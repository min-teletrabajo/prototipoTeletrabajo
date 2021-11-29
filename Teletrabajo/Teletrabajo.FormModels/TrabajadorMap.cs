using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Teletrabajo.FormModels
{
    public sealed class TrabajadorMap : ClassMap<TrabajadorDTO>
    {
        public TrabajadorMap()
        {
            Map(t => t.CuitEmpleador).Name("CUIT_EMPLEADOR");
            Map(t => t.RazonSocial).Name("RAZON_SOCIAL");
            Map(t => t.Cuil).Name("CUIL_TRABAJADOR");
            Map(t => t.Apellido).Name("APELLIDO_TRABAJADOR");
            Map(t => t.Nombre).Name("NOMBRE_TRABAJADOR");
            Map(t => t.Teletrabajador).Name("TELETRABAJADOR");
            Map(t => t.FechaInicioTeletrabajo).Name("FECHA_INICIO_TELETRABAJO");
            Map(t => t.ModalidadDeTrabajo).Name("MODALIDAD_TRABAJO");
            Map(t => t.FechaDeContrato).Name("FECHA_SUSCRIPCION_CONTRATO_TRABAJO");
            Map(t => t.Voluntariedad).Name("REQUIRIO_VOLUNTARIEDAD");
            Map(t => t.FechaDeVoluntariedad).Name("FECHA_VOLUNTARIEDAD");
            Map(t => t.Pais).Name("PAIS_LABORAL");
            Map(t => t.Provincia).Name("PROVINCIA_LABORAL");
            Map(t => t.Partido).Name("PARTIDO_LABORAL");
            Map(t => t.Localidad).Name("LOCALIDAD_LABORAL");
            Map(t => t.Calle).Name("CALLE_LABORAL");
            Map(t => t.Altura).Name("ALTURA_LABORAL");
            Map(t => t.Piso).Name("PISO_LABORAL");
            Map(t => t.Departamento).Name("DPTO_LABORAL");
            Map(t => t.CodigoPostal).Name("CPA_LABORAL");
            Map(t => t.JornadaLaboral_Lunes).Name("JORNADA_LABORAL_LUNES");
            Map(t => t.JornadaLaboral_HorarioLunesDesde).Name("LUNES_HORARIO_DESDE");
            Map(t => t.JornadaLaboral_HorarioLunesHasta).Name("LUNES_HORARIO_HASTA");
            Map(t => t.JornadaLaboral_Martes).Name("JORNADA_LABORAL_MARTES");
            Map(t => t.JornadaLaboral_HorarioMartesDesde).Name("MARTES_HORARIO_DESDE");
            Map(t => t.JornadaLaboral_HorarioMartesHasta).Name("MARTES_HORARIO_HASTA");
            Map(t => t.JornadaLaboral_Miercoles).Name("JORNADA_LABORAL_MIERCOLES");
            Map(t => t.JornadaLaboral_HorarioMiercolesDesde).Name("MIERCOLES_HORARIO_DESDE");
            Map(t => t.JornadaLaboral_HorarioMiercolesHasta).Name("MIERCOLES_HORARIO_HASTA");
            Map(t => t.JornadaLaboral_Jueves).Name("JORNADA_LABORAL_JUEVES");
            Map(t => t.JornadaLaboral_HorarioJuevesDesde).Name("JUEVES_HORARIO_DESDE");
            Map(t => t.JornadaLaboral_HorarioJuevesHasta).Name("JUEVES_HORARIO_HASTA");
            Map(t => t.JornadaLaboral_Viernes).Name("JORNADA_LABORAL_VIERNES");
            Map(t => t.JornadaLaboral_HorarioViernesDesde).Name("VIERNES_HORARIO_DESDE");
            Map(t => t.JornadaLaboral_HorarioViernesHasta).Name("VIERNES_HORARIO_HASTA");
            Map(t => t.JornadaLaboral_Sabados).Name("JORNADA_LABORAL_SABADO");
            Map(t => t.JornadaLaboral_HorarioSabadosDesde).Name("SABADO_HORARIO_DESDE");
            Map(T => T.JornadaLaboral_HorarioSabadosHasta).Name("SABADO_HORARIO_HASTA");
            Map(t => t.JornadaLaboral_Domingos).Name("JORNADA_LABORAL_DOMINGO");
            Map(t => t.JornadaLaboral_HorarioDomingosDesde).Name("DOMINGO_HORARIO_DESDE");
            Map(t => t.JornadaLaboral_HorarioDomingosHasta).Name("DOMINGO_HORARIO_HASTA");
            Map(t => t.CargaHorariaMensual).Name("CANTIDAD_HORAS_MENSUALES");
            Map(t => t.CorreoElectronicoLaboral).Name("CORREO_ELECTRONICO_LABORAL");         

        }
    }
}
