using System;
using System.Collections.Generic;
using System.Text;

namespace Teletrabajo.DbModels
{
    public partial class Sistema
    {
        public Sistema()
        {
            Form = new HashSet<Form>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Form> Form { get; set; }
    }
}
