using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PrototipoFormulario.Models
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            TramiteFormularios = new HashSet<TramiteFormularios>();
            UsuarioXperfil = new HashSet<UsuarioXperfil>();
        }

        public int IdUsuario { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<TramiteFormularios> TramiteFormularios { get; set; }
        public virtual ICollection<UsuarioXperfil> UsuarioXperfil { get; set; }
    }
}
