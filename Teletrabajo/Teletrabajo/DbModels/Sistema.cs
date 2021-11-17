﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

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
