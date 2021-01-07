using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Personal
    {
        public int personalId { get; set; }
        public string nroDoc { get; set; }
        public string email { get; set; }
        public int perfilId { get; set; }
        public string apellidoP { get; set; }
        public string apellidoM { get; set; }
        public string nombre { get; set; }
        public string celular { get; set; }
        public string fechaNacimiento { get; set; }
        public string sexo { get; set; }
        public int supervisorId { get; set; }
        public int esSupervisorId { get; set; }
        public int estado { get; set; }
        public string foto { get; set; }
        public string login { get; set; }
        public string pass { get; set; }
        public string nombreSupervisor { get; set; }
        public string nombreEstado { get; set; }
        public string nombrePerfil { get; set; }
        public int usuarioId { get; set; }
    }
}
