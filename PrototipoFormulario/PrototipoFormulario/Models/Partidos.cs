using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PrototipoFormulario.Models
{
    public partial class Partidos
    {
        public Partidos()
        {
            Localidades = new HashSet<Localidades>();
            Sucursales = new HashSet<Sucursales>();
            Trabajadores = new HashSet<Trabajadores>();
        }

        public int IdPartido { get; set; }
        public string Descripcion { get; set; }
        public int? IdProvincia { get; set; }

        public virtual Provincias IdProvinciaNavigation { get; set; }
        public virtual ICollection<Localidades> Localidades { get; set; }
        public virtual ICollection<Sucursales> Sucursales { get; set; }
        public virtual ICollection<Trabajadores> Trabajadores { get; set; }
    }
}
