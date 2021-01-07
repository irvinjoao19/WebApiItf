using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class NuevaDireccion
    {
        public int solDireccionId { get; set; }
        public int medicoId { get; set; }
        public string nombreMedico { get; set; }
        public int medicoDireccionId { get; set; }
        public string solicitante { get; set; }
        public string fechaSolicitud { get; set; }
        public string fechaRespuesta { get; set; }
        public string comentarioRespuesta { get; set; }
        public string aprobador { get; set; }
        public int estadoId { get; set; }
        public string descripcionEstado { get; set; }
        public string codigoDepartamento { get; set; }
        public string nombreDepartamento { get; set; }
        public string codigoProvincia { get; set; }
        public string nombreProvincia { get; set; }
        public string codigoDistrito { get; set; }
        public string nombreDistrito { get; set; }
        public string nombreDireccion { get; set; }
        public string referencia { get; set; }
        public string nombreInstitucion { get; set; }
        public int identity { get; set; }
        public string observacion { get; set; }

        public int usuarioId { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFinal { get; set; }
        public int tipo { get; set; }

    }
}
