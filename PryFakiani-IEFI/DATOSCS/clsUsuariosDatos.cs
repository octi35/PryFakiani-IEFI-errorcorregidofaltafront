using System;
using System.Data;
using System.Data.SqlClient;

namespace PryFakiani_IEFI
{
    public class clsUsuariosDatos
    {
        private readonly clsConexion conexionBD = new clsConexion();

        public bool AgregarUsuario(ClsUsuarios usuario)
        {
            using (SqlConnection conexion = conexionBD.ObtenerConexion())
            {
                string query = @"INSERT INTO Usuarios 
                                (Login, Nombre, Apellido, Descripcion, FechaRegistro, Area, Contraseña, FechaNacimiento, Celular, Nivel, DNI)
                                 VALUES 
                                (@Login, @Nombre, @Apellido, @Descripcion, @FechaRegistro, @Area, @Contraseña, @FechaNacimiento, @Celular, @Nivel,@DNI )";

                SqlCommand cmd = new SqlCommand(query, conexion);

                cmd.Parameters.AddWithValue("@Login", usuario.Login);
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@Descripcion", usuario.Descripcion);
                cmd.Parameters.AddWithValue("@FechaRegistro", usuario.FechaRegistro);
                cmd.Parameters.AddWithValue("@Area", usuario.area);
                cmd.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
                cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Celular", usuario.Celular);
                cmd.Parameters.AddWithValue("@Nivel", usuario.Nivel);
                cmd.Parameters.AddWithValue("@DNI", usuario.DNI);

                conexion.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public DataTable ObtenerUsuarios()
        {
            using (SqlConnection conexion = conexionBD.ObtenerConexion())
            {
                string query = "SELECT * FROM Usuarios";
                SqlDataAdapter adaptador = new SqlDataAdapter(query, conexion);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                return tabla;
            }
        }

        public DataTable BuscarUsuarioPorLogin(string login)
        {
            using (SqlConnection conexion = conexionBD.ObtenerConexion())
            {
                string query = "SELECT * FROM Usuarios WHERE Login LIKE @Login";
                SqlDataAdapter adaptador = new SqlDataAdapter(query, conexion);
                adaptador.SelectCommand.Parameters.AddWithValue("@Login", $"%{login}%");
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                return tabla;
            }
        }

        public bool ActualizarUsuario(ClsUsuarios usuario)
        {
            using (SqlConnection conexion = conexionBD.ObtenerConexion())
            {
                string query = @"UPDATE Usuarios SET 
                                 Login = @Login,
                                 Nombre = @Nombre,
                                 Apellido = @Apellido,
                                 Descripcion = @Descripcion,
                                 FechaRegistro = @FechaRegistro,
                                 Area = @Area,
                                 Contraseña = @Contraseña,
                                 FechaNacimiento = @FechaNacimiento,
                                 Celular = @Celular,
                                 Nivel = @Nivel,
                                 DNI = @DNI
                                 WHERE IdUsuarios = @IdUsuarios";

                SqlCommand cmd = new SqlCommand(query, conexion);

                cmd.Parameters.AddWithValue("@Login", usuario.Login);
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@Descripcion", usuario.Descripcion);
                cmd.Parameters.AddWithValue("@FechaRegistro", usuario.FechaRegistro);
                cmd.Parameters.AddWithValue("@Area", usuario.area);
                cmd.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
                cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Celular", usuario.Celular);
                cmd.Parameters.AddWithValue("@Nivel", usuario.Nivel);
                cmd.Parameters.AddWithValue("@DNI", usuario.DNI);
                cmd.Parameters.AddWithValue("@IdUsuarios", usuario.IdUsuarios);

                conexion.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool EliminarUsuario(int idUsuario)
        {
            using (SqlConnection conexion = conexionBD.ObtenerConexion())
            {
                conexion.Open();

                // Primero borra las auditorías relacionadas
                string queryAuditoria = "DELETE FROM Auditoria WHERE IdUsuarios = @IdUsuarios";
                SqlCommand cmdAuditoria = new SqlCommand(queryAuditoria, conexion);
                cmdAuditoria.Parameters.AddWithValue("@IdUsuarios", idUsuario);
                cmdAuditoria.ExecuteNonQuery();

                // Ahora sí puede borrar el usuario
                string queryUsuario = "DELETE FROM Usuarios WHERE IdUsuarios = @IdUsuarios";
                SqlCommand cmdUsuario = new SqlCommand(queryUsuario, conexion);
                cmdUsuario.Parameters.AddWithValue("@IdUsuarios", idUsuario);
                return cmdUsuario.ExecuteNonQuery() > 0;
            }
        }

        public bool ValidarLogin(string login, string password)
        {
            using (SqlConnection conexion = conexionBD.ObtenerConexion())
            {
                conexion.Open();
                string consulta = "SELECT COUNT(*) FROM Usuarios WHERE Login = @login AND Contraseña = @password";
                SqlCommand cmd = new SqlCommand(consulta, conexion);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", password);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public int ObtenerNivelUsuario(string login, string password)
        {
            using (SqlConnection conexion = conexionBD.ObtenerConexion())
            {
                conexion.Open();
                string query = "SELECT Nivel FROM Usuarios WHERE Login = @login AND Contraseña = @password";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", password);

                object resultado = cmd.ExecuteScalar();
                return resultado != null && resultado != DBNull.Value ? Convert.ToInt32(resultado) : -1;
            }
        }



        //metodo tiempo 
        public ClsUsuarios ObtenerUsuarioPorLogin(string login)
        {
            using (SqlConnection conexion = conexionBD.ObtenerConexion())
            {
                string query = "SELECT * FROM Usuarios WHERE Login = @login";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@login", login);

                conexion.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new ClsUsuarios
                    {
                        IdUsuarios = Convert.ToInt32(reader["IdUsuarios"]),
                        Nombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString(),
                        Login = reader["Login"].ToString(),
                        Descripcion = reader["Descripcion"].ToString(),
                        FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                        area = reader["Area"] != DBNull.Value ? reader["Area"].ToString() : "Sin Área",
                        Contraseña = reader["Contraseña"].ToString(),
                        FechaNacimiento = reader["FechaNacimiento"] != DBNull.Value
                            ? Convert.ToDateTime(reader["FechaNacimiento"])
                            : DateTime.MinValue,
                        Celular = reader["Celular"] != DBNull.Value ? reader["Celular"].ToString() : "Sin celular",
                        Nivel = reader["Nivel"] != DBNull.Value ? Convert.ToInt32(reader["Nivel"]) : 0,
                        DNI = reader["DNI"] != DBNull.Value ? reader["DNI"].ToString() : "Sin DNI"
                    };
                }
                return null;
            }
        }




    }


}
