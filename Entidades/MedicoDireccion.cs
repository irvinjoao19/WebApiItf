using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MedicoDireccion
    {
        public int medicoDireccionId { get; set; }
        public int medicoId { get; set; }
        public string codigoDepartamento { get; set; }
        public string codigoProvincia { get; set; }
        public string codigoDistrito { get; set; }
        public string direccion { get; set; }
        public string referencia { get; set; }
        public int estado { get; set; }
        public int usuarioId { get; set; }
        public string institucion { get; set; }
        public string nombreDepartamento { get; set; }
        public string nombreProvincia { get; set; }
        public string nombreDistrito { get; set; }
        public int identity { get; set; }
        public int identityDetalle { get; set; }
    }
}
