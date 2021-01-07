using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        public int productoId { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public int tipoProductoId { get; set; }
        public string abreviatura { get; set; }
        public string tipo { get; set; }
        public string control { get; set; }
        public int controlId { get; set; }
        public string estado { get; set; }
        public int estadoId { get; set; }         
        public int usuarioId { get; set; }         
        public string descripcionTipoProducto { get; set; }         

    }
}
