using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PrototipoFormulario.Models;
using PrototipoFormulario.ViewModel;

namespace PrototipoFormulario.Pages
{
    public class FormularioModel : PageModel
    {
        public readonly TeletrabajoContext _db;
        public bool Estado { get; set; }
        public Trabajadores Trabajador { get; set; }
        public RepresentantesLegales RepresentanteLegal { get; set; }
        public Empresas Empresa { get; set; }

        

        public FormularioVM FormularioVM { get; set; }

        public FormularioModel(TeletrabajoContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            var cuil = TempData["CUIL"].ToString();
            long newCuil = Convert.ToInt64(cuil);
            FormularioVM = new FormularioVM()
            {
                RepresentanteLegal = _db.RepresentantesLegales.Where(t => t.Cuil == newCuil).FirstOrDefault(),
                Trabajadores = _db.Trabajadores.ToList(),
                Empresas = _db.Empresas.ToList(),
                Paises = _db.Paises.Select(p => new SelectListItem
                {
                    Value = p.IdPais.ToString(),
                    Text = p.Descripcion
                }).ToList(),
                Provincias = _db.Provincias.Select(prov => new SelectListItem
                {
                    Value = prov.IdProvincia.ToString(),
                    Text = prov.Descripcion
                }).ToList(),
                Localidades = _db.Localidades.Select(loc => new SelectListItem
                {

                    Value = loc.IdLocalidad.ToString(),
                    Text = loc.Descripcion


                }).ToList(),
                Partidos = _db.Partidos.Select(par => new SelectListItem
                {
                    Value = par.IdPartido.ToString(),
                    Text = par.Descripcion
                }).ToList()
            };
            

        }


    }
}
