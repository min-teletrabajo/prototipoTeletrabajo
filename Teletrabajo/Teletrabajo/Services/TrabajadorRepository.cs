using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teletrabajo.Models;

namespace Teletrabajo.Services
{
    public class TrabajadorRepository : ITrabajadorRepository
    {
        public List<Trabajador> _trabajadoresList { get; set; }

        public TrabajadorRepository()
        {
            _trabajadoresList = new List<Trabajador>()
            {
                new Trabajador(){Nombre = "Jorge", Apellido = "Ibañez", Cuil = "2034561258",Genero = "Masculino", AdheridoConvenioColectivoTrabajo = "Si", Categoria = "Operario", Puesto = "Jefe", ModalidadContratacion = "Jornada Completa", ObraSocial = "Swiss Medical", Art = "Prevencion ART", FechaClaveAltaTemprana = DateTime.Now, AdheridoEntidadGremial = "No",Domicilio = new Domicilio() },
                new Trabajador(){Nombre = "Maria", Apellido = "Fernandez", Cuil = "21566547878",Genero = "Femenino", AdheridoConvenioColectivoTrabajo = "Si", Categoria = "Tecnico", Puesto = "Empleado", ModalidadContratacion = "Jornada Completa", ObraSocial = "Sancor Salud", Art = "SMG ART", FechaClaveAltaTemprana = DateTime.Now,AdheridoEntidadGremial = "Si",Domicilio = new Domicilio() },

            };
        }

        public async Task<List<Trabajador>> GetAllTrabajadores()
        {
            return await Task.FromResult(_trabajadoresList);
        }
    }
}
