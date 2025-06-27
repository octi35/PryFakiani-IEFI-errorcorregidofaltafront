using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace PryFakiani_IEFI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // 1. Verificar si existe la base de datos
            if (!BaseDeDatosExiste("Negocio"))
            {
                EjecutarScriptSQL("script_inicial.sql");
            }

            // 2. Iniciar aplicación
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new formInicio());
        }

        private static bool BaseDeDatosExiste(string nombreBD)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection("Server=localhost\\SQLEXPRESS;Integrated Security=true"))
                {
                    conexion.Open();
                    string query = $"SELECT db_id('{nombreBD}')";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    return cmd.ExecuteScalar() != DBNull.Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar la base de datos: " + ex.Message);
                return false;
            }
        }

        private static void EjecutarScriptSQL(string nombreArchivo)
        {
            try
            {
                string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, nombreArchivo);
                string script = File.ReadAllText(ruta);

                string[] comandos = script.Split(new[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);

                using (SqlConnection conexion = new SqlConnection("Server=localhost\\SQLEXPRESS;Integrated Security=true"))
                {
                    conexion.Open();
                    foreach (string comando in comandos)
                    {
                        if (!string.IsNullOrWhiteSpace(comando))
                        {
                            SqlCommand cmd = new SqlCommand(comando, conexion);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Base de datos creada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar el script SQL: " + ex.Message);
            }
        }
    }
}

