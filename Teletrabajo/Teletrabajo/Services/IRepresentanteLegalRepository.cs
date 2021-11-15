using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teletrabajo.Models;

namespace Teletrabajo.Services
{
    public interface IRepresentanteLegalRepository
    {
        List<RepresentanteLegal> GetAllRepresentantes();
    }
}
