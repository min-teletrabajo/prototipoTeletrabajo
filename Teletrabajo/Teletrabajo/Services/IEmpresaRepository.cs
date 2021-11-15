using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teletrabajo.Models;

namespace Teletrabajo.Services
{
    public interface IEmpresaRepository
    {
        Task<List<Empresa>> GetAllEmpresas();
    }

}
