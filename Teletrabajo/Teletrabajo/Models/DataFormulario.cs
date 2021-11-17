using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teletrabajo.Models
{
    public class DataFormulario
    {
        public RepresentanteLegal Representante { get; set; }
        public List<Trabajador> Trabajadores { get; set; }
        public List<Empresa> Empresas { get; set; }
    }
}
