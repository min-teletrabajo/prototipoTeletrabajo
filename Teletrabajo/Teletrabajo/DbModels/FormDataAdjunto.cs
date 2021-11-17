using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Teletrabajo.DbModels
{
    public partial class FormDataAdjunto
    {
        public Guid FormDataId { get; set; }
        public Guid AdjuntoId { get; set; }

        public virtual Adjunto Adjunto { get; set; }
        public virtual FormData FormData { get; set; }
    }
}
