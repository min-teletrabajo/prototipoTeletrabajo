using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PrototipoFormulario.Models
{
    public partial class TipoDocumentos
    {
        public TipoDocumentos()
        {
            RepresentantesLegales = new HashSet<RepresentantesLegales>();
        }

        public int IdTipoDocumento { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<RepresentantesLegales> RepresentantesLegales { get; set; }
    }
}
