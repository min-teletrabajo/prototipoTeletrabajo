<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Mvc.Rendering;
using PrototipoFormulario.Models;
=======
﻿using PrototipoFormulario.Models;
>>>>>>> aeb8c96e9f8cdfa27ae27fca84963ec9976010a8
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
<<<<<<< HEAD

            public List<SelectListItem> Paises { get; set; }
            public List<SelectListItem> Provincias { get; set; }
            public List<SelectListItem> Localidades { get; set; }
            public List<SelectListItem> Partidos { get; set; }
    }
=======
        }
>>>>>>> aeb8c96e9f8cdfa27ae27fca84963ec9976010a8
   
}
