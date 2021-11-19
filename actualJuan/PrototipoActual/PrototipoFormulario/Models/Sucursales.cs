using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PrototipoFormulario.Models
{
    public partial class Sucursales
    {
        public Sucursales()
        {
            Trabajadores = new HashSet<Trabajadores>();
        }

        public int IdSucursal { get; set; }
        public int IdEmpresa { get; set; }
        public int IdPartido { get; set; }
        public int IdProvincia { get; set; }
        public int IdLocalidad { get; set; }
        public string Calle { get; set; }
        public int? Numero { get; set; }
        public int? Piso { get; set; }
        public string Departamento { get; set; }
        public string Instrucciones { get; set; }

        public virtual Empresas IdEmpresaNavigation { get; set; }
        public virtual Localidades IdLocalidadNavigation { get; set; }
        public virtual Partidos IdPartidoNavigation { get; set; }
        public virtual Provincias IdProvinciaNavigation { get; set; }
        public virtual ICollection<Trabajadores> Trabajadores { get; set; }
    }
}
