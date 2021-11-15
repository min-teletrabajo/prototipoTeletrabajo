using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Teletrabajo.Services;
using Teletrabajo.ViewModels;

namespace Teletrabajo.Pages
{
    public class FormularioModel : PageModel
    {
        public readonly ITrabajadorRepository trabajadorRepository;
        public readonly IRepresentanteLegalRepository representanteRepository;
        public readonly IEmpresaRepository empresaRepository;

        public FormularioVM FormularioVM { get; set; }

        public FormularioModel(IFormDataService formDataRepository,
            ITrabajadorRepository trabajadorRepository, IRepresentanteLegalRepository representanteRepository,
            IEmpresaRepository empresaRepository)
        {
            this.trabajadorRepository = trabajadorRepository;
            this.representanteRepository = representanteRepository;
            this.empresaRepository = empresaRepository;
        }

        public async Task OnGet()
        {
            var cuil = TempData["Cuil"].ToString();
            FormularioVM = new FormularioVM()
            {
                RepresentanteLegal = await representanteRepository.GetRepresentanteAsync(cuil),
                Trabajadores = await trabajadorRepository.GetAllTrabajadores(),
                Empresas = await empresaRepository.GetAllEmpresas()

            };
        }
    }
}
