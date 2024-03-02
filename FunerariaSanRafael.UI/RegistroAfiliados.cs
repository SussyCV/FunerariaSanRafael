using FunerariaSanRafael.Models;
using System.Data;

namespace FunerariaSanRafael.UI
{
    public partial class RegistroAfiliados : Form
    {


        mst_User usuario = new mst_User();

        public RegistroAfiliados(int id, int col, mst_User usuario)
        {
            InitializeComponent();


            if ((col == 1))
            {
                llenaCombo(id);
                verDatos(id);

            }
            else
            {
                llenaCombo(id);
                editaDatos(id);
            }
            this.usuario = usuario;

        }

        ApplicationDbContext _context = new ApplicationDbContext();
        private void llenaCombo(int id)
        {
            try
            {
                // ComboBox RUTA

                cbRegistroRuta.DataSource = _context.mst_Ruta.ToList();
                //campo que vera el usuario
                cbRegistroRuta.DisplayMember = "ruta_nombre";
                //campo que es el valor real
                cbRegistroRuta.ValueMember = "idRuta";

                var ind = _context.mst_Expediente.Where(x => x.cod_expediente == id).FirstOrDefault();
                cbRegistroRuta.SelectedIndex = ind.idRuta-1;


                // ComboBox SERVICIO

                //campo que vera el usuario
                cbRegistroServicio.DisplayMember = "serv_desc";
                //campo que es el valor real
                cbRegistroServicio.ValueMember = "idServicio";
                cbRegistroServicio.DataSource = _context.mst_Servicio.Where(x => x.serv_status == 'A' && x.serv_tipo != "P" && x.serv_tipo != "A").ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos \n Por favor inténtelo de nuevo \n" + ex, "Error de conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void llenaTabla()
        {
            try
            {
                var servicioDB = _context.mst_Servicio;
                var relExpedienteBD = _context.rel_expediente_servicio;

                var listaServicio = (from Servicio in servicioDB
                                     join relServicio in relExpedienteBD
                                     on Servicio.idServicio equals relServicio.idServicio
                                     where relServicio.cod_expediente == Convert.ToInt32(txtRegistroExpediente.Text)
                                     select new
                                     {
                                         relServicio.id_expediente_servicio,
                                         relServicio.cod_expediente,
                                         Servicio.idServicio,
                                         Servicio.serv_desc,
                                         Servicio.serv_costo,
                                         Servicio.serv_tipo_costo,
                                         relServicio.createdAt,
                                         relServicio.createdBy,
                                         relServicio.rel_es_status
                                     }
                    ).ToList();

                dgvRegistroServicios.DataSource = listaServicio;
                dgvRegistroServicios.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos \n Por favor inténtelo de nuevo \n" + ex, "Error de conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void verDatos(int id)
        {
            try
            {
                btnRegistroGuardar.Visible = false;
                btnRegistroGuardar.Enabled = false;

                var expWhere = _context.mst_Expediente.Where(x => x.cod_expediente == id).FirstOrDefault();

                txtRegistroNombre.Text = expWhere.exp_nombre;
                txtRegistroNombre.Enabled = false;
                txtRegistroNombre.BackColor = Color.White;

                txtRegistroCedula.Text = expWhere.exp_cedula;
                txtRegistroCedula.Enabled = false;
                txtRegistroCedula.BackColor = Color.White;

                txtRegistroExpediente.Text = expWhere.cod_expediente.ToString();
                txtRegistroExpediente.Enabled = false;
                txtRegistroExpediente.BackColor = Color.White;

                txtRegistroProvincia.Text = expWhere.exp_provincia;
                txtRegistroProvincia.Enabled = false;
                txtRegistroProvincia.BackColor = Color.White;

                txtRegistroEmail.Text = expWhere.exp_email;
                txtRegistroEmail.Enabled = false;
                txtRegistroEmail.BackColor = Color.White;

                cbRegistroRuta.Text = expWhere.idRuta.ToString();
                cbRegistroRuta.Enabled = false;
                cbRegistroRuta.BackColor = Color.White;

                txtRegistroCelular.Text = expWhere.exp_celular;
                txtRegistroCelular.Enabled = false;
                txtRegistroCelular.BackColor = Color.White;

                txtRegistroTelefono.Text = expWhere.exp_telefono;
                txtRegistroTelefono.Enabled = false;
                txtRegistroTelefono.BackColor = Color.White;

                txtRegistroDireccion.Text = expWhere.exp_direccion;
                txtRegistroDireccion.Enabled = false;
                txtRegistroDireccion.BackColor = Color.White;

                txtRegistroSaldo.Text = expWhere.exp_saldo.ToString("N");
                txtRegistroSaldo.Enabled = false;
                txtRegistroSaldo.BackColor = Color.White;

                txtRegistroObservaciones.Text = expWhere.exp_comentarios;
                txtRegistroObservaciones.Enabled = false;
                txtRegistroObservaciones.BackColor = Color.White;

                if (expWhere.exp_status == 'A')
                {
                    chekActivo.Checked = true;
                }
                else
                {
                    chekActivo.Checked = false;
                }
                chekActivo.Enabled = false;
                chekActivo.BackColor = Color.White;

                txtRegistroCuota.Enabled = false;
                txtRegistroCuota.BackColor = Color.White;

                llenaTabla();
                dgvRegistroServicios.Enabled = false;
                dgvRegistroServicios.BackColor = Color.White;

                cbRegistroServicio.Visible = false;
                label6.Visible = false;
                label14.Visible = false;
                txtRegistroCosto.Visible = false;
                btnRegistroAgregar.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos \n Por favor inténtelo de nuevo \n" + ex, "Error de conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }

        private void editaDatos(int id)
        {
            try
            {
                var expWhere = _context.mst_Expediente.Where(x => x.cod_expediente == id).FirstOrDefault();

                txtRegistroNombre.Text = expWhere.exp_nombre;
                txtRegistroNombre.Enabled = false;
                txtRegistroNombre.BackColor = Color.White;

                txtRegistroCedula.Text = expWhere.exp_cedula;
                txtRegistroCedula.Enabled = false;
                txtRegistroCedula.BackColor = Color.White;

                txtRegistroExpediente.Text = expWhere.cod_expediente.ToString();
                txtRegistroExpediente.Enabled = false;
                txtRegistroExpediente.BackColor = Color.White;

                txtRegistroProvincia.Text = expWhere.exp_provincia;
                txtRegistroProvincia.Enabled = false;
                txtRegistroProvincia.BackColor = Color.White;

                txtRegistroEmail.Text = expWhere.exp_email;
                txtRegistroEmail.Enabled = false;
                txtRegistroEmail.BackColor = Color.White;

                cbRegistroRuta.Text = expWhere.idRuta.ToString();

                txtRegistroCelular.Text = expWhere.exp_celular;
                txtRegistroCelular.Enabled = false;
                txtRegistroCelular.BackColor = Color.White;

                txtRegistroTelefono.Text = expWhere.exp_telefono;
                txtRegistroTelefono.Enabled = false;
                txtRegistroTelefono.BackColor = Color.White;

                txtRegistroDireccion.Text = expWhere.exp_direccion;

                txtRegistroSaldo.Text = expWhere.exp_saldo.ToString("N");
                txtRegistroSaldo.Enabled = false;
                txtRegistroSaldo.BackColor = Color.White;

                txtRegistroObservaciones.Text = expWhere.exp_comentarios;

                if (expWhere.exp_status == 'A')
                {
                    chekActivo.Checked = true;
                }
                else
                {
                    chekActivo.Checked = false;
                }

                txtRegistroCuota.Enabled = false;
                txtRegistroCuota.BackColor = Color.White;

                llenaTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos \n Por favor inténtelo de nuevo \n" + ex, "Error de conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }

        public void editarColumnas()
        {
            dgvRegistroServicios.RowHeadersVisible = false;

            dgvRegistroServicios.Columns["id_expediente_servicio"].Visible = false;

            dgvRegistroServicios.Columns["cod_expediente"].HeaderText = "Expediente";
            dgvRegistroServicios.Columns["cod_expediente"].Width = 88;
            dgvRegistroServicios.Columns["cod_expediente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRegistroServicios.Columns["cod_expediente"].DisplayIndex = 0;

            dgvRegistroServicios.Columns["idServicio"].HeaderText = "Servicio";
            dgvRegistroServicios.Columns["idServicio"].Width = 75;
            dgvRegistroServicios.Columns["idServicio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRegistroServicios.Columns["idServicio"].DisplayIndex = 1;

            dgvRegistroServicios.Columns["serv_desc"].HeaderText = "Descripción";
            dgvRegistroServicios.Columns["serv_desc"].Width = 200;
            dgvRegistroServicios.Columns["serv_desc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRegistroServicios.Columns["serv_desc"].DisplayIndex = 2;

            dgvRegistroServicios.Columns["serv_costo"].HeaderText = "Costo";
            dgvRegistroServicios.Columns["serv_costo"].Width = 100;
            dgvRegistroServicios.Columns["serv_costo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvRegistroServicios.Columns["serv_costo"].DisplayIndex = 3;
            dgvRegistroServicios.Columns["serv_costo"].DefaultCellStyle.Format = "N";

            dgvRegistroServicios.Columns["serv_tipo_costo"].HeaderText = "Tipo";
            dgvRegistroServicios.Columns["serv_tipo_costo"].Width = 50;
            dgvRegistroServicios.Columns["serv_tipo_costo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRegistroServicios.Columns["serv_tipo_costo"].DisplayIndex = 4;

            dgvRegistroServicios.Columns["createdAt"].HeaderText = "Fecha";
            dgvRegistroServicios.Columns["createdAt"].Width = 100;
            dgvRegistroServicios.Columns["createdAt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRegistroServicios.Columns["createdAt"].DisplayIndex = 5;
            dgvRegistroServicios.Columns["createdAt"].DefaultCellStyle.Format = "d";

            dgvRegistroServicios.Columns["createdBy"].HeaderText = "Usuario";
            dgvRegistroServicios.Columns["createdBy"].Width = 225;
            dgvRegistroServicios.Columns["createdBy"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRegistroServicios.Columns["createdBy"].DisplayIndex = 6;

            dgvRegistroServicios.Columns["rel_es_status"].HeaderText = "Status";
            dgvRegistroServicios.Columns["rel_es_status"].Width = 50;
            dgvRegistroServicios.Columns["rel_es_status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRegistroServicios.Columns["rel_es_status"].DisplayIndex = 7;

            dgvRegistroServicios.Columns["Eliminar"].DisplayIndex = 8;
        }

        public void Guardar()
        {
            try
            {
                var afiliado = _context.mst_Expediente.Find(Convert.ToInt32(txtRegistroExpediente.Text));
                if (afiliado == null)
                {
                    MessageBox.Show("No se ha actualizado la información", "Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (chekActivo.Checked == true)
                    {
                        afiliado.exp_status = 'A';
                    }
                    else
                    {
                        afiliado.exp_status = 'F';
                    }

                    afiliado.idRuta = Convert.ToInt32(cbRegistroRuta.SelectedValue);
                    afiliado.exp_direccion = txtRegistroDireccion.Text;
                    afiliado.exp_comentarios = txtRegistroObservaciones.Text;
                    afiliado.updatedBy = usuario.idUser;
                    afiliado.updatedAt = DateTime.Now;

                    _context.mst_Expediente.Update(afiliado);
                    _context.SaveChanges();
                    MessageBox.Show("Registro Actualizado correctamente", "Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos \n Por favor inténtelo de nuevo \n" + ex, "Error de conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }

        public void cargaCosto()
        {
            try
            {
                var listaServicio = _context.mst_Servicio.Find(Convert.ToInt32(cbRegistroServicio.SelectedValue));
                if (listaServicio.serv_tipo_costo == "%")
                {
                    var porcentaje = listaServicio.serv_costo / 100;
                    var cuotaP = _context.mst_Servicio.Where(x => x.serv_tipo == "P").First();
                    var cuotaA = _context.mst_Servicio.Where(x => x.serv_tipo == "A").First();
                    decimal precio = 0;


                    if (listaServicio.serv_tipo == "Z")
                    {
                        precio = cuotaA.serv_costo * porcentaje;
                    }
                    else {
                        precio = cuotaP.serv_costo * porcentaje;
                    }

                    txtRegistroCosto.Text = precio.ToString("N");
                }
                else
                {
                    txtRegistroCosto.Text = listaServicio.serv_costo.ToString("N");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos \n Por favor inténtelo de nuevo \n" + ex, "Error de conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }

        public void agregaServicio()
        {
            try
            {
                rel_expediente_servicio nuevoServicio = new rel_expediente_servicio()
                {

                    idServicio = Convert.ToInt32(cbRegistroServicio.SelectedValue),
                    cod_expediente = Convert.ToInt32(txtRegistroExpediente.Text),
                    createdAt = DateTime.Now,
                    createdBy = usuario.idUser,
                    rel_es_status = "A"
                };

                var newServicio = _context.rel_expediente_servicio.Add(nuevoServicio);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha agregado el servicio, verifique que este no haya sido previamente agregado \n" + ex, "Servicio no agregado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            llenaTabla();
            calculoCuota();
        }

        public void eliminarServicio(int id)
        {
            try
            {
                var c = _context.rel_expediente_servicio.Where(x => x.id_expediente_servicio == id).FirstOrDefault();

                _context.rel_expediente_servicio.Remove(c);
                _context.SaveChanges();

                llenaTabla();
                calculoCuota();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos \n Por favor inténtelo de nuevo \n" + ex, "Error de conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }

        public void calculoCuota()
        {
            try
            {
                var servicioDB = _context.mst_Servicio;
                var relExpedienteBD = _context.rel_expediente_servicio;

                var listaCuota = (from Servicio in servicioDB
                                  join relServicio in relExpedienteBD
                                  on Servicio.idServicio equals relServicio.idServicio
                                  where relServicio.cod_expediente == Convert.ToInt32(txtRegistroExpediente.Text)
                                  select new
                                  {
                                      relServicio.id_expediente_servicio,
                                      relServicio.cod_expediente,
                                      Servicio.idServicio,
                                      Servicio.serv_desc,
                                      Servicio.serv_costo,
                                      Servicio.serv_tipo_costo,
                                      Servicio.serv_tipo,
                                      relServicio.createdAt,
                                      relServicio.createdBy,
                                      relServicio.rel_es_status
                                  }
                    ).ToList();

                Decimal Cuota = 0;

                foreach (var item in listaCuota)
                {
                    if (item.serv_tipo_costo == "%")
                    {
                        var porcentaje = item.serv_costo / 100;
                        var cuotaP = _context.mst_Servicio.Where(x => x.serv_tipo == "P").First();
                        var cuotaA = _context.mst_Servicio.Where(x => x.serv_tipo == "A").First();

                        if (item.serv_tipo == "X")
                        {
                            Cuota = Cuota - cuotaP.serv_costo * porcentaje;
                        }
                        else { 
                            if (item.serv_tipo == "Z") {
                                Cuota = Cuota - cuotaA.serv_costo * porcentaje;
                            }
                            else
                            {
                                Cuota = Cuota + cuotaP.serv_costo * porcentaje;
                            }
                        }
                        
                    }
                    else
                    {
                        if ((item.serv_tipo == "X") || (item.serv_tipo == "Z"))
                        {
                            Cuota = Cuota - item.serv_costo;
                        }
                        else {
                            Cuota = Cuota + item.serv_costo;
                        }
                    }
                }

                txtRegistroCuota.Text = Cuota.ToString("N");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos \n Por favor inténtelo de nuevo \n" + ex, "Error de conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistroSalir_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
            }
        }

        private void RegistroAfiliados_Load(object sender, EventArgs e)
        {
            editarColumnas();
            calculoCuota();
        }

        private void btnRegistroGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void btnRegistroAgregar_Click(object sender, EventArgs e)
        {
            agregaServicio();
        }

        private void cbRegistroServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargaCosto();
        }

        private void dgvRegistroServicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0) // Valida que se le dio clik a la celda en posición 0 (Eliminar)
                {


                    int idServ = Convert.ToInt32(dgvRegistroServicios.Rows[e.RowIndex].Cells["idServicio"].Value);
                    try
                    {

                        var permitir = _context.mst_Servicio.Where(x => x.idServicio == idServ).FirstOrDefault();

                        if (permitir.serv_tipo == "P" || permitir.serv_tipo == "A")
                        {
                            MessageBox.Show("Este servicio no puede ser eliminado", "Servicio no eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            int id = Convert.ToInt32(dgvRegistroServicios.Rows[e.RowIndex].Cells["id_expediente_servicio"].Value);
                            eliminarServicio(id);
                        }
                    }
                    catch (Exception ex1)
                    {
                        MessageBox.Show("No se ha podido acceder a la base de datos \n Inténtelo de nuevo \n" + ex1, "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex) { }
        }
    }
}
