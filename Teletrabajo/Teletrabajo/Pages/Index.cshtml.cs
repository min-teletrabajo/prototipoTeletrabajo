using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teletrabajo.Models;
using Teletrabajo.Services;

namespace Teletrabajo.Pages
{
    public class IndexModel : PageModel
    {
        public readonly IFormDataService formDataRepository;
        public readonly ITrabajadorRepository trabajadorRepository;
        public readonly IRepresentanteLegalRepository representanteRepository;
        public List<FormData> FormDatas { get; set; }
        public List<Trabajador> Trabajadores { get; set; }
        public List<RepresentanteLegal> Representantes { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IFormDataService formDataRepository, ITrabajadorRepository trabajadorRepository, IRepresentanteLegalRepository representanteRepository)
        {
            _logger = logger;
            this.formDataRepository = formDataRepository;
            this.trabajadorRepository = trabajadorRepository;
            this.representanteRepository = representanteRepository;
        }

        public void OnGet()
        {
            FormDatas = formDataRepository.GetAllFormData();
            Trabajadores = trabajadorRepository.GetAllTrabajadores();
            Representantes = representanteRepository.GetAllRepresentantes();
        }
    }
}
