using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class StockMantenimiento
    {
        public int productoId { get; set; }
        public string codigoProducto { get; set; }
        public string descripcion { get; set; }
        public string lote { get; set; }
        public int cantidadAsignada { get; set; }
        public int stock { get; set; }
    }
}
