using System;
using System.Collections.Generic;
using System.Text;

namespace Teletrabajo.Models
{
    public partial class FormDataAdjunto
    {
        public Guid FormDataId { get; set; }
        public Guid AdjuntoId { get; set; }

        public virtual Adjunto Adjunto { get; set; }
        public virtual FormData FormData { get; set; }
    }
}
