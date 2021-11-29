using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SvcCPA;
using Teletrabajo.Models;

namespace Teletrabajo.Services.CPA
{
    public interface ICPAService
    {
		Task<Calle[]> ObtenerCalles(string provincia, string localidad, string q);

		Task<Provincia[]> ObtenerProvincias(string nombre);

		Task<Partido[]> ObtenerPartidos(string provincia, string search);

		Task<Localidad[]> ObtenerLocalidades(string provincia, string search);
		Task<Localidad[]> ObtenerLocalidadesPorPartido(string provincia, string partido, string search);

		Task<Localidad[]> ObtenerLocalidadesConPartido(string provincia, string search);

		Task<DireccionDto> ObtenerCPA(string provincia, string localidad, string calle, string altura);
	}
}
