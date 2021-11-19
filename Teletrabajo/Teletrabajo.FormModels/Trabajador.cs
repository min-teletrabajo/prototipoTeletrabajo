using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teletrabajo.FormModels
{
    public class Trabajador
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cuil { get; set; }
        public string Genero { get; set; }
        public string Categoria { get; set; }
        public string Puesto { get; set; }
        public string Art { get; set; }
        public string ObraSocial { get; set; }
        public string ModalidadContratacion { get; set; }
        public string AdheridoEntidadGremial { get; set; }
        public string AdheridoConvenioColectivoTrabajo { get; set; }
        public DateTime FechaClaveAltaTemprana { get; set; }
        public string JornadaLaboral { get; set; }
        public DateTime FechaInicioTeletrabajo { get; set; }
        public string CorreoElectronicoLaboral { get; set; }
        public DateTime FechaDeContrato { get; set; }
        public string ModalidadDeTrabajo { get; set; }
        public string Voluntariedad { get; set; }
        public DateTime FechaDeVoluntariedad { get; set; }
        public string CargaHorariaSemanal { get; set; }
        

        public Domicilio Domicilio { get; set; } = new Domicilio();

        public bool Teletrabajo { get; set; }


        public string Pais { get; set; }


        /// <summary>
        /// Funcion para generar paises que se cargaran en la partial view de nomina
        /// de trabajadores
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> ObtenerPaises()
        {
            List<Pais> PaisesList = new List<Pais>()
            {
                new Pais(){Descripcion = "Albania"},
                new Pais(){Descripcion = "Argentina"},
                new Pais(){Descripcion = "Brasil"},
                new Pais(){Descripcion = "Uruguay"}
            };

            List<SelectListItem> Paises = PaisesList.Select(p => new SelectListItem
            {
                Value = p.Descripcion,
                Text = p.Descripcion
            }).ToList();

            return Paises;
        }
    }
}
