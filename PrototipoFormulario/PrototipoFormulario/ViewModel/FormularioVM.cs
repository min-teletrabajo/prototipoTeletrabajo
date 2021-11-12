﻿using PrototipoFormulario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototipoFormulario.ViewModel
{
   
        public class FormularioVM
        {
            public bool Estado { get; set; }
            public List<Trabajadores> Trabajadores { get; set; }
            public RepresentantesLegales RepresentanteLegal { get; set; }
            public List<Empresas> Empresas { get; set; }
        }
   
}
