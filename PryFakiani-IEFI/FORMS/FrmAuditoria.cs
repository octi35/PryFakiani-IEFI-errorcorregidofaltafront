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
        //  Clase de acceso a datos de auditoría 
        private readonly ClsAuditoriaDatos auditoriaDatos = new ClsAuditoriaDatos();

        //  Tabla para almacenar los resultados de la auditoría
        private DataTable tablaAuditoria;

        // arranca logica para el tiempo de uso 
        //  Cronómetro para medir tiempo de uso
        private Stopwatch cronometro = new Stopwatch();

        //  Timer que actualiza el cronómetro cada segundo
        private Timer timerUso = new Timer();

       
        private string loginUsuario;

        //  Objeto con los datos actuales de auditoría
        private ClsAuditoria auditoriaActual = new ClsAuditoria();

       
        private int segundosTotales = 0;

        //  Constructor del formulario, recibe el login del usuario
        public FrmAuditoria(string login)
        {
            InitializeComponent();
            this.FormClosing += FrmAuditoria_FormClosing;

            timerUso.Interval = 1000; // 1 segundo
            timerUso.Tick += TimerUso_Tick;

            loginUsuario = login;
        }

       
        private void FrmAuditoria_Load(object sender, EventArgs e)
        {
            CargarDatos(); 

            lblUsuarioAuditoria.Text = $"Usuario: {loginUsuario}";

            var clsUsuarioDatos = new clsUsuariosDatos();
            var usuario = clsUsuarioDatos.ObtenerUsuarioPorLogin(loginUsuario);

            //  Crear objeto de auditoría  ------- directamete lo creo aca
            auditoriaActual = new ClsAuditoria
            {
                Fecha = DateTime.Now,
                TiempoDeUso = 0,
                IdUsuarios = usuario.IdUsuarios,
                NombreUsuario = $"{usuario.Nombre} {usuario.Apellido}"
            };

            //  Insertar auditoría y guardar ID generado
            auditoriaActual.IdAuditoria = auditoriaDatos.RegistrarAuditoria(auditoriaActual);

            cronometro.Start();
            timerUso.Start();
        }

        //  Cada segundo, incrementa el contador y actualiza el tiempo mostrado
        private void TimerUso_Tick(object sender, EventArgs e)
        {
            segundosTotales++;
            TimeSpan tiempo = TimeSpan.FromSeconds(segundosTotales);
            lblTiempodeUso.Text = $"Tiempo de uso: {tiempo:hh\\:mm\\:ss}";
        }

        //  Al cerrar el formulario, detiene los contadores y guarda el tiempo
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

            //  ID de auditoría
            if (chkfiltrarAuditoriaId.Checked && !string.IsNullOrWhiteSpace(txtAuditoriaId.Text))
                filtro += $"Convert(IdAuditoria, 'System.String') LIKE '%{txtAuditoriaId.Text.Trim()}%'";

            //   nombre de usuario
            if (chkUsuarioNombre.Checked && !string.IsNullOrWhiteSpace(txtUsuarioNombre.Text))
            {
                if (!string.IsNullOrEmpty(filtro)) filtro += " AND ";
                filtro += $"NombreUsuario LIKE '%{txtUsuarioNombre.Text.Trim()}%'";
            }

            // fecha
            if (chkFiltroFecha.Checked)
            {
                string desde = dateDesde.Value.ToString("yyyy-MM-dd");
                string hasta = dateHasta.Value.ToString("yyyy-MM-dd");

                if (!string.IsNullOrEmpty(filtro)) filtro += " AND ";
                filtro += $"Fecha >= '{desde}' AND Fecha <= '{hasta}'";
            }

            
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
                            //  Escribir encabezados
                            for (int i = 0; i < dgvUsuarios.Columns.Count; i++)
                            {
                                writer.Write(dgvUsuarios.Columns[i].HeaderText);
                                if (i < dgvUsuarios.Columns.Count - 1) writer.Write("\t");
                            }
                            writer.WriteLine();

                            //  Escribir contenido fila por fila
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

        //  Exportar datos filtrados a Excel 
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

                            //  Escribir encabezados
                            for (int i = 0; i < dgvUsuarios.Columns.Count; i++)
                            {
                                worksheet.Cell(1, i + 1).Value = dgvUsuarios.Columns[i].HeaderText;
                            }

                            //  Escribir celdas
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

        //  Eventos para disparar los filtros al cambiar opciones // filtros rapidos con lambda
        private void radioASC_CheckedChanged(object sender, EventArgs e) => AplicarFiltros();
        private void RadioDesc_CheckedChanged(object sender, EventArgs e) => AplicarFiltros();
        private void chkUsuarioNombre_CheckedChanged(object sender, EventArgs e) => AplicarFiltros();
        private void txtUsuarioNombre_TextChanged(object sender, EventArgs e) => AplicarFiltros();
        private void chkfiltrarAuditoriaId_CheckedChanged(object sender, EventArgs e) => AplicarFiltros();
        private void txtAuditoriaId_TextChanged(object sender, EventArgs e) => AplicarFiltros();
        private void chkFiltroFecha_CheckedChanged(object sender, EventArgs e) => AplicarFiltros();
        private void dateDesde_ValueChanged(object sender, EventArgs e) => AplicarFiltros();
        private void dateHasta_ValueChanged(object sender, EventArgs e) => AplicarFiltros();

        //  Botón para recargar auditorías desde la base
        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
