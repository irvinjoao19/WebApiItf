﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Categoria
    {
        public int categoriaId { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }
        public int estadoId { get; set; }
        public int usuarioId { get; set; }
    }
}
