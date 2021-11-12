using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PrototipoFormulario.Models
{
    public partial class UsuarioXperfil
    {
        public int IdUsuarioXperfil { get; set; }
        public int IdUsuario { get; set; }
        public int IdPerfil { get; set; }

        public virtual Perfiles IdPerfilNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
    }
}
