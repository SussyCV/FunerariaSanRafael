using FunerariaSanRafael.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunerariaSanRafael.UI
{
    public partial class CtrlUsRutas : UserControl
    {
        mst_User usuario = new mst_User();
        ToolTip toolTip1 = new ToolTip();
        public CtrlUsRutas(mst_User usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        ApplicationDbContext _context = new ApplicationDbContext();

        public void tablaRutas()
        {
            try
            {
                
                ApplicationDbContext _context2 = new ApplicationDbContext();

                var listaRutas = _context2.mst_Ruta.ToList();

                if (!string.IsNullOrEmpty(txtRutasId.Text))
                {
                     listaRutas = listaRutas.Where(x => x.idRuta.ToString().Contains(txtRutasId.Text)).ToList();
                }

                if (!string.IsNullOrEmpty(txtRutasNombre.Text))
                {
                    listaRutas = listaRutas.Where(x => x.ruta_nombre.ToLower().Contains(txtRutasNombre.Text.ToLower())).ToList();
                }

                dgvRutasCompleta.DataSource = listaRutas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos \n Por favor inténtelo de nuevo \n" + ex, "Error en base de datos ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void tablaServicios()
        {
            try
            {

                ApplicationDbContext _context2 = new ApplicationDbContext();

                var listaServicios = _context2.mst_Servicio.ToList();

                if (!string.IsNullOrEmpty(txtServiciosNombre.Text))
                {
                    listaServicios = listaServicios.Where(x => x.serv_desc.ToLower().Contains(txtServiciosNombre.Text)).ToList();
                }

                dgvServiciosCompleta.DataSource = listaServicios;
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
                var listaActualiza = _context.mst_Ruta.ToList();

                if (!string.IsNullOrEmpty(txtRutasId.Text))
                {
                    listaActualiza = listaActualiza.Where(x => x.idRuta == Convert.ToInt32(txtRutasId.Text)).ToList();
                }

                if (!string.IsNullOrEmpty(txtRutasNombre.Text))
                {
                    listaActualiza = listaActualiza.Where(x => x.ruta_nombre.ToLower().Contains(txtRutasNombre.Text.ToLower())).ToList();
                }
                dgvRutasCompleta.DataSource = listaActualiza;


                var listaActualizaServicios = _context.mst_Servicio.ToList();

                if (!string.IsNullOrEmpty(txtServiciosNombre.Text))
                {
                    listaActualizaServicios = listaActualizaServicios.Where(x => x.serv_desc.ToLower().Contains(txtServiciosNombre.Text)).ToList();
                }

                dgvServiciosCompleta.DataSource = listaActualizaServicios;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos \n Por favor inténtelo de nuevo \n" + ex, "Error en base de datos ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void editarColumnasRutas()
        {
            dgvRutasCompleta.RowHeadersVisible = false;

            dgvRutasCompleta.Columns["createdAt"].Visible = false;
            dgvRutasCompleta.Columns["createdBy"].Visible = false;
            dgvRutasCompleta.Columns["updatedAt"].Visible = false;
            dgvRutasCompleta.Columns["updatedBy"].Visible = false;

            dgvRutasCompleta.Columns["ruta_nombre"].HeaderText = "Nombre";
            dgvRutasCompleta.Columns["ruta_nombre"].Width = 300;

            dgvRutasCompleta.Columns["idRuta"].HeaderText = "Id";
            dgvRutasCompleta.Columns["idRuta"].Width = 90;
            dgvRutasCompleta.Columns["idRuta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvRutasCompleta.Columns["ruta_Telefono"].HeaderText = "Telefono";
            dgvRutasCompleta.Columns["ruta_Telefono"].Width = 100;
            dgvRutasCompleta.Columns["ruta_Telefono"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvRutasCompleta.Columns["Eliminar"].DisplayIndex = 4;
        }

        public void editarColumnasServicios()
        {
            dgvServiciosCompleta.RowHeadersVisible = false;

            dgvServiciosCompleta.Columns["createdAt"].Visible = false;
            dgvServiciosCompleta.Columns["createdBy"].Visible = false;
            dgvServiciosCompleta.Columns["updatedAt"].Visible = false;
            dgvServiciosCompleta.Columns["updatedBy"].Visible = false;

            dgvServiciosCompleta.Columns["idServicio"].HeaderText = "Id";
            dgvServiciosCompleta.Columns["idServicio"].Width = 50;
            dgvServiciosCompleta.Columns["idServicio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvServiciosCompleta.Columns["serv_desc"].HeaderText = "Descripción";
            dgvServiciosCompleta.Columns["serv_desc"].Width = 180;

            dgvServiciosCompleta.Columns["serv_costo"].HeaderText = "Costo";
            dgvServiciosCompleta.Columns["serv_costo"].Width = 100;
            dgvServiciosCompleta.Columns["serv_costo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvServiciosCompleta.Columns["serv_tipo"].HeaderText = "Tipo";
            dgvServiciosCompleta.Columns["serv_tipo"].Width = 60;
            dgvServiciosCompleta.Columns["serv_tipo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvServiciosCompleta.Columns["serv_tipo_costo"].HeaderText = "Tipo costo";
            dgvServiciosCompleta.Columns["serv_tipo_costo"].Width = 90;
            dgvServiciosCompleta.Columns["serv_tipo_costo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvServiciosCompleta.Columns["serv_cuenta_contable"].HeaderText = "Cuenta contable";
            dgvServiciosCompleta.Columns["serv_cuenta_contable"].Width = 150;
            dgvServiciosCompleta.Columns["serv_cuenta_contable"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvServiciosCompleta.Columns["serv_status"].HeaderText = "Status";
            dgvServiciosCompleta.Columns["serv_status"].Width = 80;
            dgvServiciosCompleta.Columns["serv_status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvServiciosCompleta.Columns["Eliminar1"].DisplayIndex = 8;
        }

        private void btnRutasBuscar_Click(object sender, EventArgs e)
        {
            tablaRutas();
            tablaServicios();
        }

        private void dgvRutasCompleta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if ((e.ColumnIndex == 0) )// Valida que se le dio clik a la celda en posición 0 (Editar)
                {
                    int col = e.ColumnIndex;
                    bool nuevo = false;
                    int id = Convert.ToInt32(dgvRutasCompleta.Rows[e.RowIndex].Cells["idRuta"].Value);
                    RegistroRutas rr = new RegistroRutas(id, nuevo, usuario);
                    rr.ShowDialog();
                    
                }
                if (e.ColumnIndex == 1) // Valida que se le dio clik a la celda en posición 1 (Eliminar)
                {

                    if (MessageBox.Show("¿Desea eliminar la ruta?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)== DialogResult.Yes) 
                    {
                        int id = Convert.ToInt32(dgvRutasCompleta.Rows[e.RowIndex].Cells["idRuta"].Value);
                        var eliminar = _context.mst_Ruta.Where(x => x.idRuta == id).FirstOrDefault();

                        _context.mst_Ruta.Remove(eliminar);
                        _context.SaveChanges();
                        MessageBox.Show("Registro eliminado correctamente", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }
            }
            catch (Exception ex) { };
            tablaRutas();
            tablaServicios();
        }

        private void CtrlUsRutas_Load(object sender, EventArgs e)
        {
            try
            {
                dgvRutasCompleta.DataSource = _context.mst_Ruta.ToList();
                editarColumnasRutas();
                dgvServiciosCompleta.DataSource = _context.mst_Servicio.ToList();
                editarColumnasServicios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos \n Por favor inténtelo de nuevo \n" + ex, "Error en base de datos ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtRutasId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnRutasNuevo_Click(object sender, EventArgs e)
        {
            bool nuevo = true;
            int id = 0;
            RegistroRutas rr = new RegistroRutas(id, nuevo, usuario);
            rr.ShowDialog();
            actualizaTabla();
        }

        private void dgvServiciosCompleta_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            string toolTipText = "P = Principal*\nA= Administrativo*\nS = Secundario\nX =Descuento sobre el principal\nZ = Descuento sobre el administrativo\n\n* Los servicios de tipo P y A serán agregados a todos los expedientes automáticamente.";
            string toolTipText2 = "M = Se aplica la cantidad indicada\n% = Se aplica el porcentaje indicado sobre los servicios principales";

            if (e.RowIndex >= 0 && e.ColumnIndex == 5)
            {
                DataGridViewCell cell = dgvServiciosCompleta.Rows[e.RowIndex].Cells[e.ColumnIndex];
                
                if (!string.IsNullOrEmpty(toolTipText))
                {
                    toolTip1.SetToolTip(dgvServiciosCompleta, toolTipText);
                }
                else
                {
                    toolTip1.Hide(dgvServiciosCompleta);
                }
            }

            if (e.RowIndex >= 0 && e.ColumnIndex == 6)
            {
                DataGridViewCell cell = dgvServiciosCompleta.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (!string.IsNullOrEmpty(toolTipText2))
                {
                    toolTip1.SetToolTip(dgvServiciosCompleta, toolTipText2);
                }
                else
                {
                    toolTip1.Hide(dgvServiciosCompleta);
                }
            }

        }

        private void btnServiciosNuevo_Click(object sender, EventArgs e)
        {
            bool nuevo = true;
            int id = 0;
            RegistroServicios rs = new RegistroServicios(id, nuevo, usuario);
            rs.ShowDialog();
            actualizaTabla();
        }

        private void dgvServiciosCompleta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if ((e.ColumnIndex == 0))// Valida que se le dio clik a la celda en posición 0 (Editar)
                {
                    int col = e.ColumnIndex;
                    bool nuevo = false;
                    int id = Convert.ToInt32(dgvServiciosCompleta.Rows[e.RowIndex].Cells["idServicio"].Value);
                    RegistroServicios rs = new RegistroServicios(id, nuevo, usuario);
                    rs.ShowDialog();

                }
                if (e.ColumnIndex == 1) // Valida que se le dio clik a la celda en posición 1 (Eliminar)
                {

                    if (MessageBox.Show("¿Desea eliminar el servicio?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(dgvServiciosCompleta.Rows[e.RowIndex].Cells["idServicio"].Value);
                        var eliminar = _context.mst_Servicio.Where(x => x.idServicio == id).FirstOrDefault();

                        _context.mst_Servicio.Remove(eliminar);
                        _context.SaveChanges();
                        MessageBox.Show("Servicio eliminado correctamente", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception ex) { };
            tablaRutas();
            tablaServicios();
        }
    }
}
