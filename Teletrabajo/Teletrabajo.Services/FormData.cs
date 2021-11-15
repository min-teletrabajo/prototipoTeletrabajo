using System;
using System.Collections.Generic;
using System.Text;

namespace Teletrabajo.Services
{
    class FormDataRepository
    {
        public List<FormData> _formDataList { get; set; }

        public FormDataRepository()
        {
            _formDataList = new List<FormData>()
            {
                new FormData(){Id = new Guid(), EstadoTramiteId = 1, FechaCreacion = DateTime.Now, Data = "Soy la Data", UsuarioId = "1", Observaciones = "Nuevo FormData", Version = "V1", FormId=2, NumeroTramite=1},
                new FormData(){Id = new Guid(), EstadoTramiteId = 1, FechaCreacion = DateTime.Now, Data = "Soy la Data2", UsuarioId = "", Observaciones = "Nuevo FormData", Version = "V1", FormId=2, NumeroTramite=1}

            };
        }

    }
}
