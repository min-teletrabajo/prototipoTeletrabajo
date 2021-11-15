using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Teletrabajo.Models
{
    public partial class Form
    {
        public Form()
        {
            FormData = new HashSet<FormData>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int SistemaId { get; set; }

        public virtual Sistema Sistema { get; set; }
        public virtual ICollection<FormData> FormData { get; set; }
    }
}
