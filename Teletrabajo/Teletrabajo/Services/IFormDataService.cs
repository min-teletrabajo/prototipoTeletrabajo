using System;
using System.Collections.Generic;
using System.Text;
using Teletrabajo.DbModels;

namespace Teletrabajo.Services
{
    public interface IFormDataService
    {
        List<FormData> GetAllFormData();
    }
}
