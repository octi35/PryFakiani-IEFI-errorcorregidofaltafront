using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace PryFakiani_IEFI
{


    public partial class FrmPrincipal : Form
    {

        string usuarioActual;
        int nivelUsuario;

        Stopwatch cronometro = new Stopwatch();
        ClsUsuarios usuario;





        public FrmPrincipal(ClsUsuarios usuarioRecibido)
        {
            InitializeComponent();
            usuario = usuarioRecibido;
            this.FormClosing += FrmPrincipal_FormClosing;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            lblIngreso.Text = "Ingreso: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            lblBienvenida.Text = $"Bienvenido, {usuario.Login} (Nivel {usuario.Nivel})";


            cronometro.Start();

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
            FrmUsuarios usuarios = new FrmUsuarios(usuario); // ✔️ Pasás el usuario logueado
            usuarios.ShowDialog();

            
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            cronometro.Stop();

            ClsAuditoriaDatos auditor = new ClsAuditoriaDatos();

            ClsAuditoria nueva = new ClsAuditoria
            {
                Fecha = DateTime.Now,
                TiempoDeUso = (int)cronometro.Elapsed.TotalSeconds,
                IdUsuarios = usuario.IdUsuarios,
                NombreUsuario = $"{usuario.Nombre} {usuario.Apellido}"
            };

            auditor.RegistrarAuditoria(nueva);
        }


    }
}
