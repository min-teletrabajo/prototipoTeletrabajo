using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Teletrabajo.FormModels
{
    public class TrabajadorDTO
    {
        [Index(0)]
        public string CuitEmpleador { get; set; }
        [Index(1)]
        public string RazonSocial { get; set; }
        [Index(2)]
        public string Cuil { get; set; }//
        [Index(3)]
        public string Apellido { get; set; }
        [Index(4)]
        public string Nombre { get; set; }
        [Index(5)]
        public string Teletrabajador { get; set; }
        [Index(6)]
        public string FechaInicioTeletrabajo { get; set; }
        [Index(7)]
        public string ModalidadDeTrabajo { get; set; }
        [Index(8)]
        public string FechaDeContrato { get; set; }
        [Index(9)]
        public string Voluntariedad { get; set; }
        [Index(10)]
        public string FechaDeVoluntariedad { get; set; }
        [Index(11)]
        public string Pais { get; set; }
        [Index(12)]
        public string Provincia { get; set; }
        [Index(13)]
        public string Partido { get; set; }
        [Index(14)]
        public string Localidad { get; set; }
        [Index(15)]
        public string Calle { get; set; }
        [Index(16)]
        public string Altura { get; set; }
        [Index(17)]
        public string Piso { get; set; }
        [Index(18)]
        public string Departamento { get; set; }
        [Index(19)]
        public string CodigoPostal { get; set; }
        [Index(20)]
        public string JornadaLaboral_Lunes { get; set; }
        [Index(21)]
        public string JornadaLaboral_HorarioLunesDesde { get; set; }
        [Index(22)]
        public string JornadaLaboral_HorarioLunesHasta { get; set; }
        [Index(23)]
        public string JornadaLaboral_Martes { get; set; }
        [Index(24)]
        public string JornadaLaboral_HorarioMartesDesde { get; set; }
        [Index(25)]
        public string JornadaLaboral_HorarioMartesHasta { get; set; }
        [Index(26)]
        public string JornadaLaboral_Miercoles { get; set; }
        [Index(27)]
        public string JornadaLaboral_HorarioMiercolesDesde { get; set; }
        [Index(28)]
        public string JornadaLaboral_HorarioMiercolesHasta { get; set; }
        [Index(29)]
        public string JornadaLaboral_Jueves { get; set; }
        [Index(30)]
        public string JornadaLaboral_HorarioJuevesDesde { get; set; }
        [Index(31)]
        public string JornadaLaboral_HorarioJuevesHasta { get; set; }
        [Index(32)]
        public string JornadaLaboral_Viernes { get; set; }
        [Index(33)]
        public string JornadaLaboral_HorarioViernesDesde { get; set; }
        [Index(34)]
        public string JornadaLaboral_HorarioViernesHasta { get; set; }
        [Index(35)]
        public string JornadaLaboral_Sabados { get; set; }
        [Index(36)]
        public string JornadaLaboral_HorarioSabadosDesde { get; set; }
        [Index(37)]
        public string JornadaLaboral_HorarioSabadosHasta { get; set; }
        [Index(38)]
        public string JornadaLaboral_Domingos { get; set; }
        [Index(39)]
        public string JornadaLaboral_HorarioDomingosDesde { get; set; }
        [Index(40)]
        public string JornadaLaboral_HorarioDomingosHasta { get; set; }
        [Index(41)]
        public string CargaHorariaMensual { get; set; }//
        [Index(42)]
        public string CorreoElectronicoLaboral { get; set; }//
        
    }
}
