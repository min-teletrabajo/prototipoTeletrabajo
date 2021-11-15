using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teletrabajo.Models;

namespace Teletrabajo.ViewModels
{
    public class FormularioVM
    {
        public List<Trabajador> Trabajadores { get; set; }
        public RepresentanteLegal RepresentanteLegal { get; set; }
        public List<Empresa> Empresas { get; set; }


        public bool EncuestaCalidad { get; set; }
        public bool DispositivoDeControl { get; set; }
        public bool FijacionPlazos { get; set; }
        public bool EvaluacionLaboral { get; set; }
        public bool EstablecimientoIndicadores { get; set; }
        public bool SoftwareParaMonitorear { get; set; }

        public string Otros { get; set; }
    }
}
