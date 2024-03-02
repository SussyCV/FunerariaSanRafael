using FunerariaSanRafael.Models;
using System.Data;

namespace FunerariaSanRafael.UI
{
    public partial class CtrlUsAfiliados : UserControl
    {
        mst_User usuario = new mst_User();
        public CtrlUsAfiliados(mst_User usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        ApplicationDbContext _context = new ApplicationDbContext();

        public void tablaAfiliados()
        {
            try
            {
                ApplicationDbContext _context2 = new ApplicationDbContext();

                var listaAfiliados = _context2.mst_Expediente.Where(x => ((x.idRuta.ToString() == cbAfiliadosRuta.SelectedValue.ToString()) || (cbAfiliadosRuta.SelectedValue.ToString() == "0") || (cbAfiliadosRuta.Text == ""))).ToList();

                if (!string.IsNullOrEmpty(txtAfiliadosID.Text))
                {
                    listaAfiliados = listaAfiliados.Where(x => x.cod_expediente.ToString().Contains(txtAfiliadosID.Text)).ToList();
                }

                if (!string.IsNullOrEmpty(txtAfiliadosNombre.Text))
                {
                    listaAfiliados = listaAfiliados.Where(x => x.exp_nombre.ToLower().Contains(txtAfiliadosNombre.Text.ToLower())).ToList();
                }

                dgvAfiliadosCompleta.DataSource = listaAfiliados;
                agregarServiciosPrincipales();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos \n Por favor inténtelo de nuevo \n" + ex, "Error en base de datos ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void actualizaTabla()
        {
            try
            {
                var listaActualiza = _context.mst_Expediente.Where(x => ((x.idRuta.ToString() == cbAfiliadosRuta.SelectedValue.ToString()) || (cbAfiliadosRuta.Text == "Todas") || (cbAfiliadosRuta.Text == ""))).ToList();

                if (!string.IsNullOrEmpty(txtAfiliadosID.Text))
                {
                    listaActualiza = listaActualiza.Where(x => x.cod_expediente == Convert.ToInt32(txtAfiliadosID.Text)).ToList();
                }

                if (!string.IsNullOrEmpty(txtAfiliadosNombre.Text))
                {
                    listaActualiza = listaActualiza.Where(x => x.exp_nombre.ToLower().Contains(txtAfiliadosNombre.Text.ToLower())).ToList();
                }
                dgvAfiliadosCompleta.DataSource = listaActualiza;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos \n Por favor inténtelo de nuevo \n" + ex, "Error en base de datos ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        public void editarColumnas()
        {
            dgvAfiliadosCompleta.RowHeadersVisible = false;

            dgvAfiliadosCompleta.Columns["createdAt"].Visible = false;
            dgvAfiliadosCompleta.Columns["createdBy"].Visible = false;
            dgvAfiliadosCompleta.Columns["updatedAt"].Visible = false;
            dgvAfiliadosCompleta.Columns["updatedBy"].Visible = false;
            dgvAfiliadosCompleta.Columns["exp_fec_ini_contrato"].Visible = false;
            dgvAfiliadosCompleta.Columns["exp_categoria"].Visible = false;

            dgvAfiliadosCompleta.Columns["exp_nombre"].HeaderText = "Nombre";
            dgvAfiliadosCompleta.Columns["exp_nombre"].Width = 400;


            dgvAfiliadosCompleta.Columns["cod_expediente"].HeaderText = "Expediente";
            dgvAfiliadosCompleta.Columns["cod_expediente"].Width = 90;
            dgvAfiliadosCompleta.Columns["cod_expediente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvAfiliadosCompleta.Columns["exp_saldo"].HeaderText = "Saldo";
            dgvAfiliadosCompleta.Columns["exp_saldo"].Width = 125;
            dgvAfiliadosCompleta.Columns["exp_saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvAfiliadosCompleta.Columns["exp_saldo"].DefaultCellStyle.Format = "#,##0.00";


            dgvAfiliadosCompleta.Columns["idRuta"].HeaderText = "Ruta";
            dgvAfiliadosCompleta.Columns["idRuta"].Width = 50;
            dgvAfiliadosCompleta.Columns["idRuta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvAfiliadosCompleta.Columns["exp_status"].HeaderText = "Status";
            dgvAfiliadosCompleta.Columns["exp_status"].Width = 50;
            dgvAfiliadosCompleta.Columns["exp_status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvAfiliadosCompleta.Columns["exp_email"].HeaderText = "Email";
            dgvAfiliadosCompleta.Columns["exp_email"].Width = 200;

            dgvAfiliadosCompleta.Columns["exp_celular"].HeaderText = "Celular";
            dgvAfiliadosCompleta.Columns["exp_celular"].Width = 150;
            dgvAfiliadosCompleta.Columns["exp_celular"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvAfiliadosCompleta.Columns["exp_telefono"].HeaderText = "Telefono";
            dgvAfiliadosCompleta.Columns["exp_telefono"].Width = 100;
            dgvAfiliadosCompleta.Columns["exp_telefono"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvAfiliadosCompleta.Columns["exp_cedula"].HeaderText = "Cedula";
            dgvAfiliadosCompleta.Columns["exp_cedula"].Width = 100;
            dgvAfiliadosCompleta.Columns["exp_cedula"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvAfiliadosCompleta.Columns["exp_provincia"].HeaderText = "Provincia";
            dgvAfiliadosCompleta.Columns["exp_provincia"].Width = 100;

            dgvAfiliadosCompleta.Columns["exp_direccion"].HeaderText = "Direccion";
            dgvAfiliadosCompleta.Columns["exp_direccion"].Width = 300;

            dgvAfiliadosCompleta.Columns["exp_fec_utlimo_abono"].HeaderText = "Fecha utlimo abono";
            dgvAfiliadosCompleta.Columns["exp_fec_utlimo_abono"].Width = 150;
            dgvAfiliadosCompleta.Columns["exp_fec_utlimo_abono"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvAfiliadosCompleta.Columns["exp_comentarios"].HeaderText = "Comentarios";
            dgvAfiliadosCompleta.Columns["exp_comentarios"].Width = 350;
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
                            idServicio = serv.idServicio,
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

        private void btnAfiliadosBuscar_Click(object sender, EventArgs e)
        {
            tablaAfiliados();
        }

        private void dgvAfiliadosCompleta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if ((e.ColumnIndex == 0) || (e.ColumnIndex == 1))// Valida que se le dio clik a la celda en posición 0 (Editar)
                {
                    int col = e.ColumnIndex;
                    int id = Convert.ToInt32(dgvAfiliadosCompleta.Rows[e.RowIndex].Cells["cod_expediente"].Value);
                    RegistroAfiliados ra = new RegistroAfiliados(id, col, usuario);
                    ra.ShowDialog();
                    tablaAfiliados();
                }
            }
            catch (Exception ex) { }
        }

        private void CtrlUsAfiliados_Load(object sender, EventArgs e)
        {
            try
            {
                // Combox RUTA
                var combo = _context.mst_Ruta.ToList();
                combo.Add(new mst_Ruta() { idRuta = 0, ruta_nombre = "Todas" });
                List<mst_Ruta> comboOrden = combo.OrderBy(x => x.idRuta).ToList();

                cbAfiliadosRuta.DataSource = comboOrden;
                //campo que vera el usuario
                cbAfiliadosRuta.DisplayMember = "ruta_nombre";
                //campo que es el valor real
                cbAfiliadosRuta.ValueMember = "idRuta";

                dgvAfiliadosCompleta.DataSource = _context.mst_Expediente.ToList();
                editarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos \n Por favor inténtelo de nuevo \n" + ex, "Error en base de datos ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAfiliadosID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
