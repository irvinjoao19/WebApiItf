using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class RptDiario
    {
        public string nombreCiclo { get; set; }
        public string fechaInicioCiclo { get; set; }
        public string fechaFinCiclo { get; set; }
        public string fechaActual { get; set; }
        public int diasCicloMes { get; set; }
        public int diasFecha { get; set; }
        public int usuarioId { get; set; }
        public string representanteMedico { get; set; }
        public string cuota { get; set; }
        public int frecuencia { get; set; }
        public int cobertura { get; set; }
    }
}
