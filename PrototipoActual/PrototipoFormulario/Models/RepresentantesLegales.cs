using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PrototipoFormulario.Models
{
    public partial class RepresentantesLegales
    {
        public RepresentantesLegales()
        {
            Empresas = new HashSet<Empresas>();
            TramiteFormularios = new HashSet<TramiteFormularios>();
        }

        public int IdRepresentanteLegal { get; set; }
        public int IdProvincia { get; set; }
        public int IdLocalidad { get; set; }
        public int IdTipoDocumento { get; set; }
        public long? Cuil { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Correo { get; set; }
        public int? TelefonoCelular { get; set; }
        public string Calle { get; set; }
        public int? NumeroCalle { get; set; }
        public int? Piso { get; set; }
        public string Departamento { get; set; }
        public string Instrucciones { get; set; }
        public string CodigoPostal { get; set; }

        public virtual Localidades IdLocalidadNavigation { get; set; }
        public virtual Provincias IdProvinciaNavigation { get; set; }
        public virtual TipoDocumentos IdTipoDocumentoNavigation { get; set; }
        public virtual ICollection<Empresas> Empresas { get; set; }
        public virtual ICollection<TramiteFormularios> TramiteFormularios { get; set; }
    }
}
