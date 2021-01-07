using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SolMedico
    {
        public int solMedicoId { get; set; }
        public string mensajeSol { get; set; }
        public string usuario { get; set; }
        public string fecha { get; set; }
        public string usuarioAprobador { get; set; }
        public int estadoSol { get; set; }
        public string descripcionEstado { get; set; }
        public int usuarioId { get; set; }
        public int identity { get; set; }
        public int tipo { get; set; }

        public string respuestaAprobador { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFinal { get; set; }
        public List<Medico> medicos { get; set; }
    }
}
