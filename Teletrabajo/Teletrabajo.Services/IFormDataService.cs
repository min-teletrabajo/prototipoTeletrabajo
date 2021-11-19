using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Teletrabajo.Models;

namespace Teletrabajo.Services
{
    public interface IFormDataService
    {
        Task<FormData> Post(FormData formData);
    }
}
