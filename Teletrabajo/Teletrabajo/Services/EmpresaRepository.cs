using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teletrabajo.Models;

namespace Teletrabajo.Services
{
    public class EmpresaRepository : IEmpresaRepository
    {
        public List<Empresa> _empresaList { get; set; }

        public EmpresaRepository()
        {
            _empresaList = new List<Empresa>()
            {
                new Empresa() { Cuit = "25684598", RazonSocial = "Sociedad Anonima", Actividad = "Ventas", DomicilioFiscal = "Burzaco" }
            };
        }
        public async Task<List<Empresa>> GetAllEmpresas()
        {
            return await Task.FromResult(_empresaList);
        }
    }
}
