using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PrototipoFormulario.Models
{
    public partial class Modalidades
    {
        public Modalidades()
        {
            Trabajadores = new HashSet<Trabajadores>();
        }

        public int IdModalidadDeContratacion { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Trabajadores> Trabajadores { get; set; }
    }
}
