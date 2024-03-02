using FunerariaSanRafael.Models;
using FunerariaSanRafael.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunerariaSanRafael.UI
{
    public partial class RegistroRutas : Form
    {
        mst_User usuario = new mst_User();
        bool nuevo;

        public RegistroRutas(int id, bool nuevo, mst_User usuario)
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
                var rutaWhere = _context.mst_Ruta.Where(x => x.idRuta == id).FirstOrDefault();

                txtRutaNombre.Text = rutaWhere.ruta_nombre;
                txtRutasId.Text = rutaWhere.idRuta.ToString();
                txtRutasId.Enabled = false;
                txtRutasId.BackColor = Color.White;
                txtRutaTelefono.Text = rutaWhere.ruta_Telefono;
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
                var ruta = _context.mst_Ruta.Find(Convert.ToInt32(txtRutasId.Text));
                if (ruta == null)
                {
                    MessageBox.Show("No se ha actualizado la información", "Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    ruta.ruta_nombre = txtRutaNombre.Text;
                    ruta.ruta_Telefono = txtRutaTelefono.Text;
                    ruta.updatedAt = DateTime.Now;
                    ruta.updatedBy = usuario.idUser;

                    _context.mst_Ruta.Update(ruta);
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
                if ((txtRutaNombre.Text != null) && (txtRutasId.Text != null))
                {

                    mst_Ruta ruta = new mst_Ruta()
                    {
                        idRuta = Convert.ToInt32(txtRutasId.Text),
                        ruta_nombre = txtRutaNombre.Text,
                        ruta_Telefono = txtRutaTelefono.Text,
                        createdAt = DateTime.Now,
                        createdBy = usuario.idUser,
                    };

                    _context.mst_Ruta.Add(ruta);
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

        private void btnRutaSalir_Click(object sender, EventArgs e)
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

        private void btnRutaGuardar_Click(object sender, EventArgs e)
        {
            if (nuevo)
            {
                Crear();
                txtRutasId.Text = "";
                txtRutaNombre.Text = "";
                txtRutaTelefono.Text = "";
            }
            else
            {
                Actualizar();
            }
        }

        private void txtRutasId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtRutaTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
