using System;
using System.Collections.Generic;
using System.Text;
using Teletrabajo.Models;

namespace Teletrabajo.Repositorios
{
    public interface IFormDataRepository
    {
        List<FormData> GetAllFormData();
    }
}
