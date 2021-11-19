using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Teletrabajo.FormModels;
using Teletrabajo.Models;
using Teletrabajo.Repositorios;
using Teletrabajo.ViewModels;
using Teletrabajo.Services;

namespace Teletrabajo.Pages
{
    public class FormularioModel : PageModel
    {
        public readonly Teletrabajo.Models.TeletrabajoBaseDeDatosContext _db;


        public readonly ITrabajadorRepository trabajadorRepository;
        public readonly IRepresentanteLegalRepository representanteRepository;
        public readonly IEmpresaRepository empresaRepository;

        public readonly Teletrabajo.Services.IFormDataService _formsDataService;

        [BindProperty]
        public FormularioVM FormularioVM { get; set; }
        public List<Pais> PaisesList { get; set; }


        public FormularioModel(IFormDataRepository formDataRepository, Teletrabajo.Models.TeletrabajoBaseDeDatosContext db,
            ITrabajadorRepository trabajadorRepository, IRepresentanteLegalRepository representanteRepository,
            IEmpresaRepository empresaRepository, Teletrabajo.Services.IFormDataService formsDataService)
        {
            _db = db;
            this.trabajadorRepository = trabajadorRepository;
            this.representanteRepository = representanteRepository;
            this.empresaRepository = empresaRepository;
            _formsDataService = formsDataService;
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
                //Paises = PaisesList.Select(p => new SelectListItem {
                //    Value = p.Descripcion,
                //    Text = p.Descripcion
                //}).ToList()

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
            
           
            var form = FormularioVM;

            bool isValid = Validations(FormularioVM);

            if (!isValid)
            {
                
            }



            DataFormulario dataFormulario = new DataFormulario()
            {
                Representante = FormularioVM.RepresentanteLegal,
                Trabajadores = FormularioVM.Trabajadores,
                Empresas = FormularioVM.Empresas
            };

            //var formdata = await StoreFormData();               

            return Page();
           

            //return Page();

            

            //string formSerializado = JsonSerializer.Serialize<DataFormulario>(dataFormulario);

            //string formSerialziado = SerializeModel(dataFormulario);



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

            //FormData formData = new FormData()
            //{
            //    Id = Guid.NewGuid(),
            //    Data = formSerializado,
            //    Version = "V1",
            //    EstadoTramiteId = 2,
            //    FormId = 1,
            //    UsuarioId = "10001",
            //    FechaCreacion = DateTime.Now,
            //    NumeroTramite = new Random().Next(1,1000),
            //};

            //Adjunto adjunto = new Adjunto()
            //{
            //    Id = 1,
            //    NombreArchivo = "PdfAdjunto",
            //    Metadata = "Metadata1"
            //};

            //this._db.Sistema.Add(sistema);
            //this._db.Form.Add(form);
            //this._db.FormData.Add(formData);

            //await this._db.SaveChangesAsync();


            
        }

        private string SerializeModel(FormularioVM model)
        {
            return JsonSerializer.Serialize(model);
        }

        private async Task<FormData> StoreFormData()
        {
            var formData = new FormData
            {
                FormId = 1,
                Version = "V1",
                UsuarioId = "1001",
                FechaCreacion = DateTime.Now,
                Data = SerializeModel(FormularioVM),
                NumeroTramite = new Random().Next(1, 1000)
            };
            await _formsDataService.Post(formData);

            return formData;
        }

        private bool Validations(FormularioVM model)
        {
            bool isValid = true;

            for (int i = 0; i < model.Trabajadores.Count; i++)
            {
                if (string.IsNullOrEmpty(model.Trabajadores[i].Domicilio.Provincia) && model.Trabajadores[i].Teletrabajo == true && model.Trabajadores[i].Pais == "Argentina")
                {
                    ModelState.AddModelError("FormularioVM.Trabajadores[" + i.ToString() + "].Domicilio.Provincia", "Debe ingresar la provincia");
                    isValid = false;
                }

                if (string.IsNullOrEmpty(model.Trabajadores[i].Domicilio.Partido) && model.Trabajadores[i].Teletrabajo == true && model.Trabajadores[i].Pais == "Argentina")
                {
                    ModelState.AddModelError("FormularioVM.Trabajadores[" + i.ToString() + "].Domicilio.Partido", "Debe ingresar el partido");
                    isValid = false;
                }

                if (string.IsNullOrEmpty(model.Trabajadores[i].Domicilio.Localidad) && model.Trabajadores[i].Teletrabajo == true && model.Trabajadores[i].Pais == "Argentina")
                {
                    ModelState.AddModelError("FormularioVM.Trabajadores[" + i.ToString() + "].Domicilio.Localidad", "Debe ingresar la localidad");
                    isValid = false;
                }
                if (string.IsNullOrEmpty(model.Trabajadores[i].Domicilio.Calle) && model.Trabajadores[i].Teletrabajo == true && model.Trabajadores[i].Pais == "Argentina")
                {
                    ModelState.AddModelError("FormularioVM.Trabajadores[" + i.ToString() + "].Domicilio.Calle", "Debe ingresar la calle");
                    isValid = false;
                }

                if (string.IsNullOrEmpty(model.Trabajadores[i].Domicilio.Altura) && model.Trabajadores[i].Teletrabajo == true && model.Trabajadores[i].Pais == "Argentina")
                {
                    ModelState.AddModelError("FormularioVM.Trabajadores[" + i.ToString() + "].Domicilio.Altura", "Debe ingresar la altura");
                    isValid = false;
                }
                


            }

            return isValid;

        }


    }
}
