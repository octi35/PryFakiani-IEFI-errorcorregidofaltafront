using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace PryFakiani_IEFI
{
    public partial class FrmAuditoria : Form
    {
        private readonly ClsAuditoriaDatos auditoriaDatos = new ClsAuditoriaDatos();
        private DataTable tablaAuditoria;
        private Stopwatch cronometro = new Stopwatch();
        private Timer timerUso = new Timer();
        private string loginUsuario;

        private ClsAuditoria auditoriaActual = new ClsAuditoria();
        private int segundosTotales = 0;

        public FrmAuditoria(string login)
        {
            InitializeComponent();
            this.FormClosing += FrmAuditoria_FormClosing;

            timerUso.Interval = 1000;
            timerUso.Tick += TimerUso_Tick;
            loginUsuario = login;
        }

        private void FrmAuditoria_Load(object sender, EventArgs e)
        {
            CargarDatos();
            lblUsuarioAuditoria.Text = $"Usuario: {loginUsuario}";

            var clsUsuarioDatos = new clsUsuariosDatos();
            var usuario = clsUsuarioDatos.ObtenerUsuarioPorLogin(loginUsuario);

            auditoriaActual = new ClsAuditoria
            {
                Fecha = DateTime.Now,
                TiempoDeUso = 0,
                IdUsuarios = usuario.IdUsuarios,
                NombreUsuario = $"{usuario.Nombre} {usuario.Apellido}"
            };

            // Guardamos el ID del registro insertado
            auditoriaActual.IdAuditoria = auditoriaDatos.RegistrarAuditoria(auditoriaActual);

            cronometro.Start();
            timerUso.Start();
        }

        private void TimerUso_Tick(object sender, EventArgs e)
        {
            segundosTotales++;
            TimeSpan tiempo = TimeSpan.FromSeconds(segundosTotales);
            lblTiempodeUso.Text = $"Tiempo de uso: {tiempo:hh\\:mm\\:ss}";
        }

        private void FrmAuditoria_FormClosing(object sender, FormClosingEventArgs e)
        {
            cronometro.Stop();
            timerUso.Stop();

            auditoriaDatos.ActualizarTiempoDeUso(auditoriaActual.IdAuditoria, segundosTotales);
        }

        private void CargarDatos()
        {
            try
            {
                tablaAuditoria = auditoriaDatos.ObtenerAuditoriasConUsuarios();
                AplicarFiltros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar auditorías: " + ex.Message);
            }
        }

        private void AplicarFiltros()
        {
            if (tablaAuditoria == null) return;

            string filtro = "";

            // Filtro por ID de auditoría
            if (chkfiltrarAuditoriaId.Checked && !string.IsNullOrWhiteSpace(txtAuditoriaId.Text))
                filtro += $"Convert(IdAuditoria, 'System.String') LIKE '%{txtAuditoriaId.Text.Trim()}%'";

            // Filtro por nombre de usuario
            if (chkUsuarioNombre.Checked && !string.IsNullOrWhiteSpace(txtUsuarioNombre.Text))
            {
                if (!string.IsNullOrEmpty(filtro)) filtro += " AND ";
                filtro += $"NombreUsuario LIKE '%{txtUsuarioNombre.Text.Trim()}%'";
            }

            // Filtro por fecha (AGREGÁ ESTO)
            if (chkFiltroFecha.Checked)
            {
                string desde = dateDesde.Value.ToString("yyyy-MM-dd");
                string hasta = dateHasta.Value.ToString("yyyy-MM-dd");

                if (!string.IsNullOrEmpty(filtro)) filtro += " AND ";
                filtro += $"Fecha >= '{desde}' AND Fecha <= '{hasta}'";
            }

            // Aplicar al DataView
            DataView vista = tablaAuditoria.DefaultView;
            vista.RowFilter = filtro;

            string orden = radioASC.Checked ? "IdAuditoria ASC" : "IdAuditoria DESC";
            vista.Sort = orden;

            dgvUsuarios.DataSource = vista;
        }



        private void btnDescargar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.");
                return;
            }

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Archivo de texto (*.txt)|*.txt";
                saveDialog.FileName = "Auditoria_Exportada.txt";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(saveDialog.FileName))
                        {
                            for (int i = 0; i < dgvUsuarios.Columns.Count; i++)
                            {
                                writer.Write(dgvUsuarios.Columns[i].HeaderText);
                                if (i < dgvUsuarios.Columns.Count - 1) writer.Write("\t");
                            }
                            writer.WriteLine();

                            foreach (DataGridViewRow fila in dgvUsuarios.Rows)
                            {
                                if (!fila.IsNewRow)
                                {
                                    for (int i = 0; i < dgvUsuarios.Columns.Count; i++)
                                    {
                                        var valor = fila.Cells[i].Value?.ToString().Replace("\t", " ");
                                        writer.Write(valor);
                                        if (i < dgvUsuarios.Columns.Count - 1) writer.Write("\t");
                                    }
                                    writer.WriteLine();
                                }
                            }
                        }

                        MessageBox.Show("Datos exportados correctamente.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al exportar: " + ex.Message);
                    }
                }
            }
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.");
                return;
            }

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Archivo de Excel (*.xlsx)|*.xlsx";
                saveDialog.FileName = "AuditoriaExportada.xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Auditorias");

                            // Escribir encabezados
                            for (int i = 0; i < dgvUsuarios.Columns.Count; i++)
                            {
                                worksheet.Cell(1, i + 1).Value = dgvUsuarios.Columns[i].HeaderText;
                            }

                            // Escribir datos fila por fila
                            for (int i = 0; i < dgvUsuarios.Rows.Count; i++)
                            {
                                for (int j = 0; j < dgvUsuarios.Columns.Count; j++)
                                {
                                    worksheet.Cell(i + 2, j + 1).Value = dgvUsuarios.Rows[i].Cells[j].Value?.ToString();
                                }
                            }

                            workbook.SaveAs(saveDialog.FileName);
                        }

                        MessageBox.Show("Exportación a Excel exitosa.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al exportar a Excel: " + ex.Message);
                    }
                }
            }
        }

        private void radioASC_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void RadioDesc_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void chkUsuarioNombre_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void txtUsuarioNombre_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void chkfiltrarAuditoriaId_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void txtAuditoriaId_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void chkFiltroFecha_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void dateDesde_ValueChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void dateHasta_ValueChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }


        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
