using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ProgramacionDet
    {
        public int programacionDetId { get; set; }
        public int programacionId { get; set; }
        public int productoId { get; set; }
        public int ordenProgramacion { get; set; }
        public string codigoProducto { get; set; }
        public string descripcionProducto { get; set; }
        public string lote { get; set; }
        public int cantidad { get; set; }
        public int stock { get; set; }
        public int identity { get; set; }
    }
}
