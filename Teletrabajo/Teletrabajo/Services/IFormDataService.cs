using System;
using System.Collections.Generic;
using System.Text;
using Teletrabajo.Models;

namespace Teletrabajo.Services
{
    public interface IFormDataService
    {
        List<FormData> GetAllFormData();
    }
}
