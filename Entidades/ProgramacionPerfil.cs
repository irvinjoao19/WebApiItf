using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ProgramacionPerfil
    {
        public int medicoId { get; set; }
        public string nombreMedico { get; set; }
        public string matricula { get; set; }
        public string especialidad { get; set; }
        public string direccion { get; set; }
        public string mercadoProducto { get; set; }
        public string doceUltimosMeses { get; set; }
        public string tresUltimosMeses { get; set; }
        public string ultimoMeses { get; set; }
    }
}
