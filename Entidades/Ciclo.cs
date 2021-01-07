using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciclo
    {
        public int cicloId { get; set; }
        public string nombre { get; set; }
        public string desde { get; set; }
        public string hasta { get; set; }
        public string nombreEstado { get; set; }
        public int estado { get; set; }
        public int usuarioId { get; set; }
    }
}
