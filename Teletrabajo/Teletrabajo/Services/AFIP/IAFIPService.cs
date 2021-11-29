using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DGIIT.Integration.WSAfip.NetCore;

namespace Teletrabajo.Services.AFIP
{
    public interface IAFIPService
    {
        SrvAfip.EmpresaBase GetEmpresaByCUIT(string cuit);

    }
}
