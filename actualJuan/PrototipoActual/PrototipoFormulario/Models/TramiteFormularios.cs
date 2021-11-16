using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PrototipoFormulario.Models
{
    public partial class TramiteFormularios
    {
        public TramiteFormularios()
        {
            Trabajadores = new HashSet<Trabajadores>();
        }

        public int IdTramiteFormulario { get; set; }
        public int IdUsuario { get; set; }
        public int IdEmpresa { get; set; }
        public int IdRepresentanteLegal { get; set; }
        public int IdEstado { get; set; }
        public string Observacion { get; set; }
        public DateTime? FechaAlta { get; set; }
        public bool EncuestaCalidad { get; set; }
        public bool DispositivoDeControl { get; set; }
        public bool FijacionPlazos { get; set; }
        public bool EvaluacionLaboral { get; set; }
        public bool EstablecimientoIndicadores { get; set; }
        public bool SoftwareParaMonitorear { get; set; }
        public string Otros { get; set; }
        public int? NumeroTramite { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual Empresas IdEmpresaNavigation { get; set; }
        public virtual Estados IdEstadoNavigation { get; set; }
        public virtual RepresentantesLegales IdRepresentanteLegalNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
        public virtual ICollection<Trabajadores> Trabajadores { get; set; }
    }
}
