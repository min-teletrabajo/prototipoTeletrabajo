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
        [Required(ErrorMessage = "La calle es obligatoria")]
        public string Calle { get; set; }
        [Required(ErrorMessage ="La altura es obligatoria")]
        public string Altura { get; set; }
        [Required(ErrorMessage = "El es piso es obligatorio")]
        public string Piso { get; set; }
        public string Departamento { get; set; }
        public string InstruccionesAdicionales { get; set; }
        public string CodigoPostal { get; set; }
    }
}
