using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teletrabajo.DbModels;
using Teletrabajo.Models;
using Teletrabajo.Services;

namespace Teletrabajo.Pages
{
    public class IndexModel : PageModel
    {
        public readonly IFormDataService formDataRepository;
        public readonly ITrabajadorRepository trabajadorRepository;
        public readonly IRepresentanteLegalRepository representanteRepository;
        public readonly IEmpresaRepository empresaRepository;

        public List<FormData> FormDatas { get; set; }
        public List<Trabajador> Trabajadores { get; set; }
        public List<RepresentanteLegal> Representantes { get; set; }
        public RepresentanteLegal Representante { get; set; }
        public string Cuil { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IFormDataService formDataRepository,
            ITrabajadorRepository trabajadorRepository, IRepresentanteLegalRepository representanteRepository, IEmpresaRepository empresaRepository)
        {
            _logger = logger;
            this.formDataRepository = formDataRepository;
            this.trabajadorRepository = trabajadorRepository;
            this.representanteRepository = representanteRepository;
            this.empresaRepository = empresaRepository;
        }

        public async void OnGet()
        {
            FormDatas = formDataRepository.GetAllFormData();
            //Trabajadores = await trabajadorRepository.GetAllTrabajadores();
            Representantes = await representanteRepository.GetAllRepresentantes();
        }

        public async Task<ActionResult> OnPost(string cuil)
        {
            Representante = await representanteRepository.GetRepresentanteAsync(cuil);

            if (Representante != null)
            {
                TempData["Cuil"] = cuil;
                return RedirectToPage("/Formulario");
            }
            return RedirectToPage("/Error");
        }
    }
}
