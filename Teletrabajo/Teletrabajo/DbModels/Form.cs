using System;
using System.Collections.Generic;
using System.Text;

namespace Teletrabajo.DbModels
{
    public partial class Form
    {
        public Form()
        {
            FormData = new HashSet<FormData>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string VersionActual { get; set; }
        public bool Habilitado { get; set; }
        public int SistemaId { get; set; }

        public virtual Sistema Sistema { get; set; }
        public virtual ICollection<FormData> FormData { get; set; }
    }
}
