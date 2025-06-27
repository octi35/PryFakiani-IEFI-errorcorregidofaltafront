using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PryFakiani_IEFI
{
    public partial class formInicio : Form
    {

        clsUsuariosDatos objUsuario;
        public formInicio()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            objUsuario = new clsUsuariosDatos();



        }
        private void btnIniciar_Click_1(object sender, EventArgs e)
        {
            string login = txtUsuario.Text.Trim();
            string password = txtClave.Text.Trim();

            if (login == "" || password == "")
            {
                MessageBox.Show("Debe ingresar el usuario y la contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsUsuariosDatos usuarioDatos = new clsUsuariosDatos();
            bool loginExitoso = usuarioDatos.ValidarLogin(login, password);

            if (loginExitoso)
            {
                MessageBox.Show("Inicio de sesión exitoso", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();

                // Obtener el objeto completo del usuario
                ClsUsuarios datosUsuario = usuarioDatos.ObtenerUsuarioPorLogin(login);

                // Pasar el objeto completo a FrmPrincipal
                FrmPrincipal principal = new FrmPrincipal(datosUsuario);
                principal.ShowDialog();

                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
