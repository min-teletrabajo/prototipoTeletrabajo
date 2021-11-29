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
using Microsoft.Extensions.Logging;
using Teletrabajo.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using CsvHelper;
using System.Globalization;
using System.Text;
using CsvHelper.Configuration;
using Teletrabajo.Services.AFIP;
using Teletrabajo.Services.CPA;

namespace Teletrabajo.Pages
{
    public class FormularioModel : PageModel
    {
        public readonly Teletrabajo.Models.TeletrabajoBaseDeDatosContext _db;

        private readonly ILogger<FormularioModel> _logger;


        public readonly ITrabajadorRepository trabajadorRepository;
        public readonly IRepresentanteLegalRepository representanteRepository;
        public readonly IEmpresaRepository empresaRepository;

        public readonly Teletrabajo.Services.IFormDataService _formsDataService;
        public readonly IAFIPService _afipService;
        public readonly ICPAService _cpaService;

        [BindProperty]
        public FormularioVM FormularioVM { get; set; }
        public List<Pais> PaisesList { get; set; }

        [BindProperty]
        public string SuccessMessage { get; set; }

        [BindProperty]
        public bool Succeeded { get; set; }

        [BindProperty]
        public string ErrorMessage { get; set; }
        [BindProperty]
        public IFormFile ArchivoCsv { get; set; }

        public FormularioModel(ILogger<FormularioModel> logger, IFormDataRepository formDataRepository, Teletrabajo.Models.TeletrabajoBaseDeDatosContext db,
            ITrabajadorRepository trabajadorRepository, IRepresentanteLegalRepository representanteRepository,
            IEmpresaRepository empresaRepository, Teletrabajo.Services.IFormDataService formsDataService, IAFIPService afipService, ICPAService cpaService)
        {
            _db = db;
            _logger = logger;
            this.trabajadorRepository = trabajadorRepository;
            this.representanteRepository = representanteRepository;
            this.empresaRepository = empresaRepository;
            _formsDataService = formsDataService;
            _afipService = afipService;
            _cpaService = cpaService;

            InitializeModel();
        }

        private async void InitializeModel()
        {
           

            FormularioVM = new FormularioVM()
            {
                RepresentanteLegal = await representanteRepository.GetRepresentanteAsync("20388240558"),
                Trabajadores = await trabajadorRepository.GetAllTrabajadores(),
                Empresas = await empresaRepository.GetAllEmpresas(),
                
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

            //FormularioVM = new FormularioVM()
            //{
            //    RepresentanteLegal = await representanteRepository.GetRepresentanteAsync("20388240558"),
            //    Trabajadores = await trabajadorRepository.GetAllTrabajadores(),
            //    Empresas = await empresaRepository.GetAllEmpresas(),

            //};

            return Page();
           
           
        }

      

        public async Task<ActionResult> OnPostGuardarBorrador()
        {
            return await Guardar(EstadoTramite.Borrador);
        }

        public async Task<ActionResult> OnPostEnviar()
        {
            return await Guardar(EstadoTramite.PendienteDeRecepcion);
        }

        public async Task<ActionResult> Guardar(EstadoTramite estado)
        {
            try
            {
                //var archivo = ArchivoCsv;


                //var trabajadoresDTO = Validations(ObtenerTrabajadores(ArchivoCsv));
                var trabajadoresDTO = ObtenerTrabajadores(ArchivoCsv);
                FormularioVM.Trabajadores = await TransformarTrabajadores(trabajadoresDTO);
                var form = FormularioVM;

                //bool isValid = Validations(ObtenerTrabajadores(ArchivoCsv));

                //if (!isValid)
                //{
                //    ErrorMessage = "El formulario no paso las validaciones";
                //    return Page();
                //}

                var formdata = await StoreFormData(estado);



                SuccessMessage = "Formulario Enviado Exitosamente.";
                Succeeded = true;

            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                ErrorMessage = string.Format("Ha ocurrido un error: {0}", ex.Message);
                
            }
            
            return Page();

        }
        /// <summary>
        /// Serializa el Viewmodel que trae el Post
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        private string SerializeModel(FormularioVM model)
        {
            return JsonSerializer.Serialize(model);
        }

        /// <summary>
        /// Crea un formdata, serializa los datos del view model del formulario
        /// y llama al servicio Post de formData para guardar los datos en la base
        /// </summary>
        /// <returns></returns>
        private async Task<FormData> StoreFormData(EstadoTramite estado)
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
            await _formsDataService.Post(formData,estado);

            return formData;
        }

        public async Task<ActionResult> OnPostDescargarCsv()
        {
            List<TrabajadorDTO> trabajadores = await ObtenerTrabajadoresDTO();

            var config = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                //Cambiar ";" por "," si hay problemas con el excel
                Delimiter = ","
            };

            var path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot"}";
            using (var write = new StreamWriter(path + "\\Trabajadores.csv"))
            using (var csv = new CsvWriter(write, config))
            {
                csv.Context.RegisterClassMap<TrabajadorMap>();
                csv.WriteHeader<TrabajadorDTO>(); // write headers
                csv.WriteField(""); // it will be `;` in file
                csv.NextRecord();
                foreach (var item in trabajadores)
                {
                    csv.WriteRecord(item); // actual data 
                    csv.WriteField(""); // it will be `;` in file
                    csv.NextRecord();
                }
                //csv.WriteRecords(trabajadores);
            }
            var fs = new FileStream(path + "\\Trabajadores.csv", FileMode.Open, FileAccess.Read, FileShare.None, 4096, FileOptions.DeleteOnClose);
            return File(fileStream: fs, contentType: "application/octet-stream", fileDownloadName: "NominaDeTrabajadores.csv");          
        }


        private List<TrabajadorDTO> ObtenerTrabajadores(IFormFile file)
        {
            List<TrabajadorDTO> trabajadores = new List<TrabajadorDTO>();
            var config = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                //Cambiar ";" por "," si hay problemas con el excel
                Delimiter = ",",
                MissingFieldFound = null
            };
            #region Leer CSV
            //var path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + filename;
            using (var reader = new StreamReader(file.OpenReadStream()))
            using (var csv = new CsvReader(reader, config))
            {             
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var trabajador = csv.GetRecord<TrabajadorDTO>();
                    trabajadores.Add(trabajador);
                }
            }

            return trabajadores;
            #endregion

        }


        private async Task<List<TrabajadorDTO>> ObtenerTrabajadoresDTO()
        {
            List<TrabajadorDTO> trabajadoresDTO = new List<TrabajadorDTO>();
            var trabajadores = await trabajadorRepository.GetAllTrabajadores();

            for (int i = 0; i < trabajadores.Count; i++)
            {
                TrabajadorDTO trbj = new TrabajadorDTO()
                {
                    CuitEmpleador = trabajadores[i].CuitEmpleador,
                    RazonSocial = trabajadores[i].RazonSocial,
                    Cuil = trabajadores[i].Cuil,
                    Apellido = trabajadores[i].Apellido,
                    Nombre = trabajadores[i].Nombre,                 
                };
                trabajadoresDTO.Add(trbj);
            }

            return trabajadoresDTO;
        }

        private async Task<List<Trabajador>> TransformarTrabajadores(List<TrabajadorDTO> trabajadoresDTO)
        {
            //List<Trabajador> trabajadores = new List<Trabajador>();
            var trabajadores = await trabajadorRepository.GetAllTrabajadores();

            for (int i = 0; i < trabajadores.Count; i++)
            {
                //TrabajadorDTO trbj = new TrabajadorDTO()
                //{
                //    CuitEmpleador = trabajadores[i].CuitEmpleador,
                //    RazonSocial = trabajadores[i].RazonSocial,
                //    Cuil = trabajadores[i].Cuil,
                //    Apellido = trabajadores[i].Apellido,
                //    Nombre = trabajadores[i].Nombre,
                //};
                //trabajadoresDTO.Add(trbj);
                trabajadores[i].Teletrabajador = trabajadoresDTO[i].Teletrabajador;
                //trabajadores[i].FechaInicioTeletrabajo = trabajadoresDTO[i].FechaInicioTeletrabajo;
                trabajadores[i].ModalidadDeTrabajo = trabajadoresDTO[i].ModalidadDeTrabajo;
                //trabajadores[i].FechaDeContrato = trabajadoresDTO[i].FechaDeContrato;
                trabajadores[i].Voluntariedad = trabajadoresDTO[i].Voluntariedad;
                //trabajadores[i].FechaDeVoluntariedad = trabajadoresDTO[i].FechaDeVoluntariedad;
                trabajadores[i].Pais = trabajadoresDTO[i].Pais;
                trabajadores[i].Domicilio.Provincia = trabajadoresDTO[i].Provincia;
                trabajadores[i].Domicilio.Partido = trabajadoresDTO[i].Partido;
                trabajadores[i].Domicilio.Localidad = trabajadoresDTO[i].Localidad;
                trabajadores[i].Domicilio.Calle = trabajadoresDTO[i].Calle;
                trabajadores[i].Domicilio.Altura = trabajadoresDTO[i].Altura;
                trabajadores[i].Domicilio.Piso = trabajadoresDTO[i].Piso;
                trabajadores[i].Domicilio.Departamento = trabajadoresDTO[i].Departamento;
                trabajadores[i].Domicilio.CodigoPostal = trabajadoresDTO[i].CodigoPostal;
                trabajadores[i].JornadaLaboral_Lunes = trabajadoresDTO[i].JornadaLaboral_Lunes;
                trabajadores[i].JornadaLaboral_HorarioLunesDesde = trabajadoresDTO[i].JornadaLaboral_HorarioLunesDesde;
                trabajadores[i].JornadaLaboral_HorarioLunesHasta = trabajadoresDTO[i].JornadaLaboral_HorarioLunesHasta;
                trabajadores[i].JornadaLaboral_Martes = trabajadoresDTO[i].JornadaLaboral_Martes;
                trabajadores[i].JornadaLaboral_HorarioMartesDesde = trabajadoresDTO[i].JornadaLaboral_HorarioMartesDesde;
                trabajadores[i].JornadaLaboral_HorarioMartesHasta = trabajadoresDTO[i].JornadaLaboral_HorarioMartesHasta;
                trabajadores[i].JornadaLaboral_Miercoles = trabajadoresDTO[i].JornadaLaboral_Miercoles;
                trabajadores[i].JornadaLaboral_HorarioMiercolesDesde = trabajadoresDTO[i].JornadaLaboral_HorarioMiercolesHasta;
                trabajadores[i].JornadaLaboral_HorarioMiercolesHasta = trabajadoresDTO[i].JornadaLaboral_HorarioMiercolesHasta;
                trabajadores[i].JornadaLaboral_Jueves = trabajadoresDTO[i].JornadaLaboral_Jueves;
                trabajadores[i].JornadaLaboral_HorarioJuevesDesde = trabajadoresDTO[i].JornadaLaboral_HorarioJuevesDesde;
                trabajadores[i].JornadaLaboral_HorarioJuevesHasta = trabajadoresDTO[i].JornadaLaboral_HorarioJuevesHasta;
                trabajadores[i].JornadaLaboral_Viernes = trabajadoresDTO[i].JornadaLaboral_Viernes;
                trabajadores[i].JornadaLaboral_HorarioViernesDesde = trabajadoresDTO[i].JornadaLaboral_HorarioViernesDesde;
                trabajadores[i].JornadaLaboral_HorarioViernesHasta = trabajadoresDTO[i].JornadaLaboral_HorarioViernesHasta;
                trabajadores[i].JornadaLaboral_Sabados = trabajadoresDTO[i].JornadaLaboral_Sabados;
                trabajadores[i].JornadaLaboral_HorarioSabadosDesde = trabajadoresDTO[i].JornadaLaboral_HorarioSabadosDesde;
                trabajadores[i].JornadaLaboral_HorarioSabadosHasta = trabajadoresDTO[i].JornadaLaboral_HorarioSabadosHasta;
                trabajadores[i].JornadaLaboral_Domingos = trabajadoresDTO[i].JornadaLaboral_Domingos;
                trabajadores[i].JornadaLaboral_HorarioDomingosDesde = trabajadoresDTO[i].JornadaLaboral_HorarioDomingosDesde;
                trabajadores[i].JornadaLaboral_HorarioDomingosHasta = trabajadoresDTO[i].JornadaLaboral_HorarioDomingosHasta;
                trabajadores[i].CargaHorariaMensual = trabajadoresDTO[i].CargaHorariaMensual;
                trabajadores[i].CorreoElectronicoLaboral = trabajadoresDTO[i].CorreoElectronicoLaboral;

            }
            return trabajadores;

        }

        private bool Validations(List<TrabajadorDTO> trabajadores)
        {
            bool isValid = true;

            for (int i = 0; i < trabajadores.Count; i++)
            {
                if (string.IsNullOrEmpty(trabajadores[i].Teletrabajador))
                {
                    isValid = false;
                }
                if (string.IsNullOrEmpty(trabajadores[i].FechaInicioTeletrabajo))
                {
                    isValid = false;
                }
                if (string.IsNullOrEmpty(trabajadores[i].ModalidadDeTrabajo))
                {
                    isValid = false;
                }
                if (string.IsNullOrEmpty(trabajadores[i].FechaDeContrato))
                {
                    isValid = false;
                }
                if (string.IsNullOrEmpty(trabajadores[i].Voluntariedad) || (trabajadores[i].Voluntariedad != "Si" && trabajadores[i].Voluntariedad != "No"))
                {
                    isValid = false;
                }
                if (string.IsNullOrEmpty(trabajadores[i].FechaDeVoluntariedad))
                {
                    isValid = false;
                }
                if (string.IsNullOrEmpty(trabajadores[i].Pais))
                {
                    isValid = false;
                }
                if (string.IsNullOrEmpty(trabajadores[i].Provincia) && trabajadores[i].Pais == "Argentina")
                {
                    isValid = false;
                }
                if (trabajadores[i].Pais == "Argentina")
                {
                    if (string.IsNullOrEmpty(trabajadores[i].Partido))
                    {
                        isValid = false;
                    }
                    if (string.IsNullOrEmpty(trabajadores[i].Localidad))
                    {
                        isValid = false;
                    }
                    if (string.IsNullOrEmpty(trabajadores[i].Calle))
                    {
                        isValid = false;
                    }
                    if (string.IsNullOrEmpty(trabajadores[i].Altura))
                    {
                        isValid = false;
                    }
                    if (string.IsNullOrEmpty(trabajadores[i].CodigoPostal))
                    {
                        isValid = false;
                    }
                }


                if(trabajadores[i].Pais != "Argentina")
                {
                    if (!string.IsNullOrEmpty(trabajadores[i].Partido))
                    {
                        isValid = false;
                    }
                    if (!string.IsNullOrEmpty(trabajadores[i].Localidad))
                    {
                        isValid = false;
                    }
                    if (!string.IsNullOrEmpty(trabajadores[i].Calle))
                    {
                        isValid = false;
                    }
                    if (!string.IsNullOrEmpty(trabajadores[i].Altura))
                    {
                        isValid = false;
                    }
                    if (!string.IsNullOrEmpty(trabajadores[i].CodigoPostal))
                    {
                        isValid = false;
                    }
                    if (!string.IsNullOrEmpty(trabajadores[i].Piso))
                    {
                        isValid = false;
                    }
                    if (!string.IsNullOrEmpty(trabajadores[i].Departamento))
                    {
                        isValid = false;
                    }
                }

                if (!string.IsNullOrEmpty(trabajadores[i].JornadaLaboral_Lunes) && (trabajadores[i].JornadaLaboral_Lunes != "1" || trabajadores[i].JornadaLaboral_Lunes != "0"))
                {
                    isValid = false;
                }
                if (string.IsNullOrEmpty(trabajadores[i].JornadaLaboral_HorarioLunesDesde))
                {
                    isValid = false;
                }
                if (trabajadores[i].JornadaLaboral_Lunes == "0" && !string.IsNullOrEmpty(trabajadores[i].JornadaLaboral_HorarioLunesHasta))
                {
                    isValid = false;
                }
                if (string.IsNullOrEmpty(trabajadores[i].JornadaLaboral_Martes))
                {
                    isValid = false;
                }
                if (string.IsNullOrEmpty(trabajadores[i].JornadaLaboral_HorarioMartesDesde))
                {
                    isValid = false;
                }
                if (string.IsNullOrEmpty(trabajadores[i].JornadaLaboral_HorarioMartesHasta))
                {
                    isValid = false;
                }
                if (string.IsNullOrEmpty(trabajadores[i].JornadaLaboral_Miercoles))
                {
                    isValid = false;
                }
                if (string.IsNullOrEmpty(trabajadores[i].JornadaLaboral_HorarioMiercolesDesde))
                {
                    isValid = false;
                }
                if (string.IsNullOrEmpty(trabajadores[i].JornadaLaboral_HorarioMiercolesHasta))
                {
                    isValid = false;
                }
                if (string.IsNullOrEmpty(trabajadores[i].JornadaLaboral_Jueves))
                {
                    isValid = false;
                }
                if (string.IsNullOrEmpty(trabajadores[i].JornadaLaboral_HorarioJuevesDesde))
                {
                    isValid = false;
                }
                if (string.IsNullOrEmpty(trabajadores[i].JornadaLaboral_HorarioJuevesHasta))
                {
                    isValid = false;
                }
                if (string.IsNullOrEmpty(trabajadores[i].JornadaLaboral_Viernes))
                {
                    isValid = false;
                }
                if (string.IsNullOrEmpty(trabajadores[i].JornadaLaboral_HorarioViernesDesde))
                {
                    isValid = false;
                }
                if (string.IsNullOrEmpty(trabajadores[i].JornadaLaboral_HorarioViernesHasta))
                {
                    isValid = false;
                }
                if(string.IsNullOrEmpty(trabajadores[i].JornadaLaboral_Sabados))
                {
                    isValid = false;
                }
                if (string.IsNullOrEmpty(trabajadores[i].JornadaLaboral_HorarioSabadosDesde))
                {
                    isValid = false;
                }
                if (string.IsNullOrEmpty(trabajadores[i].JornadaLaboral_HorarioSabadosHasta))
                {
                    isValid = false;
                }
                if (string.IsNullOrEmpty(trabajadores[i].JornadaLaboral_Domingos))
                {
                    isValid = false;
                }
                if (string.IsNullOrEmpty(trabajadores[i].JornadaLaboral_HorarioDomingosDesde))
                {
                    isValid = false;
                }
                if (string.IsNullOrEmpty(trabajadores[i].JornadaLaboral_HorarioDomingosHasta))
                {
                    isValid = false;
                }

            }

            return isValid;
        }

        //private bool Validations(FormularioVM model)
        //{
        //    bool isValid = true;

        //    for (int i = 0; i < model.Trabajadores.Count; i++)
        //    {
        //        if (string.IsNullOrEmpty(model.Trabajadores[i].Domicilio.Provincia) && model.Trabajadores[i].Teletrabajo == true && model.Trabajadores[i].Pais == "Argentina")
        //        {
        //            ModelState.AddModelError("FormularioVM.Trabajadores[" + i.ToString() + "].Domicilio.Provincia", "Debe ingresar la provincia");
        //            isValid = false;
        //        }

        //        if (string.IsNullOrEmpty(model.Trabajadores[i].Domicilio.Partido) && model.Trabajadores[i].Teletrabajo == true && model.Trabajadores[i].Pais == "Argentina")
        //        {
        //            ModelState.AddModelError("FormularioVM.Trabajadores[" + i.ToString() + "].Domicilio.Partido", "Debe ingresar el partido");
        //            isValid = false;
        //        }

        //        if (string.IsNullOrEmpty(model.Trabajadores[i].Domicilio.Localidad) && model.Trabajadores[i].Teletrabajo == true && model.Trabajadores[i].Pais == "Argentina")
        //        {
        //            ModelState.AddModelError("FormularioVM.Trabajadores[" + i.ToString() + "].Domicilio.Localidad", "Debe ingresar la localidad");
        //            isValid = false;
        //        }
        //        if (string.IsNullOrEmpty(model.Trabajadores[i].Domicilio.Calle) && model.Trabajadores[i].Teletrabajo == true && model.Trabajadores[i].Pais == "Argentina")
        //        {
        //            ModelState.AddModelError("FormularioVM.Trabajadores[" + i.ToString() + "].Domicilio.Calle", "Debe ingresar la calle");
        //            isValid = false;
        //        }

        //        if (string.IsNullOrEmpty(model.Trabajadores[i].Domicilio.Altura) && model.Trabajadores[i].Teletrabajo == true && model.Trabajadores[i].Pais == "Argentina")
        //        {
        //            ModelState.AddModelError("FormularioVM.Trabajadores[" + i.ToString() + "].Domicilio.Altura", "Debe ingresar la altura");
        //            isValid = false;
        //        }
        //        //if(string.IsNullOrEmpty(model.Trabajadores[i].AdheridoEntidadGremial) && model.Trabajadores[i].Teletrabajo == true) 
        //        //{
        //        //    ModelState.AddModelError("FormularioVM.Trabajadores[" + i.ToString() + "].AdheridoEntidadGremial", "Debe ingresar si esta adherido o no");
        //        //    isValid = false;
        //        //}
        //        if (model.Trabajadores[i].FechaInicioTeletrabajo == null && model.Trabajadores[i].Teletrabajo == true)
        //        {
        //            ModelState.AddModelError("FormularioVM.Trabajadores[" + i.ToString() + "].FechaInicioTeletrabajo", "Debe ingresar la fecha de incicio");
        //            isValid = false;
        //        }
        //        if (model.Trabajadores[i].FechaDeContrato == null && model.Trabajadores[i].Teletrabajo == true)
        //        {
        //            ModelState.AddModelError("FormularioVM.Trabajadores[" + i.ToString() + "].FechaDeContrato", "Debe ingresar la fecha de contrato");
        //            isValid = false;
        //        }
        //        if (string.IsNullOrEmpty(model.Trabajadores[i].JornadaLaboral) && model.Trabajadores[i].Teletrabajo == true)
        //        {
        //            ModelState.AddModelError("FormularioVM.Trabajadores[" + i.ToString() + "].JornadaLaboral", "Debe ingresar la jornada laboral");
        //            isValid = false;
        //        }
        //        if (string.IsNullOrEmpty(model.Trabajadores[i].CorreoElectronicoLaboral) && model.Trabajadores[i].Teletrabajo == true)
        //        {
        //            ModelState.AddModelError("FormularioVM.Trabajadores[" + i.ToString() + "].CorreoElectronicoLaboral", "Debe ingresar si esta adherido o no");
        //            isValid = false;
        //        }
        //        if (string.IsNullOrEmpty(model.Trabajadores[i].CargaHorariaSemanal) && model.Trabajadores[i].Teletrabajo == true)
        //        {
        //            ModelState.AddModelError("FormularioVM.Trabajadores[" + i.ToString() + "].CargaHorariaSemanal", "Debe ingresar la carga horaria semanal");
        //            isValid = false;
        //        }

        //    }

        //    return isValid;

        //}


        














    }
}
