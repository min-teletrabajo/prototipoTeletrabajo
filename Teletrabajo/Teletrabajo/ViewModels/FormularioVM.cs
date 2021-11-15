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
    }
}
