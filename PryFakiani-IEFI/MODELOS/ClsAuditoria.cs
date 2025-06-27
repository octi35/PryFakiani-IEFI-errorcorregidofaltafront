using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryFakiani_IEFI
{
    public class ClsAuditoria
    {
        public int IdAuditoria { get; set; }
        public int IdUsuarios { get; set; }
        public string NombreUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public int TiempoDeUso { get; set; }

    }
}
