using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PrototipoFormulario.Models
{
    public partial class Permisos
    {
        public int IdPermiso { get; set; }
        public int IdPerfil { get; set; }
        public string Descripcion { get; set; }

        public virtual Perfiles IdPerfilNavigation { get; set; }
    }
}
