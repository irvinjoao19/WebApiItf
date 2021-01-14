using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Medico
    {
        public int medicoId { get; set; }
        public int medicoSolId { get; set; }
        public int identificadorId { get; set; }
        public string cpmMedico { get; set; }
        public string nombreMedico { get; set; }
        public string apellidoP { get; set; }
        public string apellidoM { get; set; }
        public int categoriaId { get; set; }
        public int especialidadId { get; set; }
        public int especialidadId2 { get; set; }
        public string email { get; set; }
        public string fechaNacimiento { get; set; }
        public string sexo { get; set; }
        public string telefono { get; set; }
        public int estado { get; set; }
        public int usuarioId { get; set; }
        public string nombreIdentificador { get; set; }
        public string nombreCategoria { get; set; }
        public string nombreEspecialidad { get; set; }
        public string nombreEspecialidad2 { get; set; }
        public int identity { get; set; }
        public string visitadoPor { get; set; }
        public string direccion { get; set; }
        public string nombreCompleto { get; set; }
        public int tipoVisitaId { get; set; }
        public List<MedicoDireccion> direcciones { get; set; }
    }
}
