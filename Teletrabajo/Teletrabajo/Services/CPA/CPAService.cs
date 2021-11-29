using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DGIIT.Integration.WSCPA;
using Teletrabajo.Models;
using Microsoft.Extensions.Options;
using SvcCPA;

namespace Teletrabajo.Services.CPA
{
    public class CPAService : ICPAService
    {
		private readonly CPAOptions options;
		private WSCPAClient cpaClient;

		private WSCPAClient CpaClient
		{
			get
			{
				return LazyInitializer.EnsureInitialized(ref this.cpaClient,
					() => new WSCPAClient(options.WSUrl, options.Credential));
			}
		}

		public CPAService(IOptions<CPAOptions> options)
		{
			this.options = options.Value;
		}

		public Task<Provincia[]> ObtenerProvincias(string nombre)
		{
			return Task.Run(() =>
			{
				var provincias = CpaClient.ObtenerProvincias(nombre);
				return provincias.Select(ToProvinciaEntidad).ToArray();
			});
		}

		public async Task<Partido[]> ObtenerPartidos(string provincia, string search)
		{
			var partidos = await CpaClient.ObtenerPartidos(provincia, search);
			return partidos.Select(ToPartidoEntidad).ToArray();
		}

		public async Task<Localidad[]> ObtenerLocalidades(string provincia, string nombre)
		{
			var localidades = await CpaClient.ObtenerLocalidades(provincia, nombre);
			return localidades.Select(ToLocalidadEntidad).ToArray();
		}

		public async Task<Localidad[]> ObtenerLocalidadesPorPartido(string provincia, string partido, string nombre)
		{
			var localidades = new List<Localidad>();
			var localidadesPartido = await CpaClient.ObtenerLocalidadesPorPartido(provincia, partido, nombre);

			foreach (var localidad in localidadesPartido)
			{
				localidades.Add(ToLocalidadConPartidoEntidad(localidad.Localidad, localidad.Partido));
			}

			return localidades.ToArray();
		}

		public async Task<Localidad[]> ObtenerLocalidadesConPartido(string provincia, string nombre)
		{
			var localidades = new List<Localidad>();
			var localidadesPartido = await CpaClient.ObtenerLocalidadesConPartido(provincia, nombre);

			foreach (var localidad in localidadesPartido)
			{
				localidades.Add(ToLocalidadConPartidoEntidad(localidad.Localidad, localidad.Partido));
			}

			return localidades.ToArray();
		}

		public async Task<Calle[]> ObtenerCalles(string provincia, string localidad, string search)
		{
			var calles = await CpaClient.ObtenerCalles(provincia, localidad, search);
			return calles.Select(ToCalleEntidad).ToArray();
		}

		public async Task<DireccionDto> ObtenerCPA(string provincia, string localidad, string calle, string altura)
		{
			return await CpaClient.ObtenerCPA(provincia, localidad, calle, altura);
		}

		private Provincia ToProvinciaEntidad(string descripcion)
		{
			return
				new Provincia { Descripcion = descripcion };
		}

		private Partido ToPartidoEntidad(string descripcion)
		{
			return
				new Partido { Descripcion = descripcion };
		}

		private Localidad ToLocalidadEntidad(string descripcion)
		{
			return
				new Localidad { Descripcion = descripcion };
		}

		private Localidad ToLocalidadConPartidoEntidad(string descripcion, string partido)
		{
			return
				new Localidad { Descripcion = descripcion, Partido = partido };
		}

		private Calle ToCalleEntidad(string descripcion)
		{
			return
				new Calle { Descripcion = descripcion };
		}
	}
}
