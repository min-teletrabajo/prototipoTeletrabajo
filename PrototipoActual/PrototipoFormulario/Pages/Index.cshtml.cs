using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PrototipoFormulario.Models;
using PrototipoFormulario.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrototipoFormulario.Pages
{
    public class IndexModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;

        [Required(ErrorMessage = "Debe ingresar CUIL")]
        [MaxLength(11)]
        [MinLength(1)]
        [RegularExpression("[^0-9]", ErrorMessage = "El CUIL debe ser numerico")]
        public string CUIL { get; set; }
        public FormularioVM FormularioVM { get; set; }
        public RepresentantesLegales Representante { get; set; }
        public readonly TeletrabajoContext _db;

        public IndexModel(ILogger<IndexModel> logger, TeletrabajoContext db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnGet()
        {

        }
        public IActionResult OnPost(string cuil)
        {
            //Buscar el cuil en la DB y verificar si existe


            try
            {
                long newCuil = Convert.ToInt64(cuil);

                Representante = _db.RepresentantesLegales.Where(c => c.Cuil == newCuil).FirstOrDefault();

                if (Representante != null)
                {


                    TempData["CUIL"] = cuil;

                    return RedirectToPage("/Formulario", FormularioVM);
                }

                return Page();
            }
            catch (Exception)
            {

                return Page();
            }


        }
    }
}
