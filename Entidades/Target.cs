using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Target
    {
        public int targetId { get; set; }
        public int usuarioId { get; set; }
        public string nombreUsuario { get; set; }
        public string cmpMedico { get; set; }
        public int medicoId { get; set; }
        public string nombreMedico { get; set; }
        public int categoriaId { get; set; }
        public string descripcionCategoria { get; set; }
        public int especialidadId { get; set; }
        public string descripcionEspecialidad { get; set; }
        public int numeroContactos { get; set; }
        public string estado { get; set; }
        public List<Medico> medicos { get; set; }
    }
}
