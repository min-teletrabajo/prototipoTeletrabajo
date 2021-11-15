using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Teletrabajo.Models
{
    public partial class FormDataAdjunto
    {
        [Key]
        public Guid FormDataId { get; set; }
        [Key]
        public Guid AdjuntoId { get; set; }

        public virtual Adjunto Adjunto { get; set; }
        public virtual FormData FormData { get; set; }
    }
}
