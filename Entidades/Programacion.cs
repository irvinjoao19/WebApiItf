using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Programacion
    {

        public int programacionId { get; set; }
        public int cicloId { get; set; }
        public string nombreCiclo { get; set; }
        public string numeroVisita { get; set; }
        public int usuarioId { get; set; }
        public string nombreUsuario { get; set; }        
        public int medicoId { get; set; }
        public string cmpMedico { get; set; }
        public string nombreMedico { get; set; }        
        public string categoria { get; set; }
        public string especialidad { get; set; }
        public string fechaProgramacion { get; set; }
        public string horaProgramacion { get; set; }
        public string fechaReporteProgramacion { get; set; }
        public string horaReporteProgramacion { get; set; }        
        public string visitaAcompanada { get; set; }
        public string dataAcompaniante { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public int estadoProgramacion { get; set; }
        public string descripcionEstado { get; set; }
        public int resultadoVisitaId { get; set; }
        public string descripcionResultado { get; set; }             
		public int direccionId { get; set; }
		public string direccion { get; set; }
        public int identity { get; set; }
        public int especialidadId { get; set; }
        public List<ProgramacionDet> productos { get; set; }       
    }
}
