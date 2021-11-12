using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PrototipoFormulario.Models
{
    public partial class Paises
    {
        public Paises()
        {
            Provincias = new HashSet<Provincias>();
            Trabajadores = new HashSet<Trabajadores>();
        }

        public int IdPais { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Provincias> Provincias { get; set; }
        public virtual ICollection<Trabajadores> Trabajadores { get; set; }
    }
}
