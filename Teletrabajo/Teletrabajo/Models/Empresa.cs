using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teletrabajo.Models
{
    public class Empresa
    {
        public string Cuit { get; set; }
        public string RazonSocial { get; set; }
        public string Actividad { get; set; }
        public string DomicilioFiscal { get; set; }
    }
}
