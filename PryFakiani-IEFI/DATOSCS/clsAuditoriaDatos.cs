using System;
using System.Data;
using System.Data.SqlClient;

namespace PryFakiani_IEFI
{
    public class ClsAuditoriaDatos
    {
        private readonly string cadenaConexion = "server=OCTI\\SQLEXPRESS; database=Negocio; integrated security=true";

        public DataTable ObtenerAuditoriasConUsuarios()
        {
            DataTable tabla = new DataTable();
            string consulta = @"
                SELECT 
                    A.IdAuditoria, 
                    A.IdUsuarios,
                    U.Nombre + ' ' + U.Apellido AS NombreUsuario,
                    A.Fecha, 
                    A.TiempoDeUso
                FROM Auditoria A
                INNER JOIN Usuarios U ON A.IdUsuarios = U.IdUsuarios
                ORDER BY A.IdAuditoria";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
                    adaptador.Fill(tabla);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener auditorías: " + ex.Message);
                }
            }

            return tabla;
        }

        //  Insertar auditoría y devolver el ID insertado
        public int RegistrarAuditoria(ClsAuditoria auditoria)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                string insert = @"INSERT INTO Auditoria (Fecha, TiempoDeUso, IdUsuarios, NombreUsuario)
                                  OUTPUT INSERTED.IdAuditoria
                                  VALUES (@Fecha, @TiempoDeUso, @IdUsuarios, @NombreUsuario)";

                SqlCommand cmdInsert = new SqlCommand(insert, conexion);
                cmdInsert.Parameters.AddWithValue("@Fecha", auditoria.Fecha);
                cmdInsert.Parameters.AddWithValue("@TiempoDeUso", auditoria.TiempoDeUso);
                cmdInsert.Parameters.AddWithValue("@IdUsuarios", auditoria.IdUsuarios);
                cmdInsert.Parameters.AddWithValue("@NombreUsuario", auditoria.NombreUsuario);

                return (int)cmdInsert.ExecuteScalar();
            }
        }

        //  Actualizar por ID
        public bool ActualizarTiempoDeUso(int idAuditoria, int tiempoEnSegundos)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                string update = @"UPDATE Auditoria
                                  SET TiempoDeUso = @TiempoDeUso
                                  WHERE IdAuditoria = @IdAuditoria";

                SqlCommand cmd = new SqlCommand(update, conexion);
                cmd.Parameters.AddWithValue("@TiempoDeUso", tiempoEnSegundos);
                cmd.Parameters.AddWithValue("@IdAuditoria", idAuditoria);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
