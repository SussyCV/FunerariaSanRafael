using FunerariaSanRafael.Models;
using FunerariaSanRafael.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Configuration;

namespace FunerariaSanRafael.UI
{
    public partial class CtrlUsLiquidacion : UserControl
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        mst_User usuario = new mst_User();
        Liquidar Lq = new Liquidar();
        string url = ConfigurationManager.AppSettings["baseApiURL"];

        public CtrlUsLiquidacion(mst_User usuario)
        {
            InitializeComponent();
            this.usuario = usuario;

        }

        public void CargarTabla()
        {
            int i = 0;
            try
            {
                // A liquidar
                var listarLiquidacion = (from aLiquidar in _context.rel_recibo_metodo_pago
                                         join Pago in _context.mst_MetodoPago
                                    on aLiquidar.idMetodoPago equals Pago.idMetodoPago
                                         join recibo in _context.mst_Recibo
                                    on new { aLiquidar.cod_expediente, aLiquidar.rec_periodo } equals new
                                    {
                                        recibo.cod_expediente,
                                        recibo.rec_periodo
                                    }
                                         select new
                                         {
                                             Pago.mpa_descripcion,
                                             aLiquidar.cod_expediente,
                                             aLiquidar.rec_periodo,
                                             aLiquidar.mpa_monto_recibido,
                                             recibo.rec_status,
                                             recibo.rec_deducciones,

                                         }
                                ).ToList();

                var listaLiquidar = listarLiquidacion.Where(x => x.rec_status == "T").ToList();
                dgvLiquidacionPagos.DataSource = listaLiquidar;


                // Totales


                var metodos = _context.mst_MetodoPago.ToList();

                List<Total> pagosTotal = new List<Total>();

                foreach (var item in metodos)
                {
                    Total total = new Total()
                    {
                        metodoPago = item.mpa_descripcion,
                        cantidad = listaLiquidar.Where(x => x.mpa_descripcion == item.mpa_descripcion).Count(),
                        total = listaLiquidar.Where(x => x.mpa_descripcion == item.mpa_descripcion).Sum(x => x.mpa_monto_recibido + x.rec_deducciones),
                    };
                    pagosTotal.Add(total);
                }
                dgvLiquidacionTotales.DataSource = pagosTotal;


                // General
                var listarRecibo = (from Recibo in _context.mst_Recibo
                                    join Expediente in _context.mst_Expediente
                                    on Recibo.cod_expediente equals Expediente.cod_expediente
                                    select new
                                    {
                                        Recibo.Selec,
                                        Recibo.cod_expediente,
                                        Expediente.exp_nombre,
                                        Expediente.idRuta,
                                        Recibo.rec_fechaPago,
                                        Recibo.rec_status,
                                        Recibo.rec_aporte_anterior,
                                        Recibo.rec_monto,
                                        Recibo.rec_deducciones,
                                        Recibo.rec_periodo,
                                        Recibo.updatedAt,
                                        Recibo.updatedBy,
                                        Recibo.numRecibo,
                                    }
                    ).ToList();

                var listaGeneral = listarRecibo.Where(x => (x.rec_status == "A") || (x.rec_status == "S")).ToList();

                //Flitra por ruta
                listaGeneral = listaGeneral.Where(x => (x.idRuta == Convert.ToInt32(cbLiquidacionRuta.SelectedValue, CultureInfo.InvariantCulture) || (cbLiquidacionRuta.SelectedValue.ToString() == "0"))).ToList();


                //Flitra por periodo
                if (!string.IsNullOrEmpty(cbLiquidacionMes.Text))
                {
                    if (cbLiquidacionMes.Text == "Todos")
                    {
                    }
                    else
                    {
                        var rec_periodoDe = Convert.ToInt32(udLiquidacionAnio.Value.ToString() + cbLiquidacionMes.Text, CultureInfo.InvariantCulture);
                        var rec_periodoA = Convert.ToInt32(udLiquidacionAnioA.Value.ToString() + cbLiquidacionMesA.Text, CultureInfo.InvariantCulture);
                        listaGeneral = listaGeneral.Where(x => (x.rec_periodo >= rec_periodoDe && x.rec_periodo <= rec_periodoA)).ToList();
                    }
                }

                //Flitra por nombre
                if (!string.IsNullOrEmpty(txtLiquidacionNombre.Text))
                {
                    listaGeneral = listaGeneral.Where(x => x.exp_nombre.ToLower().Contains(txtLiquidacionNombre.Text.ToLower())).ToList();
                }

                //Flitra por expediente
                if (!string.IsNullOrEmpty(txtLiquidacionExpediente.Text))
                {
                    listaGeneral = listaGeneral.Where(x => x.cod_expediente.ToString().Contains(txtLiquidacionExpediente.Text)).ToList();
                }

                //Flitra por idRecibo
                if (!string.IsNullOrEmpty(txtLiquidacionRecibo.Text))
                {
                    listaGeneral = listaGeneral.Where(x => x.numRecibo.ToString().Contains(txtLiquidacionRecibo.Text)).ToList();
                }

                dgvLiquidacionCompleta.DataSource = listaGeneral;

                // Calculo total de liquidacion
                var liquidacionTotal = _context.mst_Recibo.Where(x => x.rec_status == "T").Sum(x => x.rec_monto + x.rec_deducciones);
                lblLiquidacionTotal.Text = liquidacionTotal?.ToString("N");

                // Habilita el boton de liquidar
                if (!string.IsNullOrEmpty(txtLiquidacionTotalRecibido.Text))
                {
                    var recibido = Convert.ToDecimal(txtLiquidacionTotalRecibido.Text, CultureInfo.InvariantCulture);

                    if (liquidacionTotal == recibido)
                        btnLiquidacionLiquidar.Enabled = true;
                    else
                        btnLiquidacionLiquidar.Enabled = false;
                }

                lblLiquidacionSeleccionado.Text = listaGeneral.Where(x => x.rec_status == "S").Sum(x => x.rec_monto).ToString("N");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos \n Por favor inténtelo de nuevo \n" + ex, "Error de conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void editarColumnasPrincipal()
        {
            try
            {
                dgvLiquidacionCompleta.RowHeadersVisible = false;

                dgvLiquidacionCompleta.Columns["updatedAt"].Visible = false;
                dgvLiquidacionCompleta.Columns["updatedBy"].Visible = false;
                dgvLiquidacionCompleta.Columns["rec_fechaPago"].Visible = false;

                dgvLiquidacionCompleta.Columns["cod_expediente"].HeaderText = "Expediente";
                dgvLiquidacionCompleta.Columns["cod_expediente"].Width = 90;
                dgvLiquidacionCompleta.Columns["cod_expediente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvLiquidacionCompleta.Columns["cod_expediente"].DisplayIndex = 2;

                dgvLiquidacionCompleta.Columns["exp_nombre"].HeaderText = "Nombre";
                dgvLiquidacionCompleta.Columns["exp_nombre"].Width = 250;
                dgvLiquidacionCompleta.Columns["exp_nombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvLiquidacionCompleta.Columns["exp_nombre"].DisplayIndex = 3;

                dgvLiquidacionCompleta.Columns["numRecibo"].HeaderText = "Doc #";
                dgvLiquidacionCompleta.Columns["numRecibo"].Width = 75;
                dgvLiquidacionCompleta.Columns["numRecibo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvLiquidacionCompleta.Columns["numRecibo"].DisplayIndex = 4;

                dgvLiquidacionCompleta.Columns["rec_periodo"].HeaderText = "Periodo";
                dgvLiquidacionCompleta.Columns["rec_periodo"].Width = 65;
                dgvLiquidacionCompleta.Columns["rec_periodo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvLiquidacionCompleta.Columns["rec_periodo"].DisplayIndex = 5;

                dgvLiquidacionCompleta.Columns["rec_aporte_anterior"].HeaderText = "Aporte anterior";
                dgvLiquidacionCompleta.Columns["rec_aporte_anterior"].Width = 140;
                dgvLiquidacionCompleta.Columns["rec_aporte_anterior"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvLiquidacionCompleta.Columns["rec_aporte_anterior"].DefaultCellStyle.Format = "N";
                dgvLiquidacionCompleta.Columns["rec_aporte_anterior"].DisplayIndex = 6;

                dgvLiquidacionCompleta.Columns["rec_monto"].HeaderText = "Monto";
                dgvLiquidacionCompleta.Columns["rec_monto"].Width = 75;
                dgvLiquidacionCompleta.Columns["rec_monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvLiquidacionCompleta.Columns["rec_monto"].DefaultCellStyle.Format = "N";
                dgvLiquidacionCompleta.Columns["rec_monto"].DisplayIndex = 7;

                dgvLiquidacionCompleta.Columns["rec_deducciones"].HeaderText = "Deducciones";
                dgvLiquidacionCompleta.Columns["rec_deducciones"].Width = 100;
                dgvLiquidacionCompleta.Columns["rec_deducciones"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvLiquidacionCompleta.Columns["rec_deducciones"].DefaultCellStyle.Format = "N";
                dgvLiquidacionCompleta.Columns["rec_deducciones"].DisplayIndex = 8;

                dgvLiquidacionCompleta.Columns["rec_status"].HeaderText = "Status";
                dgvLiquidacionCompleta.Columns["rec_status"].Width = 50;
                dgvLiquidacionCompleta.Columns["rec_status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvLiquidacionCompleta.Columns["rec_status"].DisplayIndex = 9;

                dgvLiquidacionCompleta.Columns["idRuta"].HeaderText = "Ruta";
                dgvLiquidacionCompleta.Columns["idRuta"].Width = 50;
                dgvLiquidacionCompleta.Columns["idRuta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvLiquidacionCompleta.Columns["idRuta"].DisplayIndex = 10;

                dgvLiquidacionCompleta.Columns["Selec"].DisplayIndex = 1;
                dgvLiquidacionCompleta.Columns["Selec"].Width = 65;
                dgvLiquidacionCompleta.Columns["Agregar"].DisplayIndex = 0;
                dgvLiquidacionCompleta.Columns["Agregar"].Width = 65;
            }
            catch (Exception ex) { }
        }
        public void editarColumnasSecundaria()
        {
            try
            {
                dgvLiquidacionPagos.RowHeadersVisible = false;

                dgvLiquidacionPagos.Columns["mpa_descripcion"].HeaderText = "Método de pago";
                dgvLiquidacionPagos.Columns["mpa_descripcion"].Width = 200;
                dgvLiquidacionPagos.Columns["mpa_descripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvLiquidacionPagos.Columns["mpa_descripcion"].DisplayIndex = 1;

                dgvLiquidacionPagos.Columns["cod_expediente"].HeaderText = "Expediente";
                dgvLiquidacionPagos.Columns["cod_expediente"].Width = 75;
                dgvLiquidacionPagos.Columns["cod_expediente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvLiquidacionPagos.Columns["cod_expediente"].DisplayIndex = 2;

                dgvLiquidacionPagos.Columns["rec_periodo"].HeaderText = "Periodo";
                dgvLiquidacionPagos.Columns["rec_periodo"].Width = 65;
                dgvLiquidacionPagos.Columns["rec_periodo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvLiquidacionPagos.Columns["rec_periodo"].DisplayIndex = 3;

                dgvLiquidacionPagos.Columns["mpa_monto_recibido"].HeaderText = "Monto";
                dgvLiquidacionPagos.Columns["mpa_monto_recibido"].Width = 75;
                dgvLiquidacionPagos.Columns["mpa_monto_recibido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvLiquidacionPagos.Columns["mpa_monto_recibido"].DefaultCellStyle.Format = "N";
                dgvLiquidacionPagos.Columns["mpa_monto_recibido"].DisplayIndex = 4;

                dgvLiquidacionPagos.Columns["rec_status"].HeaderText = "Status";
                dgvLiquidacionPagos.Columns["rec_status"].Width = 50;
                dgvLiquidacionPagos.Columns["rec_status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvLiquidacionPagos.Columns["rec_status"].DisplayIndex = 5;

                dgvLiquidacionTotales.RowHeadersVisible = false;

                dgvLiquidacionTotales.Columns["metodoPago"].HeaderText = "Metodo Pago";
                dgvLiquidacionTotales.Columns["metodoPago"].Width = 220;
                dgvLiquidacionTotales.Columns["metodoPago"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvLiquidacionTotales.Columns["metodoPago"].DisplayIndex = 0;

                dgvLiquidacionTotales.Columns["cantidad"].HeaderText = "Cantidad";
                dgvLiquidacionTotales.Columns["cantidad"].Width = 100;
                dgvLiquidacionTotales.Columns["cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvLiquidacionTotales.Columns["cantidad"].DisplayIndex = 1;

                dgvLiquidacionTotales.Columns["total"].HeaderText = "Total";
                dgvLiquidacionTotales.Columns["total"].Width = 120;
                dgvLiquidacionTotales.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvLiquidacionTotales.Columns["total"].DisplayIndex = 2;
                dgvLiquidacionTotales.Columns["total"].DefaultCellStyle.Format = "N";
            }
            catch (Exception ex) { }
        }
        public void AgregarRegistro(int id, int Periodo, int Expediente)
        {
            try
            {
                if (cbLiquidacionPago.SelectedIndex == -1)
                    MessageBox.Show("No hay metodo de pago");
                else
                {
                    var recibo = _context.mst_Recibo.Where(x => x.numRecibo == id && x.cod_expediente == Expediente && x.rec_periodo == Periodo).FirstOrDefault();

                    recibo.rec_status = "T";
                    recibo.updatedBy = usuario.idUser;
                    recibo.updatedAt = DateTime.Now;

                    _context.Entry(recibo).Property(x => x.rec_status).IsModified = true;
                    _context.Entry(recibo).Property(x => x.updatedBy).IsModified = true;
                    _context.Entry(recibo).Property(x => x.updatedAt).IsModified = true;

                    rel_recibo_metodo_pago ReciboPago = new rel_recibo_metodo_pago()
                    {
                        cod_expediente = recibo.cod_expediente,
                        rec_periodo = recibo.rec_periodo,
                        mpa_monto_recibido = recibo.rec_monto,
                        idMetodoPago = Convert.ToInt32(cbLiquidacionPago.SelectedValue, CultureInfo.InvariantCulture),
                        createdAt = DateTime.Now,
                        createdBy = usuario.idUser,
                    };

                    _context.rel_recibo_metodo_pago.Add(ReciboPago);
                    _context.SaveChanges();
                }

                CargarTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos \n Por favor inténtelo de nuevo \n" + ex, "Error de conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void RegresarRegistro(int expediente, int periodo)
        {
            try
            {
                var recibo = _context.mst_Recibo.Where(x => (x.cod_expediente == expediente) && (x.rec_periodo == periodo)).FirstOrDefault();

                recibo.rec_status = "A";
                recibo.updatedBy = usuario.idUser;
                recibo.updatedAt = DateTime.Now;
                recibo.Selec = false;

                _context.Entry(recibo).Property(x => x.rec_status).IsModified = true;
                _context.Entry(recibo).Property(x => x.updatedBy).IsModified = true;
                _context.Entry(recibo).Property(x => x.updatedAt).IsModified = true;

                var ReciboPago = _context.rel_recibo_metodo_pago.Where(x => (x.cod_expediente == expediente) && (x.rec_periodo == periodo)).FirstOrDefault();

                _context.rel_recibo_metodo_pago.Remove(ReciboPago);
                _context.SaveChanges();

                CargarTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos \n Por favor inténtelo de nuevo \n" + ex, "Error de conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void AgregarSeleccion()
        {
            try
            {
                var lista = _context.mst_Recibo.Where(x => x.rec_status == "S").ToList();

                if (lista.Count > 0)
                {
                    foreach (var item in lista)
                    {
                        int idRecibo = item.numRecibo;
                        int periodo = item.rec_periodo;
                        int expediente = item.cod_expediente;

                        AgregarRegistro(idRecibo, periodo, expediente);
                    }
                    CargarTabla();
                }
                else
                {
                    MessageBox.Show("No ha seleccionado ningún recibo \n Seleccione los recibos que desea agregar", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos \n Por favor inténtelo de nuevo \n" + ex, "Error de conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SeleccionarTodo()
        {
            try
            {
                //Flitra por activo
                var listaSeleccionado = _context.mst_Recibo.Where(x => x.rec_status == "A").ToList();

                //Flitra por ruta
                listaSeleccionado = listaSeleccionado.Where(x => (x.idRuta == Convert.ToInt32(cbLiquidacionRuta.SelectedValue, CultureInfo.InvariantCulture) || (cbLiquidacionRuta.SelectedValue.ToString() == "0"))).ToList();

                //Flitra por Nombre
                if (!string.IsNullOrEmpty(txtLiquidacionNombre.Text))
                {
                    var exp = _context.mst_Expediente.Where(x => x.exp_nombre.ToLower().Contains(txtLiquidacionNombre.Text.ToLower())).ToList();
                    if (exp.Count > 0)
                    {
                        foreach (var item in exp)
                        {
                            listaSeleccionado = listaSeleccionado.Where(x => x.cod_expediente == item.cod_expediente).ToList();
                        }
                    }
                    else { listaSeleccionado.Clear(); }
                }

                //Flitra por expediente
                if (!string.IsNullOrEmpty(txtLiquidacionExpediente.Text))
                {
                    listaSeleccionado = listaSeleccionado.Where(x => x.cod_expediente.ToString().Contains(txtLiquidacionExpediente.Text)).ToList();
                }

                //Flitra por periodo
                if (!string.IsNullOrEmpty(cbLiquidacionMes.Text))
                {
                    if (cbLiquidacionMes.Text == "Todos")
                    {
                    }
                    else
                    {
                        var rec_periodo = Convert.ToInt32(udLiquidacionAnio.Value.ToString() + cbLiquidacionMes.Text, CultureInfo.InvariantCulture);
                        listaSeleccionado = listaSeleccionado.Where(x => (x.rec_periodo == rec_periodo)).ToList();
                    }
                }

                //Flitra por idRecibo
                if (!string.IsNullOrEmpty(txtLiquidacionRecibo.Text))
                {
                    listaSeleccionado = listaSeleccionado.Where(x => x.numRecibo.ToString().Contains(txtLiquidacionRecibo.Text)).ToList();
                }

                if (listaSeleccionado.Count > 0)
                {
                    foreach (var item in listaSeleccionado)
                    {
                        item.Selec = true;
                        item.rec_status = "S";

                        _context.Entry(item).Property(x => x.rec_status).IsModified = true;
                        _context.SaveChanges();
                    }
                    btnLiquidacionSeleccionarTodo.Text = "Deseleccionar todos";
                }
                else
                {
                    MessageBox.Show("No existen recivos a seleccionar", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                CargarTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos \n Por favor inténtelo de nuevo \n" + ex, "Error de conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void DeSeleccionarTodo()
        {
            try
            {
                var QuitarSeleccion = _context.mst_Recibo.Where(x => x.rec_status == "S").ToList();

                foreach (var item in QuitarSeleccion)
                {
                    item.Selec = false;
                    item.rec_status = "A";

                    _context.Entry(item).Property(x => x.rec_status).IsModified = true;
                    _context.SaveChanges();
                }

                lblLiquidacionSeleccionado.Text = 0.ToString("N");

                btnLiquidacionSeleccionarTodo.Text = "Seleccionar todos";

                CargarTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos \n Por favor inténtelo de nuevo \n" + ex, "Error de conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SeleccionarRegistro(int id)
        {
            try
            {
                var result2 = _context.mst_Recibo.Where(x => x.numRecibo == id).FirstOrDefault();

                if (result2.rec_status == "S")
                {
                    result2.Selec = false;
                    result2.rec_status = "A";
                }
                else
                {
                    result2.Selec = true;
                    result2.rec_status = "S";
                }
                _context.Entry(result2).Property(x => x.rec_status).IsModified = true;
                _context.SaveChanges();

                CargarTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos \n Por favor inténtelo de nuevo \n" + ex, "Error de conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public async void Liquidar()
        {
            try
            {
                sincronizar();
                int count = 0;

                var recibo = _context.mst_Recibo.Where(x => x.rec_status == "T").ToList();
                ResponseGetAccounts cuentas = JsonSerializer.Deserialize<ResponseGetAccounts>(apiCuentas(url));

                

                foreach (var item in recibo)
                {
                    item.rec_fechaLiquidacion = DateTime.Now;
                    _context.Entry(item).Property(x => x.rec_fechaLiquidacion).IsModified = true;
                }
                _context.SaveChanges();

                foreach (var item in recibo)
                {
                    var numCuenta = await _context.rel_recibo_metodo_pago.Where(x => (x.cod_expediente == item.cod_expediente) && (x.rec_periodo == item.rec_periodo)).FirstOrDefaultAsync();

                    var rServicio = await _context.rel_expediente_servicio.Where(x => x.cod_expediente == item.cod_expediente).ToListAsync();

                    var cuota = await _context.mst_Servicio.Where(x => x.serv_tipo == "P").FirstOrDefaultAsync();

                    var expServicio = (from expS in rServicio
                                       join serV in _context.mst_Servicio
                                        on expS.idServicio equals serV.idServicio
                                       select new
                                       {
                                           expS.idServicio,
                                           serV.serv_costo,
                                           serV.serv_desc,
                                           serV.serv_tipo_costo,
                                           serV.serv_cuenta_contable,
                                       }
                                ).ToList();

					var x = dateTimePicker1.Value;
					decimal montoAcumulado = 0;

                    ResponseCreateReceipt datos = new ResponseCreateReceipt()
                    {
                        mod = "Accounting",
                        fn = "createReceipt",
                        dbName = "fsrafael",
                        file_id = item.cod_expediente,
                        id_referencia = item.numRecibo.ToString(),
						fecha = x.Year + "-" + x.Month + "-" + x.Day
					};

                    List<Aporte> aporteList = new List<Aporte>();
                    List<Otro> otrosList = new List<Otro>();

                    foreach (var serv1 in expServicio)
                    {
                        if (serv1.serv_tipo_costo == "M")
                        {
                            montoAcumulado = montoAcumulado + serv1.serv_costo;
                        }
                        else
                        {
                            var porcent = serv1.serv_costo / 100;
                            montoAcumulado = montoAcumulado + cuota.serv_costo * porcent;
                        }
                    }

                        Aporte aporte = new Aporte()
                    {
                        monto = montoAcumulado,
                        id_cuenta_banco = Convert.ToInt32(cbLiquidacionPago.SelectedValue, CultureInfo.InvariantCulture),
                    };
                    aporteList.Add(aporte);

                    

                    decimal precio = 0;

                    foreach (var serv in expServicio)
                    {
                        if (serv.serv_tipo_costo == "M")
                        {
                            precio = serv.serv_costo;
                        }
                        else
                        {
                            var porcent = serv.serv_costo / 100;
                            precio = cuota.serv_costo * porcent;
                        }
                   
                            var cuentaContable = cuentas.data.Where(x => x.code == serv.serv_cuenta_contable).FirstOrDefault();

                        Otro otro = new Otro()
                        {
                            monto = precio,
                            id_referencia = serv.idServicio.ToString(),
                            referencia = serv.serv_desc,
                            id_cuenta = cuentaContable.id,
                        };
                        otrosList.Add(otro);
                    }


                    datos.aporte = aporteList;
                    datos.otros = otrosList;

                    string result = apiRecibos(url, datos);
                    count++;
                }

                foreach (var item in recibo)
                {
                    item.rec_status = "P";
                    item.updatedBy = usuario.idUser;
                    item.updatedAt = DateTime.Now;
                    //item.rec_fechaLiquidacion = DateTime.Now;
                    item.rec_fechaLiquidacion = dateTimePicker1.Value;

                    _context.Entry(item).Property(x => x.rec_status).IsModified = true;
                    _context.Entry(item).Property(x => x.updatedBy).IsModified = true;
                    _context.Entry(item).Property(x => x.updatedAt).IsModified = true;
                    _context.Entry(item).Property(x => x.rec_fechaLiquidacion).IsModified = true;
                }

                _context.SaveChanges();

                CargarTabla();
                sincronizar();

                MessageBox.Show("Se han liquidado exitosamente "+ count + " recibos", "Liquidación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos \n Por favor inténtelo de nuevo \n" + ex, "Error de conexión",
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

        public static string apiRecibos(string url, ResponseCreateReceipt responseCreateReceiptList)
        {
            string result = "";
            WebRequest oRequest = WebRequest.Create(url);
            oRequest.Method = "POST";
            oRequest.ContentType = "application/json";
            oRequest.Headers.Add("Authorization", ConfigurationManager.AppSettings["token"]);

            using (var oSW = new StreamWriter(oRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(responseCreateReceiptList);

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
        public void sincronizar()
        {
            try
            {
                ApplicationDbContext _context2 = new ApplicationDbContext();
                ResponseGetClients clientes = JsonSerializer.Deserialize<ResponseGetClients>(apiClientes(url));
                var expedientes = _context2.mst_Expediente.ToList();

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
                        }
                    }
                }
                _context.SaveChanges();
                _context2.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos \n Por favor inténtelo de nuevo \n" + ex, "Error en base de datos ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnLiquidacionBuscar_Click(object sender, EventArgs e)
        {
            CargarTabla();
        }

        private void txtLiquidacionNombre_TextChanged(object sender, EventArgs e)
        {
            CargarTabla();
        }

        private void txtLiquidacionRecibo_TextChanged(object sender, EventArgs e)
        {
            CargarTabla();

        }

        private void txtLiquidacionTotalRecibido_TextChanged(object sender, EventArgs e)
        {
            CargarTabla();

        }

        private void txtLiquidacionExpediente_TextChanged(object sender, EventArgs e)
        {
            CargarTabla();
        }

        private void txtLiquidacionRecibo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtLiquidacionTotalRecibido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtLiquidacionExpediente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CtrlUsLiquidacion_Load(object sender, EventArgs e)
        {
            try
            {
                // ComboBox RUTA
                var combo = _context.mst_Ruta.ToList();
                combo.Add(new mst_Ruta() { idRuta = 0, ruta_nombre = "Todas" });
                List<mst_Ruta> comboOrden = combo.OrderBy(x => x.idRuta).ToList();


                cbLiquidacionRuta.DataSource = comboOrden;
                //campo que vera el usuario
                cbLiquidacionRuta.DisplayMember = "ruta_nombre";
                //campo que es el valor real
                cbLiquidacionRuta.ValueMember = "idRuta";

                // ComboBox Metodo de pago
                cbLiquidacionPago.DataSource = _context.mst_MetodoPago.ToList();
                //campo que vera el usuario
                cbLiquidacionPago.DisplayMember = "mpa_descripcion";
                //campo que es el valor real
                cbLiquidacionPago.ValueMember = "idMetodoPago";

                DateTime fecha = DateTime.Now;
                string s = fecha.Month.ToString();
                cbLiquidacionMes.SelectedIndex = fecha.Month;
                udLiquidacionAnio.Value = fecha.Year;

                cbLiquidacionMesA.SelectedIndex = fecha.Month;
                udLiquidacionAnioA.Value = fecha.Year;

                CargarTabla();
                editarColumnasPrincipal();
                editarColumnasSecundaria();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos \n Por favor inténtelo de nuevo \n" + ex, "Error de conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnLiquidacionSeleccionarTodo_Click_1(object sender, EventArgs e)
        {
            if (btnLiquidacionSeleccionarTodo.Text == "Seleccionar todos")
            {

                SeleccionarTodo();
            }
            else if (btnLiquidacionSeleccionarTodo.Text == "Deseleccionar todos")
            {

                DeSeleccionarTodo();
            }
        }

        private void btnLiquidacionAgregarTodos_Click_1(object sender, EventArgs e)
        {
            btnLiquidacionSeleccionarTodo.Text = "Seleccionar todos";
            AgregarSeleccion();
        }

        private void btnLiquidacionLiquidar_Click_1(object sender, EventArgs e)
        {
            Liquidar();
        }

        private void dgvLiquidacionPagos_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0) // Valida que se le dio clik a la celda en posición 0 (Deshacer)
                {

                    int expediente = Convert.ToInt32(dgvLiquidacionPagos.Rows[e.RowIndex].Cells["cod_expediente"].Value, CultureInfo.InvariantCulture);
                    int periodo = Convert.ToInt32(dgvLiquidacionPagos.Rows[e.RowIndex].Cells["rec_periodo"].Value, CultureInfo.InvariantCulture);

                    RegresarRegistro(expediente, periodo);
                }
            }
            catch (Exception ex) { }
        }

        private void dgvLiquidacionCompleta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0) // Valida que se le dio clik a la celda en posición 0 (Agregar)
                {
                    int idRecibo = Convert.ToInt32(dgvLiquidacionCompleta.Rows[e.RowIndex].Cells["numRecibo"].Value, CultureInfo.InvariantCulture);
                    int Periodo = Convert.ToInt32(dgvLiquidacionCompleta.Rows[e.RowIndex].Cells["rec_periodo"].Value, CultureInfo.InvariantCulture);
                    int Expediente = Convert.ToInt32(dgvLiquidacionCompleta.Rows[e.RowIndex].Cells["cod_expediente"].Value, CultureInfo.InvariantCulture);

                    AgregarRegistro(idRecibo, Periodo, Expediente);
                }

                if (e.ColumnIndex == 1) // Valida que se le dio clik a la celda en posición 1 (Selec)
                {
                    int id = (int)dgvLiquidacionCompleta.Rows[e.RowIndex].Cells["numRecibo"].Value;
                    SeleccionarRegistro(id);
                }
            }
            catch (Exception ex) { }
        }

        private void cbLiquidacionPago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
