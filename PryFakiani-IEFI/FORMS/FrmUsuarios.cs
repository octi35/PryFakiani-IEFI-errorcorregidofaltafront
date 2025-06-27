using System;
using System.Data;
using System.Windows.Forms;

namespace PryFakiani_IEFI
{
    public partial class FrmUsuarios : Form
    {
        private readonly clsUsuariosDatos usuariosDatos = new clsUsuariosDatos();
        private ClsUsuarios usuarioSeleccionado = null;
        private ClsUsuarios usuarioActual;

        public FrmUsuarios(ClsUsuarios usuarioLogueado)
        {
            InitializeComponent();
            usuarioActual = usuarioLogueado;
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            CargarAreas();
            ConfigurarStatusStrip();
            ControlarAccesoPorNivel();
            dataUsuarios.CellClick += dataUsuarios_CellClick;
        }

        private void CargarUsuarios()
        {
            dataUsuarios.DataSource = usuariosDatos.ObtenerUsuarios();
        }

        private void CargarAreas()
        {
            cmbArea.Items.Clear();
            cmbArea.Items.AddRange(new string[]
            {
                "Recursos Humanos",
                "Finanzas y Control",
                "Producción",
                "Ventas y Marketing"
            });
        }

        private void ConfigurarStatusStrip()
        {
            lblNombreUsuario.Text = $"Usuario: {usuarioActual.Nombre} {usuarioActual.Apellido}";
            lblNiveldeUsuario.Text = $"Nivel: {(usuarioActual.Nivel == 1 ? "Administrador,1" : "Usuario común,0")}";
        }

        private void ControlarAccesoPorNivel()
        {
            bool esAdmin = usuarioActual.Nivel == 1;
            btnNuevo.Enabled = esAdmin;
            btnModificar.Enabled = esAdmin;
            btnEliminar.Enabled = esAdmin;
            btnActualizar.Enabled = esAdmin;
        }

        private void LimpiarCampos()
        {
            txtLogin.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtContraseña.Clear();
            txtCelular.Clear();
            cmbArea.SelectedIndex = -1;
            dataNacimiento.Value = DateTime.Now;
            txtDNI.Clear();
            usuarioSeleccionado = null;
        }

        private bool ValidarCamposObligatorios()
        {
            if (string.IsNullOrWhiteSpace(txtLogin.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDNI.Text) ||
                string.IsNullOrWhiteSpace(txtContraseña.Text) ||
                string.IsNullOrWhiteSpace(txtCelular.Text) ||
                cmbArea.SelectedIndex == -1)
            {
                MessageBox.Show("Debe completar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool LoginExiste(string login)
        {
            DataTable dt = usuariosDatos.BuscarUsuarioPorLogin(login);
            return dt.Rows.Count > 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string textoBusqueda = txtBusqueda.Text.Trim();
            dataUsuarios.DataSource = usuariosDatos.BuscarUsuarioPorLogin(textoBusqueda);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposObligatorios()) return;

            string login = txtLogin.Text.Trim();
            if (LoginExiste(login))
            {
                MessageBox.Show("El login ya existe. Ingrese uno diferente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ClsUsuarios nuevo = new ClsUsuarios
            {
                Login = login,
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Descripcion = "Registrado desde el sistema",
                FechaRegistro = DateTime.Now,
                area = cmbArea.Text,
                Contraseña = txtContraseña.Text.Trim(),
                FechaNacimiento = dataNacimiento.Value,
                Celular = txtCelular.Text.Trim(),
                Nivel = 0,
                DNI = txtDNI.Text.Trim() // Asegúrate de que txtDNI esté definido en tu formulario
            };

            if (usuariosDatos.AgregarUsuario(nuevo))
            {
                MessageBox.Show("Usuario agregado correctamente");
                CargarUsuarios();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al agregar el usuario");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (usuarioSeleccionado == null)
            {
                MessageBox.Show("Seleccione un usuario para actualizar.");
                return;
            }

            if (!ValidarCamposObligatorios()) return;

            usuarioSeleccionado.Login = txtLogin.Text.Trim();
            usuarioSeleccionado.Nombre = txtNombre.Text.Trim();
            usuarioSeleccionado.Apellido = txtApellido.Text.Trim();
            usuarioSeleccionado.area = cmbArea.Text;
            usuarioSeleccionado.Contraseña = txtContraseña.Text.Trim();
            usuarioSeleccionado.FechaNacimiento = dataNacimiento.Value;
            usuarioSeleccionado.DNI = txtDNI.Text.Trim(); // Asegúrate de que txtDNI esté definido en tu formulario
            usuarioSeleccionado.Celular = txtCelular.Text.Trim();

            if (usuariosDatos.ActualizarUsuario(usuarioSeleccionado))
            {
                MessageBox.Show("Usuario actualizado correctamente.");
                CargarUsuarios();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al actualizar el usuario.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (usuarioSeleccionado == null)
            {
                MessageBox.Show("Seleccione un usuario para eliminar.");
                return;
            }

            if (usuariosDatos.EliminarUsuario(usuarioSeleccionado.IdUsuarios))
            {
                MessageBox.Show("Usuario eliminado correctamente.");
                CargarUsuarios();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al eliminar el usuario.");
            }
        }

        private void dataUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataUsuarios.Rows[e.RowIndex];

                usuarioSeleccionado = new ClsUsuarios
                {
                    IdUsuarios = Convert.ToInt32(fila.Cells["IdUsuarios"].Value),
                    Login = fila.Cells["Login"].Value?.ToString(),
                    Nombre = fila.Cells["Nombre"].Value?.ToString(),
                    Apellido = fila.Cells["Apellido"].Value?.ToString(),
                    Descripcion = fila.Cells["Descripcion"].Value?.ToString(),
                    FechaRegistro = Convert.ToDateTime(fila.Cells["FechaRegistro"].Value),
                    area = fila.Cells["Area"].Value?.ToString(),
                    Contraseña = fila.Cells["Contraseña"].Value?.ToString(),
                    FechaNacimiento = Convert.ToDateTime(fila.Cells["FechaNacimiento"].Value),
                    Celular = fila.Cells["Celular"].Value?.ToString(),
                    Nivel = Convert.ToInt32(fila.Cells["Nivel"].Value)
                };

                txtLogin.Text = usuarioSeleccionado.Login;
                txtNombre.Text = usuarioSeleccionado.Nombre;
                txtApellido.Text = usuarioSeleccionado.Apellido;
                cmbArea.Text = usuarioSeleccionado.area;
                txtContraseña.Text = usuarioSeleccionado.Contraseña;
                dataNacimiento.Value = usuarioSeleccionado.FechaNacimiento;
                txtDNI.Text = usuarioSeleccionado.DNI; // Asegúrate de que txtDNI esté definido en tu formulario
                txtCelular.Text = usuarioSeleccionado.Celular;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            btnActualizar.PerformClick();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
