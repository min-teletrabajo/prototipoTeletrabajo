using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Teletrabajo.DbModels;
using Teletrabajo.Models;
using Teletrabajo.Services;
using Teletrabajo.ViewModels;

namespace Teletrabajo.Pages
{
    public class FormularioModel : PageModel
    {
        public readonly TeletrabajoBaseDeDatosContext _db;


        public readonly ITrabajadorRepository trabajadorRepository;
        public readonly IRepresentanteLegalRepository representanteRepository;
        public readonly IEmpresaRepository empresaRepository;

        [BindProperty]
        public FormularioVM FormularioVM { get; set; }
        public List<Pais> PaisesList { get; set; }


        public FormularioModel(IFormDataService formDataRepository, TeletrabajoBaseDeDatosContext db,
            ITrabajadorRepository trabajadorRepository, IRepresentanteLegalRepository representanteRepository,
            IEmpresaRepository empresaRepository)
        {
            _db = db;
            this.trabajadorRepository = trabajadorRepository;
            this.representanteRepository = representanteRepository;
            this.empresaRepository = empresaRepository;
            InitializeModel();
        }

        private async void InitializeModel()
        {
            PaisesList = new List<Pais>()
            {
                new Pais(){Descripcion = "Argentina"},
                new Pais(){Descripcion = "Brasil"},
                new Pais(){Descripcion = "Uruguay"}
            };


            FormularioVM = new FormularioVM()
            {
                RepresentanteLegal = await representanteRepository.GetRepresentanteAsync("20388240558"),
                Trabajadores = await trabajadorRepository.GetAllTrabajadores(),
                Empresas = await empresaRepository.GetAllEmpresas(),
                Paises = PaisesList.Select(p => new SelectListItem {
                    Value = p.Descripcion,
                    Text = p.Descripcion
                }).ToList()

            };
        }

        public async Task<ActionResult> OnGet()
        {
            //var cuil = TempData["Cuil"].ToString();
            //FormularioVM = new FormularioVM()
            //{
            //    RepresentanteLegal = await representanteRepository.GetRepresentanteAsync(cuil),
            //    Trabajadores = await trabajadorRepository.GetAllTrabajadores(),
            //    Empresas = await empresaRepository.GetAllEmpresas()

            //};

            return Page();
           
           
        }

        public async Task<ActionResult> OnPost()
        {
            //var form = FormularioVM;
            //if (ModelState.IsValid)
            //{
            //    return RedirectToPage("/Privacy");
            //}

            //return Page();

            var form = FormularioVM;


            DataFormulario dataFormulario = new DataFormulario()
            {
                Representante = FormularioVM.RepresentanteLegal,
                Trabajadores = FormularioVM.Trabajadores,
                Empresas = FormularioVM.Empresas
            };

            string formSerializado = JsonSerializer.Serialize<DataFormulario>(dataFormulario);

            //Sistema sistema = new Sistema()
            //{
            //    Id = 1,
            //    Nombre = "Teletrabajo",
            //    Descripcion = "No se"
            //};

            //Form form = new Form()
            //{
            //    Id = 1,
            //    SistemaId = 1,
            //    Nombre = "Form 1",
            //    Titulo = "Teletrabajo",
            //    VersionActual = "1",
            //    Habilitado = true,
            //    Descripcion = "Form Teletrabajo"

            //};

            FormData formData = new FormData()
            {
                Id = Guid.NewGuid(),
                Data = formSerializado,
                Version = "V1",
                EstadoTramiteId = 2,
                FormId = 1,
                UsuarioId = "10001",
                FechaCreacion = DateTime.Now,
                NumeroTramite = new Random().Next(1,1000),
            };

            //Adjunto adjunto = new Adjunto()
            //{
            //    Id = 1,
            //    NombreArchivo = "PdfAdjunto",
            //    Metadata = "Metadata1"
            //};

            //this._db.Sistema.Add(sistema);
            //this._db.Form.Add(form);
            this._db.FormData.Add(formData);

            await this._db.SaveChangesAsync();

            return Page();
        }
    }
}
