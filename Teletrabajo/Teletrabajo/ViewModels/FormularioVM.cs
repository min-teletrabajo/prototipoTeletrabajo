using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teletrabajo.FormModels;

namespace Teletrabajo.ViewModels
{
    public class FormularioVM
    {
        public List<Trabajador> Trabajadores { get; set; } = new List<Trabajador>();
        public RepresentanteLegal RepresentanteLegal { get; set; }
        public List<Empresa> Empresas { get; set; } = new List<Empresa>();

        //public List<SelectListItem> Paises { get; set; }


        public bool EncuestaCalidad { get; set; }
        public bool DispositivoDeControl { get; set; }
        public bool FijacionPlazos { get; set; }
        public bool EvaluacionLaboral { get; set; }
        public bool EstablecimientoIndicadores { get; set; }
        public bool SoftwareParaMonitorear { get; set; }

        public string Otros { get; set; }
    }
}
