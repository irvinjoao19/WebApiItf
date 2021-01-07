using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PuntoContacto
    {
        public int puntoContactoId { get; set; }
        public int usuarioId { get; set; }
        public string fechaPuntoContacto { get; set; }
        public string descripcion { get; set; }
        public int estadoId { get; set; }
        public string descripcionEstado { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
    }
}
