using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace PryFakiani_IEFI
{
    public partial class FrmPrincipal : Form
    {
        //  Cronómetro para medir el tiempo de uso del sistema
        Stopwatch cronometro = new Stopwatch();

        //  Usuario logueado, recibido desde el formulario de login
        ClsUsuarios usuario;

        //  Constructor que recibe el usuario logueado
        public FrmPrincipal(ClsUsuarios usuarioRecibido)
        {
            InitializeComponent();
            usuario = usuarioRecibido;

         //  cerrar para registrar auditoría
            this.FormClosing += FrmPrincipal_FormClosing;
        }

       
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            
            lblIngreso.Text = "Ingreso: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            lblBienvenida.Text = $"Bienvenido, {usuario.Login} (Nivel {usuario.Nivel})";

            
            cronometro.Start();

            // Si el usuario no es administrador, ocultar menú de auditoría
            if (usuario.Nivel != 1)
            {
                aUDITORIAToolStripMenuItem.Visible = false;
            }
        }

        
        private void aUDITORIAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmAuditoria auditoria = new FrmAuditoria(usuario.Login);
            auditoria.ShowDialog();
        }

       
        private void aUDITORIAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuarios usuarios = new FrmUsuarios(usuario); // Se pasa el usuario actual
            usuarios.ShowDialog();
        }

        
        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            cronometro.Stop();

            
            ClsAuditoria nueva = new ClsAuditoria
            {
                Fecha = DateTime.Now,
                TiempoDeUso = (int)cronometro.Elapsed.TotalSeconds, // Tiempo en segundos
                IdUsuarios = usuario.IdUsuarios,
                NombreUsuario = $"{usuario.Nombre} {usuario.Apellido}"
            };

           
            ClsAuditoriaDatos auditor = new ClsAuditoriaDatos();
            auditor.RegistrarAuditoria(nueva);
        }
    }
}
