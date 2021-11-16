using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Migracion.Models
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
