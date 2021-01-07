using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TargetDet
    {
        public int targetDetId { get; set; }
        public int targetCabId { get; set; }
        public int medicoId { get; set; }
        public string cmp { get; set; }
        public int categoriaId { get; set; }
        public int especialidadId { get; set; }
        public int nroContacto { get; set; }
        public string mensajeRespuesta { get; set; }
        public string nombreMedico { get; set; }
        public string nombreCategoria { get; set; }
        public string nombreEspecialidad { get; set; }

        public int identity { get; set; }
        public int estado { get; set; }
        public int estadoTarget { get; set; }
        public string visitadoPor { get; set; }
        public int visitado { get; set; }
        public int nrovisita { get; set; }
        public string mensajeNrovisita { get; set; }
        public List<TargetInfo> infos { get; set; }
    }
}
