using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class RptGeneral
    {
        public int usuarioId { get; set; }
        public string representanteMedico { get; set; }
        public string nombreCiclo { get; set; }
        public string fechaInicioCiclo { get; set; }
        public string fechaFinCiclo { get; set; }
        public string fechaActual { get; set; }
        public int diasCicloMes { get; set; }
        public int diasFecha { get; set; }
        public string accion { get; set; }
        public int cuotaMes { get; set; }
        public int numeroVisita { get; set; }
        public int porcentajeMes { get; set; }
        public int saldoMes { get; set; }
        public int cuotaFecha { get; set; }
        public int porcentajeFecha { get; set; }
        public int saldoFecha { get; set; }
    }
}
