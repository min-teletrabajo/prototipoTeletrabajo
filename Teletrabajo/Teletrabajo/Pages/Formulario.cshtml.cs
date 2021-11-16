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
            InitializeModel();
        }


        private async void InitializeModel()
        {
            //var cuil = TempData["Cuil"].ToString();
            FormularioVM = new FormularioVM();


            FormularioVM.RepresentanteLegal = await representanteRepository.GetRepresentanteAsync("20388240558");
            FormularioVM.Trabajadores = await trabajadorRepository.GetAllTrabajadores();
            FormularioVM.Empresas = await empresaRepository.GetAllEmpresas();
        }

        public async Task OnGet()
        {
            //var cuil = TempData["Cuil"].ToString();
            //FormularioVM = new FormularioVM()
            //{
            //    RepresentanteLegal = await representanteRepository.GetRepresentanteAsync(cuil),
            //    Trabajadores = await trabajadorRepository.GetAllTrabajadores(),
            //    Empresas = await empresaRepository.GetAllEmpresas()

            //};
        }
        public async Task<ActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                FormularioVM.Trabajadores[0].Domicilio.Calle = "Algo";
                FormularioVM.Trabajadores[0].Domicilio.Altura = "Otro";

                return RedirectToPage("/Privacy");
            }
            return RedirectToPage("/Error");
            
        }
    }
}
