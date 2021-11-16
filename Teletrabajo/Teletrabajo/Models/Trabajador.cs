using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teletrabajo.Models
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

        public Domicilio Domicilio { get; set; } = new Domicilio();


    }
}
