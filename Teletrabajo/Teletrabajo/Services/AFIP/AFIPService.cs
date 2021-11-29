using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DGIIT.Integration.WSAfip.NetCore;
using Microsoft.Extensions.Options;


namespace Teletrabajo.Services.AFIP
{
    public class AFIPService : IAFIPService
	{
		private readonly AFIPOptions options;

		private SrvAfip.WSAfipClient AfipClient
		{
			get
			{
				return WSAfipClient.GetClient(options.WSUrl, options.Credential);
			}
		}

		public AFIPService(IOptions<AFIPOptions> options)
		{
			this.options = options.Value;
		}

		public SrvAfip.EmpresaBase GetEmpresaByCUIT(string cuit)
		{
			if (string.IsNullOrWhiteSpace(cuit))
				return null;

			var empresaDTO = AfipClient.GetEmpresaByCUIT(cuit, 0);

			return empresaDTO;
		}
	}
}
