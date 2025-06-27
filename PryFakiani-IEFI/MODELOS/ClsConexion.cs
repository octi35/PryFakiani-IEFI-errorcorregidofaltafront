using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryFakiani_IEFI
{
     
        public class clsConexion
        {
            public  string cadenaConexion = "server=OCTI\\SQLEXPRESS; database=Negocio; integrated security=true";

            public SqlConnection ObtenerConexion()
            {
                return new SqlConnection(cadenaConexion);
            }
        }   
}
