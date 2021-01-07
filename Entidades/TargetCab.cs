using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TargetCab
    {
        public int targetCabId { get; set; }
        public string fechaSolicitud { get; set; }
        public string aprobador { get; set; }
        public int estado { get; set; }
        public string nombreEstado { get; set; }
        public string usuarioSolicitante { get; set; }
        public int usuarioId { get; set; }
        public string tipoTarget { get; set; }
        public int identity { get; set; }
        public int tipo { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFinal { get; set; }
		
		public string  cmpMedico{ get; set; }
		public string  nombresMedico{ get; set; }
		public string  descripcionCategoria{ get; set; }
		public string  descripcionEspecialidad{ get; set; }
		public int numeroContactos{ get; set; }

        public List<TargetDet> detalle { get; set; }
    }
}
