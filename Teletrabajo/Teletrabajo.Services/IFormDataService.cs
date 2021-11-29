using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Teletrabajo.Models;
using Teletrabajo.Models.Enums;

namespace Teletrabajo.Services
{
    public interface IFormDataService
    {
        Task<FormData> Post(FormData formData, EstadoTramite estado);
    }
}
