using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PrototipoFormulario.Models
{
    public partial class Empresas
    {
        public Empresas()
        {
            Sucursales = new HashSet<Sucursales>();
            TramiteFormularios = new HashSet<TramiteFormularios>();
        }

        public int IdEmpresa { get; set; }
        public int IdRepresentanteLegal { get; set; }
        public int? IdActividad { get; set; }
        public long Cuit { get; set; }
        public string RazonSocial { get; set; }
        public string DomicilioFiscal { get; set; }

        public virtual Actividades IdActividadNavigation { get; set; }
        public virtual RepresentantesLegales IdRepresentanteLegalNavigation { get; set; }
        public virtual ICollection<Sucursales> Sucursales { get; set; }
        public virtual ICollection<TramiteFormularios> TramiteFormularios { get; set; }
    }
}
