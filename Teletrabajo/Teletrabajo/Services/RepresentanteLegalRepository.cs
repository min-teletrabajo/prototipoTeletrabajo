using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teletrabajo.Models;

namespace Teletrabajo.Services
{
    public class RepresentanteLegalRepository: IRepresentanteLegalRepository
    {
        public List<RepresentanteLegal> _representanteLegalList { get; set; }

        public RepresentanteLegalRepository()
        {
            _representanteLegalList = new List<RepresentanteLegal>()
            {
                new RepresentanteLegal(){Nombre = "Jorge", Apellido = "Ibañez", Cuil = "20388240558", CorreoElectronicoLaboral = "jmendoza@gmail.com", TelefonoCelular = "1168540559"}
            };
        }

        public List<RepresentanteLegal> GetAllRepresentantes()
        {
            return _representanteLegalList;
        }
    }
}
