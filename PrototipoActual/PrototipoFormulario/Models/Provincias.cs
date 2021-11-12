using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PrototipoFormulario.Models
{
    public partial class Provincias
    {
        public Provincias()
        {
            Partidos = new HashSet<Partidos>();
            RepresentantesLegales = new HashSet<RepresentantesLegales>();
            Sucursales = new HashSet<Sucursales>();
            Trabajadores = new HashSet<Trabajadores>();
        }

        public int IdProvincia { get; set; }
        public string Descripcion { get; set; }
        public int? IdPais { get; set; }

        public virtual Paises IdPaisNavigation { get; set; }
        public virtual ICollection<Partidos> Partidos { get; set; }
        public virtual ICollection<RepresentantesLegales> RepresentantesLegales { get; set; }
        public virtual ICollection<Sucursales> Sucursales { get; set; }
        public virtual ICollection<Trabajadores> Trabajadores { get; set; }
    }
}
