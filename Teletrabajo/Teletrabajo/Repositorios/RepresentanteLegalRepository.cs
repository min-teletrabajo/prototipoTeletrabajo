using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teletrabajo.FormModels;

namespace Teletrabajo.Repositorios
{
    public class RepresentanteLegalRepository: IRepresentanteLegalRepository
    {
        public List<RepresentanteLegal> _representanteLegalList { get; set; }

        public RepresentanteLegalRepository()
        {
            _representanteLegalList = new List<RepresentanteLegal>()
            {
                new RepresentanteLegal(){Nombre = "Javier", Apellido = "Mendoza", Cuil = "20388240558", CorreoElectronicoLaboral = "jmendoza@gmail.com", TelefonoCelular = "1168540559"}
            };
        }

        public async Task<List<RepresentanteLegal>> GetAllRepresentantes()
        {
            return await Task.FromResult(_representanteLegalList);
        }

        public async Task<RepresentanteLegal> GetRepresentanteAsync(string cuil)
        {
            var representante = _representanteLegalList.Where(rep => rep.Cuil == cuil).SingleOrDefault();
            return await Task.FromResult(representante);
        }
    }
}
