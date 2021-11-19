using System;
using System.Collections.Generic;
using System.Text;

namespace Teletrabajo.Models
{
    public partial class Adjunto
    {
        public Guid Id { get; set; }
        public string NombreArchivo { get; set; }
        public string Metadata { get; set; }
        public byte[] Content { get; set; }
    }
}
