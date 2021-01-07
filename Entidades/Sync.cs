using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Sync
    {
        public List<Estado> estados { get; set; }
        public List<Ciclo> ciclos { get; set; }
        public List<Duracion> duracions { get; set; }
        public List<Personal> personals { get; set; }
        public List<Categoria> categorias { get; set; }
        public List<Identificador> identificadors { get; set; }
        public List<Especialidad> especialidads { get; set; }
        public List<Ubigeo> ubigeos { get; set; }        
        public List<Medico> medicos { get; set; }
        public List<Visita> visitas { get; set; }
    }
}
