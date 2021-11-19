using System;
using System.Collections.Generic;
<<<<<<< HEAD:Teletrabajo/Teletrabajo.Models/FormDataAdjunto.cs
using System.Text;
=======

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable
>>>>>>> 5d75ce1960411eb41da1fd707afe876ed33eb039:Teletrabajo/Teletrabajo/DbModels/FormDataAdjunto.cs

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
