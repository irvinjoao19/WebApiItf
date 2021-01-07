using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Visita
    {
        public int visitaId { get; set; }
        public string descripcion { get; set; }
        public string resultado { get; set; }
        public string estado { get; set; }
        public int estadoId { get; set; }
        public int usuarioId { get; set; }
    }
}
