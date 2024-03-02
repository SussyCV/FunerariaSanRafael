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

namespace FunerariaSanRafael.UI
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

        ApplicationDbContext _context = new ApplicationDbContext();

        public void iniciaSesion()
        {

            try
            {
                var usuario = _context.mst_User.Find(txtLoginUsuario.Text);

                if (usuario == null)
                {

                    MessageBox.Show("Usuario incorrecto");
                    return;

                }
                else if (txtLoginContraseña.Text == usuario.user_Password)
                {
                    frmMenu mn = new frmMenu(usuario);
                    mn.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido iniciar su sesión \n Por favor inténtelo de nuevo \n" + ex, "Error en inicio de sesión " ,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnLoginIniciaSesion_Click(object sender, EventArgs e)
        {
            iniciaSesion();
        }

        private void txtLoginContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                iniciaSesion();
            }
        }

    }
}
