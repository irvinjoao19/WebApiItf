using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Actividad
    {
        public int actividadId { get; set; }
        public int cicloId { get; set; }
        public string fechaActividad { get; set; }
        public string fecha { get; set; }
        public int duracionId { get; set; }
        public string descripcionDuracion { get; set; }
        public string detalle { get; set; }
        public int estado { get; set; }
        public string descripcionEstado { get; set; }
        public string aprobador { get; set; }
        public string observacion { get; set; }
        public string usuario { get; set; }
        public int usuarioId { get; set; }
        public int identity { get; set; }
        public string fechaRespuesta { get; set; }
        public string tipoInterfaz { get; set; }
        public string nombreCiclo { get; set; }
        public int tipo { get; set; }
        public int medicoId { get; set; }
        public string nombreMedico { get; set; }
    }
}
