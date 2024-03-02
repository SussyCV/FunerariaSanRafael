using FunerariaSanRafael.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FunerariaSanRafael.UI
{
    public partial class RegistroServicios : Form
    {

        mst_User usuario = new mst_User();
        bool nuevo;

        public RegistroServicios(int id, bool nuevo, mst_User usuario)
        {
            InitializeComponent();

            if (!nuevo)
            {
                editaDatos(id);
            }

            this.usuario = usuario;
            this.nuevo = nuevo;

        }

        ApplicationDbContext _context = new ApplicationDbContext();
        private void editaDatos(int id)
        {
            try
            {
                var servWhere = _context.mst_Servicio.Where(x => x.idServicio == id).FirstOrDefault();

                txtServicioDescripcion.Text = servWhere.serv_desc;
                txtServicioId.Text = servWhere.idServicio.ToString();
                txtServicioId.Enabled = false;
                txtServicioId.BackColor = Color.White;
                txtServicioCosto.Text = servWhere.serv_costo.ToString();
                cbServicioTipo.Text = servWhere.serv_tipo;
                cbServicioTipoCosto.Text = servWhere.serv_tipo_costo;
                txtServicioCtaCont.Text = servWhere.serv_cuenta_contable;
                cbServicioStatus.Text = servWhere.serv_status.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos \n Por favor inténtelo de nuevo \n" + ex, "Error de conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Actualizar()
        {
            try
            {
                var servicio = _context.mst_Servicio.Find(Convert.ToInt32(txtServicioId.Text));
                if (servicio == null)
                {
                    MessageBox.Show("No se ha actualizado la información", "Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    servicio.serv_desc = txtServicioDescripcion.Text;
                    servicio.serv_costo = decimal.Parse(txtServicioCosto.Text);
                    servicio.serv_tipo = cbServicioTipo.Text;
                    servicio.serv_tipo_costo = cbServicioTipoCosto.Text;
                    servicio.serv_cuenta_contable = txtServicioCtaCont.Text;
                    servicio.serv_status = cbServicioStatus.Text.ToCharArray()[0];
                    servicio.updatedAt = DateTime.Now;
                    servicio.updatedBy = usuario.idUser;

                    _context.mst_Servicio.Update(servicio);
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

        public void Crear()
        {
            try
            {
                if ((txtServicioDescripcion.Text != null) && (txtServicioId.Text != null) && (txtServicioCosto.Text != null) && (txtServicioCtaCont.Text != null))
                {

                    mst_Servicio servicio = new mst_Servicio()
                    {
                        idServicio = 0,
                        serv_desc = txtServicioDescripcion.Text,
                        serv_costo = decimal.Parse(txtServicioCosto.Text),
                        serv_tipo = cbServicioTipo.Text,
                        serv_tipo_costo = cbServicioTipoCosto.Text,
                        serv_cuenta_contable = txtServicioCtaCont.Text,
                        serv_status = cbServicioStatus.Text.ToCharArray()[0],
                        createdAt = DateTime.Now,
                        createdBy = usuario.idUser,
                    };

                    _context.mst_Servicio.Add(servicio);
                    _context.SaveChanges();
                    MessageBox.Show("Registro Actualizado correctamente", "Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha guardado la información\n Verifique que los datos estén correctos y el Id no esté en uso. \n" + ex, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnServicioSalir_Click(object sender, EventArgs e)
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

        private void btnServicioGuardar_Click(object sender, EventArgs e)
        {
            if (nuevo)
            {
                Crear();
                txtServicioDescripcion.Text = "";
                txtServicioId.Text = "";
                txtServicioCosto.Text = "";
                txtServicioCtaCont.Text = "";
            }
            else
            {
                Actualizar();
            }
        }

        private void txtServicioCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            char keyPressed = e.KeyChar;

            if (!char.IsDigit(keyPressed) && keyPressed != '.' && keyPressed != '-' && keyPressed != '\b')
            {
                e.Handled = true;
            }
            else if (keyPressed == '.' && txtServicioCosto.Text.Contains('.'))
            {
                e.Handled = true;
            }
            else if (keyPressed == '-' && txtServicioCosto.Text.Contains('-'))
            {
                e.Handled = true;
            }
        }

        private void txtServicioCtaCont_KeyPress(object sender, KeyPressEventArgs e)
        {
            char keyPressed = e.KeyChar;

            if (!char.IsDigit(keyPressed) && keyPressed != '.' && keyPressed != '-' && keyPressed != '\b')
            {
                e.Handled = true;
            }
            else if (keyPressed == '.' && txtServicioCtaCont.Text.Contains('.'))
            {
                e.Handled = true;
            }
            else if (keyPressed == '-' && txtServicioCtaCont.Text.Contains('-'))
            {
                e.Handled = true;
            }
        }

        private void txtServicioCosto_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
