using CsvHelper.Configuration.Attributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teletrabajo.FormModels
{
    public class Trabajador
    {
        public string CuitEmpleador { get; set; }
        public string RazonSocial { get; set; }       
        public string Nombre { get; set; }//

        public string Apellido { get; set; }//

        public string Cuil { get; set; }//

        public string Teletrabajador { get; set; }
        public string Genero { get; set; }//

        public string Categoria { get; set; }//

        
        public string Puesto { get; set; }//

       
        public string Art { get; set; }//

        
        public string ObraSocial { get; set; }//

      
        public string ModalidadContratacion { get; set; }//
 
        public string AdheridoEntidadGremial { get; set; }//

        
        public string AdheridoConvenioColectivoTrabajo { get; set; }//

        
        public string FechaClaveAltaTemprana { get; set; }//
   
        public DateTime? FechaInicioTeletrabajo { get; set; }//

        
        public string CorreoElectronicoLaboral { get; set; }//

        
        public DateTime? FechaDeContrato { get; set; }//

        
        public string ModalidadDeTrabajo { get; set; }

       
        public string Voluntariedad { get; set; }//

       
        public DateTime? FechaDeVoluntariedad { get; set; }//

        public string CargaHorariaMensual { get; set; }//
        public string Pais { get; set; }

        public Domicilio Domicilio { get; set; } = new Domicilio();

        public string JornadaLaboral_Lunes { get; set; }

   
        public string JornadaLaboral_HorarioLunesDesde { get; set; }

 
        public string JornadaLaboral_HorarioLunesHasta { get; set; }

 
        public string JornadaLaboral_Martes { get; set; }

 
        public string JornadaLaboral_HorarioMartesDesde { get; set; }

        public string JornadaLaboral_HorarioMartesHasta { get; set; }


 
        public string JornadaLaboral_Miercoles { get; set; }


   
        public string JornadaLaboral_HorarioMiercolesDesde { get; set; }


        public string JornadaLaboral_HorarioMiercolesHasta { get; set; }


        public string JornadaLaboral_Jueves { get; set; }


        public string JornadaLaboral_HorarioJuevesDesde { get; set; }


        public string JornadaLaboral_HorarioJuevesHasta { get; set; }



        public string JornadaLaboral_Viernes { get; set; }

        public string JornadaLaboral_HorarioViernesDesde { get; set; }


        public string JornadaLaboral_HorarioViernesHasta { get; set; }


        public string JornadaLaboral_Sabados { get; set; }
 
        public string JornadaLaboral_HorarioSabadosDesde { get; set; }

  
        public string JornadaLaboral_HorarioSabadosHasta { get; set; }


    
        public string JornadaLaboral_Domingos { get; set; }
   
        public string JornadaLaboral_HorarioDomingosDesde { get; set; }


        public string JornadaLaboral_HorarioDomingosHasta { get; set; }

        

        




        //public string Provincia { get { return this.Domicilio.Provincia; } set { this.Domicilio.Provincia = value; } }




        //public bool Teletrabajo { get; set; }

        //


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
