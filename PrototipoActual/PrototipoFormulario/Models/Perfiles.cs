using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PrototipoFormulario.Models
{
    public partial class Perfiles
    {
        public Perfiles()
        {
            Permisos = new HashSet<Permisos>();
            UsuarioXperfil = new HashSet<UsuarioXperfil>();
        }

        public int IdPerfil { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Permisos> Permisos { get; set; }
        public virtual ICollection<UsuarioXperfil> UsuarioXperfil { get; set; }
    }
}
