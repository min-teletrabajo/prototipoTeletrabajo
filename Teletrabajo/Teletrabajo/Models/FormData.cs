using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Teletrabajo.Models
{
    public partial class FormData
    {
        public int Id { get; set; }
        public int? EstadoTramiteId { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string Data { get; set; }
        public string UsuarioId { get; set; }
        public string Observaciones { get; set; }
        public string Version { get; set; }
        public int? NumeroTramite { get; set; }
        public int? FormId { get; set; }

        public virtual Form Form { get; set; }
    }
}
