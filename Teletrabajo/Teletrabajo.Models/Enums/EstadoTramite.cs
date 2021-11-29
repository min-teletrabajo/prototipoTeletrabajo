using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Teletrabajo.Models.Enums
{
    public enum EstadoTramite
    {
		[Display(Name = "Borrador")]
		Borrador = 0,
		
		[Display(Name = "Pendiente de Recepción")]
		PendienteDeRecepcion = 1, // ENVIADO para que lo vea el AGENTE
		
		[Display(Name = "Recepcionado")]
		Recepcionado = 2,
		
		[Display(Name = "Recepcionado con Observaciones")]
		RecepcionadoConObservaciones = 3,
		
		[Display(Name = "Finalizado")]
		Finalizado = 4,
		
		[Display(Name = "Migrado")]
		Migrado = 5,

		[Display(Name = "Todos")]
		Todos = 99
    }
}
