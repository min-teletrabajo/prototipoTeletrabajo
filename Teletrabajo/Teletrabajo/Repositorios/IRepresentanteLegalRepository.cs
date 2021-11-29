using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teletrabajo.FormModels;

namespace Teletrabajo.Repositorios
{
    public interface IRepresentanteLegalRepository
    {
        Task<List<RepresentanteLegal>> GetAllRepresentantes();
        Task<RepresentanteLegal> GetRepresentanteAsync(string cuil);
    }
}
