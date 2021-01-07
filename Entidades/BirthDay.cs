using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class BirthDay
    {
        public int targetId { get; set; }
        public int usuarioId { get; set; }
        public string nombreMedico { get; set; }
        public string cmpMedico { get; set; }
        public int medicoId { get; set; }
        public int categoriaId { get; set; }
        public string descripcionCategoria { get; set; }
        public int especialidad { get; set; }
        public string descripcionEspecialidad { get; set; }
        public int numeroContacto { get; set; }        
        public string nombreEstado { get; set; }
        public string fechaNacimiento { get; set; }
        public int mesId { get; set; }
        
    }
}
