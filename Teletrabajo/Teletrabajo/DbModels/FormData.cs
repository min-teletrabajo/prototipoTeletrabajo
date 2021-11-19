using System;
using System.Collections.Generic;
using System.Text;

namespace Teletrabajo.DbModels
{
    public partial class FormData
    {
        public Guid Id { get; set; }
        public string UsuarioId { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? EstadoTramiteId { get; set; }
        public string Data { get; set; }
        public string Version { get; set; }
        public string Observaciones { get; set; }
        public int NumeroTramite { get; set; }
        public int FormId { get; set; }

        public virtual Form Form { get; set; }
    }
}
