using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Email
    {
        public string remitente { get; set; }
        public string remitentePass { get; set; }
        public string destinatario { get; set; }
        public string copiaDestinatario { get; set; }
        public string asunto { get; set; }
        public string cuerpoMensaje { get; set; }
    }
}
