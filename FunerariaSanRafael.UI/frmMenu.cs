using FunerariaSanRafael.Models;
using FunerariaSanRafael.Models.DTO;
using System.Configuration;
using System.Globalization;
//using Newtonsoft.Json;
using System.Net;
using System.Text.Json;


namespace FunerariaSanRafael.UI
{
    public partial class frmMenu : Form
    {
        mst_User usuario = new mst_User();
        public frmMenu(mst_User usuario)
        {
            InitializeComponent();

            this.usuario = usuario;

            lblNombre.Text = usuario.user_name.ToString();
        }

        ApplicationDbContext _context = new ApplicationDbContext();
        ApplicationDbContext _context2 = new ApplicationDbContext();
        ResponseGetAccounts getAccounts = new ResponseGetAccounts();
        Login log = new Login();
        string url = ConfigurationManager.AppSettings["baseApiURL"];
        bool sinc = false;

        public void formatStatus()
        {
            try
            {
                var recibo = _context.mst_Recibo.Where(x => (x.rec_status == "T") || (x.rec_status == "S")).ToList();

                foreach (var item in recibo)
                {
                    item.rec_status = "A";
                    item.updatedBy = usuario.idUser;
                    item.updatedAt = DateTime.Now;

                    _context.Entry(item).Property(x => x.rec_status).IsModified = true;
                    _context.Entry(item).Property(x => x.updatedBy).IsModified = true;
                    _context.Entry(item).Property(x => x.updatedAt).IsModified = true;

                    var ReciboPago = _context.rel_recibo_metodo_pago.Where(x => (x.cod_expediente == item.cod_expediente) && (x.rec_periodo == item.rec_periodo)).FirstOrDefault();
                    _context.rel_recibo_metodo_pago.Remove(ReciboPago);
                }
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se han podido guardar los cambios realizados \n Por favor inténtelo de nuevo \n" + ex, "Error en guardar cambios ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        public void agregarServiciosPrincipales()
        {
            try
            {
                var expedientes = _context.mst_Expediente.ToList();
                var relacion = _context.rel_expediente_servicio.ToList();
                var servicio = _context.mst_Servicio.Where(x => (x.serv_tipo == "P") || (x.serv_tipo == "A")).ToList();

                var nuevos = expedientes.ExceptBy(relacion.Select(x => x.cod_expediente), x => x.cod_expediente);

                foreach (var nuevo in nuevos)
                {
                    foreach (var serv in servicio)
                    {
                        rel_expediente_servicio nuevoServicio = new rel_expediente_servicio()
                        {
                            idServicio = (int)serv.idServicio,
                            cod_expediente = nuevo.cod_expediente,
                            createdAt = DateTime.Now,
                            createdBy = usuario.idUser,
                            rel_es_status = "A"
                        };
                        var newServicio = _context.rel_expediente_servicio.Add(nuevoServicio);
                    }
                }
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos \n Por favor inténtelo de nuevo \n" + ex, "Error de conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void sincronizar()
        {
            try
            {

                ResponseGetAccounts cuentas = JsonSerializer.Deserialize<ResponseGetAccounts>(apiCuentas(url));

                ResponseGetClients clientes = JsonSerializer.Deserialize<ResponseGetClients>(apiClientes(url));
                var expedientes = _context.mst_Expediente.ToList();

                if (sinc) { 
                    expedientes = _context2.mst_Expediente.ToList(); 
                } 


                int expCount = 0;
                int cuenCount = 0;
                int saldoCount = 0;

                if (cuentas != null)
                {
                    var cuenta = cuentas.data.Where(x => x.desc.Contains("CUENTA BANCARIA")).ToList();
                    var bancos = _context.mst_MetodoPago.ToList();

                    foreach (var item in cuenta)
                    {
                        var existeC = false;
                        foreach (var banco in bancos)
                        {
                            if (item.id == banco.idMetodoPago)
                            {
                                existeC = true;
                            }
                        }
                        if (!existeC)
                        {
                            mst_MetodoPago nuevaCuenta = new mst_MetodoPago()
                            {
                                idMetodoPago = item.id,
                                mpa_descripcion = item.name,
                                mpa_cuenta_contable = item.code,
                                mpa_status = 'A',
                                createdAt = DateTime.Now,
                                createdBy = usuario.idUser.ToString(),
                                updatedAt = null,
                                updatedBy = null,

                            };

                            var newCuenta = _context.mst_MetodoPago.Add(nuevaCuenta);
                            _context.SaveChanges();
                            cuenCount++;
                        }
                    }
                }

                if (clientes != null)
                {
                    foreach (var item in clientes.data)
                    {
                        var existe = false;
                        foreach (var exp in expedientes)
                        {
                            if (item.id == exp.cod_expediente)
                            {
                                existe = true;
                                if (Convert.ToDecimal(item.amount_avail, CultureInfo.InvariantCulture) != exp.exp_saldo)
                                {
                                    exp.exp_saldo = Convert.ToDecimal(item.amount_avail, CultureInfo.InvariantCulture);
                                    exp.exp_nombre = item.name;
                                    exp.exp_email = item.email;
                                    exp.exp_celular = item.paxphone;
                                    saldoCount++;
                                }
                            }
                        }
                        if (!existe)
                        {
                            mst_Expediente nuevoExpediente = new mst_Expediente()
                            {
                                cod_expediente = item.id,
                                exp_saldo = Convert.ToDecimal(item.amount_avail, CultureInfo.InvariantCulture),
                                idRuta = 1,
                                exp_status = 'A',
                                createdAt = DateTime.Now,
                                createdBy = usuario.idUser.ToString(),
                                updatedAt = null,
                                updatedBy = null,
                                exp_nombre = item.name,
                                exp_email = item.email,
                                exp_celular = item.paxphone,
                                exp_telefono = null,
                                exp_cedula = item.idnum,
                                exp_provincia = null,
                                exp_fec_ini_contrato = DateTime.Parse(item.datein),
                                exp_direccion = null,
                                exp_fec_utlimo_abono = null,
                                exp_categoria = null,
                                exp_comentarios = item.requested,
                            };

                            var newExpediente = _context.mst_Expediente.Add(nuevoExpediente);

                            expCount++;
                        }
                    }
                }
                _context.SaveChanges();
                _context2.SaveChanges();
                MessageBox.Show("Se han agregado " + expCount + " afiliados nuevos. \nSe han agregado " + cuenCount + " cuentas bancarias nuevas. \nSe han actualizado " + saldoCount + " expedientes.", "Datos sincronizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos \n Por favor inténtelo de nuevo \n" + ex, "Error en base de datos ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string apiCuentas(string url)
        {

            string result = "";
            WebRequest oRequest = WebRequest.Create(url);
            oRequest.Method = "POST";
            oRequest.ContentType = "application/json";
            oRequest.Headers.Add("Authorization", ConfigurationManager.AppSettings["token"]);

            using (var oSW = new StreamWriter(oRequest.GetRequestStream()))
            {
                string json = "{\"mod\": \"Accounting\", \"fn\": \"getAccounts\", \"dbName\": \"fsrafael\"}";

                oSW.Write(json);
                oSW.Flush();
                oSW.Close();
            }

            WebResponse oResponse = oRequest.GetResponse();
            using (var oSR = new StreamReader(oResponse.GetResponseStream()))
            {

                result = oSR.ReadToEnd().Trim();
            }
            return result;
        }
        public static string apiClientes(string url)
        {
            string result = "";
            WebRequest oRequest = WebRequest.Create(url);
            oRequest.Method = "POST";
            oRequest.ContentType = "application/json";
            oRequest.Headers.Add("Authorization", ConfigurationManager.AppSettings["token"]);

            using (var oSW = new StreamWriter(oRequest.GetRequestStream()))
            {
                string json = "{\"mod\": \"Client\", \"fn\": \"getFiles\", \"dbName\": \"fsrafael\"}";

                oSW.Write(json);
                oSW.Flush();
                oSW.Close();
            }

            WebResponse oResponse = oRequest.GetResponse();
            using (var oSR = new StreamReader(oResponse.GetResponseStream()))
            {

                result = oSR.ReadToEnd().Trim();
            }
            return result;
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            try
            {
                var ruta = _context.mst_Ruta.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos \n Por favor inténtelo de nuevo \n" + ex, "Error en base de datos ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            sincronizar();
            agregarServiciosPrincipales();
        }

        private void btnAfiliados_Click(object sender, EventArgs e)
        {
            try
            {
                lblTitulo.Text = "Afiliados";

                CtrlUsAfiliados ctrlUsAfiliados = new CtrlUsAfiliados(usuario);
                if (pnlExe.Contains(ctrlUsAfiliados) == false)
                {
                    pnlExe.Controls.Add(ctrlUsAfiliados);
                    ctrlUsAfiliados.Dock = DockStyle.Fill;
                    ctrlUsAfiliados.BringToFront();
                }
                else
                {
                    ctrlUsAfiliados.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos \n Por favor inténtelo de nuevo \n" + ex, "Error en base de datos ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLiquidacion_Click(object sender, EventArgs e)
        {
            try
            {
                lblTitulo.Text = "Liquidación";

                CtrlUsLiquidacion ctrlUsLiquidacion = new CtrlUsLiquidacion(usuario);
                if (pnlExe.Contains(ctrlUsLiquidacion) == false)
                {
                    pnlExe.Controls.Add(ctrlUsLiquidacion);
                    ctrlUsLiquidacion.Dock = DockStyle.Fill;
                    ctrlUsLiquidacion.BringToFront();
                }
                else
                {
                    ctrlUsLiquidacion.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos \n Por favor inténtelo de nuevo \n" + ex, "Error en base de datos ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRecibos_Click(object sender, EventArgs e)
        {
            try
            {
                lblTitulo.Text = "Generación e impresión de recibos";

                CtrlUsRecibos ctrlUsRecibos = new CtrlUsRecibos(usuario);
                if (pnlExe.Contains(ctrlUsRecibos) == false)
                {
                    pnlExe.Controls.Add(ctrlUsRecibos);
                    ctrlUsRecibos.Dock = DockStyle.Fill;
                    ctrlUsRecibos.BringToFront();
                }
                else
                {
                    ctrlUsRecibos.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos \n Por favor inténtelo de nuevo \n" + ex, "Error en base de datos ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            formatStatus();
            Application.Exit();
        }

        private void btnMenuSinc_Click(object sender, EventArgs e)
        {
            sinc = true;
            sincronizar();
            agregarServiciosPrincipales();
        }

        private void btnRutas_Click(object sender, EventArgs e)
        {

            try
            {
                lblTitulo.Text = "Mantenimiento de rutas";

                CtrlUsRutas ctrlUsRutas = new CtrlUsRutas(usuario);
                if (pnlExe.Contains(ctrlUsRutas) == false)
                {
                    pnlExe.Controls.Add(ctrlUsRutas);
                    ctrlUsRutas.Dock = DockStyle.Fill;
                    ctrlUsRutas.BringToFront();
                }
                else
                {
                    ctrlUsRutas.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos \n Por favor inténtelo de nuevo \n" + ex, "Error en base de datos ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}