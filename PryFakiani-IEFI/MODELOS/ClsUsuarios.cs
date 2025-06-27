using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryFakiani_IEFI
{
    public class ClsUsuarios
    {
        public int IdUsuarios { get; set; }
        public string Login { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string DNI { get; set; }

        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string area { get; set; }
        public string Contraseña { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Celular { get; set; }
        public int Nivel {  get; set; }

        public ClsUsuarios()
        {
            FechaRegistro = DateTime.Now;
        }

    }
}
