using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PrototipoFormulario.Models
{
    public partial class Trabajadores
    {
        public int IdTrabajador { get; set; }
        public int IdTramiteFormulario { get; set; }
        public int IdGenero { get; set; }
        public int IdCategoria { get; set; }
        public int IdPuesto { get; set; }
        public int IdArt { get; set; }
        public int IdObraSocial { get; set; }
        public int IdModalidadDeContratacion { get; set; }
        public int? IdLocalidad { get; set; }
        public int? IdPartido { get; set; }
        public int? IdProvincia { get; set; }
        public int IdPais { get; set; }
        public int IdSucursal { get; set; }
        public int IdJornadaLaboral { get; set; }
        public long? Cuil { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool? AdheridoConvenioColectivoTrabajo { get; set; }
        public DateTime? FechaClaveAltaTemprana { get; set; }
        public bool? Teletrabajo { get; set; }
        public bool? AdheridoEntidadGremial { get; set; }
        public DateTime? FechaInicioTeletrabajo { get; set; }
        public string Calle { get; set; }
        public int? NumeroCalle { get; set; }
        public int? Piso { get; set; }
        public string Departamento { get; set; }
        public string Instrucciones { get; set; }
        public string CorreoElectronicoLaboral { get; set; }
        public string NombreArchivoAcreditacion { get; set; }
        public string MetadataAcreditacion { get; set; }
        public byte[] ContenidoAcreditacion { get; set; }
        public string NombreArchivoContrato { get; set; }
        public string MetadataContrato { get; set; }
        public string ContenidoContrato { get; set; }

        public virtual Arts IdArtNavigation { get; set; }
        public virtual Categorias IdCategoriaNavigation { get; set; }
        public virtual Generos IdGeneroNavigation { get; set; }
        public virtual JornadasLaborales IdJornadaLaboralNavigation { get; set; }
        public virtual Localidades IdLocalidadNavigation { get; set; }
        public virtual Modalidades IdModalidadDeContratacionNavigation { get; set; }
        public virtual ObrasSociales IdObraSocialNavigation { get; set; }
        public virtual Paises IdPaisNavigation { get; set; }
        public virtual Partidos IdPartidoNavigation { get; set; }
        public virtual Provincias IdProvinciaNavigation { get; set; }
        public virtual Puestos IdPuestoNavigation { get; set; }
        public virtual Sucursales IdSucursalNavigation { get; set; }
        public virtual TramiteFormularios IdTramiteFormularioNavigation { get; set; }
    }
}
