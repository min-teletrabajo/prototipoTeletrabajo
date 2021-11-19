using System;
using System.Collections.Generic;
using System.Text;

namespace Teletrabajo.FormModels
{
    public class DataFormulario
    {
        public RepresentanteLegal Representante { get; set; }
        public List<Trabajador> Trabajadores { get; set; }
        public List<Empresa> Empresas { get; set; }
    }
}
