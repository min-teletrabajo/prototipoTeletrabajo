using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Teletrabajo.Models
{
    public class Domicilio
    {
        public string Provincia { get; set; }
        public string Partido { get; set; }
        public string Localidad { get; set; }
        [Required]
        public string Calle { get; set; }
        [Required]
        public string Altura { get; set; }
        public string Piso { get; set; }
        public string Departamento { get; set; }
        public string InstruccionesAdicionales { get; set; }
        public string CodigoPostal { get; set; }
    }
}
