using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PrototipoFormulario.Models
{
    public partial class TeletrabajoContext : DbContext
    {
        public TeletrabajoContext()
        {
        }

        public TeletrabajoContext(DbContextOptions<TeletrabajoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actividades> Actividades { get; set; }
        public virtual DbSet<Arts> Arts { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Empresas> Empresas { get; set; }
        public virtual DbSet<Estados> Estados { get; set; }
        public virtual DbSet<Generos> Generos { get; set; }
        public virtual DbSet<JornadasLaborales> JornadasLaborales { get; set; }
        public virtual DbSet<Localidades> Localidades { get; set; }
        public virtual DbSet<Modalidades> Modalidades { get; set; }
        public virtual DbSet<ObrasSociales> ObrasSociales { get; set; }
        public virtual DbSet<Paises> Paises { get; set; }
        public virtual DbSet<Partidos> Partidos { get; set; }
        public virtual DbSet<Perfiles> Perfiles { get; set; }
        public virtual DbSet<Permisos> Permisos { get; set; }
        public virtual DbSet<Provincias> Provincias { get; set; }
        public virtual DbSet<Puestos> Puestos { get; set; }
        public virtual DbSet<RepresentantesLegales> RepresentantesLegales { get; set; }
        public virtual DbSet<Sucursales> Sucursales { get; set; }
        public virtual DbSet<TipoDocumentos> TipoDocumentos { get; set; }
        public virtual DbSet<Trabajadores> Trabajadores { get; set; }
        public virtual DbSet<TramiteFormularios> TramiteFormularios { get; set; }
        public virtual DbSet<UsuarioXperfil> UsuarioXperfil { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:teletrabajodb.database.windows.net,1433;Initial Catalog=TeletrabajoDatabase;Persist Security Info=False;User ID=admin123;Password=Teletrabajo123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actividades>(entity =>
            {
                entity.HasKey(e => e.IdActividad)
                    .HasName("PK__Activida__C5FAF47E9B9CAC3B");

                entity.Property(e => e.IdActividad).HasColumnName("ID_Actividad");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Arts>(entity =>
            {
                entity.HasKey(e => e.IdArt)
                    .HasName("PK__Arts__2A42BFCCE57B8F7E");

                entity.Property(e => e.IdArt).HasColumnName("ID_Art");

                entity.Property(e => e.Descripcion).HasMaxLength(50);
            });

            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__02AA07857E8E4D91");

                entity.Property(e => e.IdCategoria).HasColumnName("ID_Categoria");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Empresas>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa);

                entity.Property(e => e.IdEmpresa)
                    .HasColumnName("ID_Empresa")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cuit).HasColumnName("CUIT");

                entity.Property(e => e.DomicilioFiscal)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.IdActividad).HasColumnName("ID_Actividad");

                entity.Property(e => e.IdRepresentanteLegal).HasColumnName("ID_RepresentanteLegal");

                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(40)
                    .IsFixedLength();

                entity.HasOne(d => d.IdActividadNavigation)
                    .WithMany(p => p.Empresas)
                    .HasForeignKey(d => d.IdActividad)
                    .HasConstraintName("FK__Empresas__ID_Act__4AB81AF0");

                entity.HasOne(d => d.IdRepresentanteLegalNavigation)
                    .WithMany(p => p.Empresas)
                    .HasForeignKey(d => d.IdRepresentanteLegal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Empresas__ID_Rep__40058253");
            });

            modelBuilder.Entity<Estados>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__Estados__9CF49395734C8816");

                entity.Property(e => e.IdEstado).HasColumnName("ID_Estado");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Generos>(entity =>
            {
                entity.HasKey(e => e.IdGenero)
                    .HasName("PK__Generos__52F05F3DBA8DD79D");

                entity.Property(e => e.IdGenero).HasColumnName("ID_Genero");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<JornadasLaborales>(entity =>
            {
                entity.HasKey(e => e.IdJornadaLaboral)
                    .HasName("PK__Jornadas__DFE2F981D42B2C31");

                entity.Property(e => e.IdJornadaLaboral).HasColumnName("ID_JornadaLaboral");

                entity.Property(e => e.Descripcion).HasMaxLength(50);
            });

            modelBuilder.Entity<Localidades>(entity =>
            {
                entity.HasKey(e => e.IdLocalidad)
                    .HasName("PK__Localida__8ACE3DA1037DA938");

                entity.Property(e => e.IdLocalidad).HasColumnName("ID_Localidad");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IdPartido).HasColumnName("ID_Partido");

                entity.HasOne(d => d.IdPartidoNavigation)
                    .WithMany(p => p.Localidades)
                    .HasForeignKey(d => d.IdPartido)
                    .HasConstraintName("FK__Localidad__ID_Pa__503BEA1C");
            });

            modelBuilder.Entity<Modalidades>(entity =>
            {
                entity.HasKey(e => e.IdModalidadDeContratacion)
                    .HasName("PK__Modalida__28FB572C84DA06BE");

                entity.Property(e => e.IdModalidadDeContratacion).HasColumnName("ID_ModalidadDeContratacion");

                entity.Property(e => e.Descripcion).HasMaxLength(50);
            });

            modelBuilder.Entity<ObrasSociales>(entity =>
            {
                entity.HasKey(e => e.IdObraSocial)
                    .HasName("PK__ObrasSoc__F2933F0F9F3F5EFF");

                entity.Property(e => e.IdObraSocial).HasColumnName("ID_ObraSocial");

                entity.Property(e => e.Descripcion).HasMaxLength(50);
            });

            modelBuilder.Entity<Paises>(entity =>
            {
                entity.HasKey(e => e.IdPais)
                    .HasName("PK__Paises__AE88C4EF8ADA65A8");

                entity.Property(e => e.IdPais).HasColumnName("ID_Pais");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Partidos>(entity =>
            {
                entity.HasKey(e => e.IdPartido)
                    .HasName("PK__Partidos__B94207B21BCD2C13");

                entity.Property(e => e.IdPartido).HasColumnName("ID_Partido");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IdProvincia).HasColumnName("ID_Provincia");

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Partidos)
                    .HasForeignKey(d => d.IdProvincia)
                    .HasConstraintName("FK__Partidos__ID_Pro__4F47C5E3");
            });

            modelBuilder.Entity<Perfiles>(entity =>
            {
                entity.HasKey(e => e.IdPerfil)
                    .HasName("PK__Perfiles__684BCA631EDE96E4");

                entity.Property(e => e.IdPerfil)
                    .HasColumnName("ID_Perfil")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Permisos>(entity =>
            {
                entity.HasKey(e => e.IdPermiso)
                    .HasName("PK__Permisos__D5B666CC0218B5D9");

                entity.Property(e => e.IdPermiso)
                    .HasColumnName("ID_Permiso")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdPerfil).HasColumnName("ID_Perfil");

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.Permisos)
                    .HasForeignKey(d => d.IdPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PER_PER");
            });

            modelBuilder.Entity<Provincias>(entity =>
            {
                entity.HasKey(e => e.IdProvincia)
                    .HasName("PK__Provinci__A659F87B25CFEB2F");

                entity.Property(e => e.IdProvincia).HasColumnName("ID_Provincia");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IdPais).HasColumnName("ID_Pais");

                entity.HasOne(d => d.IdPaisNavigation)
                    .WithMany(p => p.Provincias)
                    .HasForeignKey(d => d.IdPais)
                    .HasConstraintName("FK__Provincia__ID_Pa__4D5F7D71");
            });

            modelBuilder.Entity<Puestos>(entity =>
            {
                entity.HasKey(e => e.IdPuesto)
                    .HasName("PK__Puestos__ED24C14CF182DEDB");

                entity.Property(e => e.IdPuesto).HasColumnName("ID_Puesto");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RepresentantesLegales>(entity =>
            {
                entity.HasKey(e => e.IdRepresentanteLegal)
                    .HasName("PK__Represen__BDC632604F86004E");

                entity.Property(e => e.IdRepresentanteLegal).HasColumnName("ID_RepresentanteLegal");

                entity.Property(e => e.Apellido).HasMaxLength(50);

                entity.Property(e => e.Calle).HasMaxLength(50);

                entity.Property(e => e.CodigoPostal).HasMaxLength(15);

                entity.Property(e => e.Correo).HasMaxLength(50);

                entity.Property(e => e.Cuil).HasColumnName("CUIL");

                entity.Property(e => e.Departamento).HasMaxLength(50);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.IdLocalidad).HasColumnName("ID_Localidad");

                entity.Property(e => e.IdProvincia).HasColumnName("ID_Provincia");

                entity.Property(e => e.IdTipoDocumento).HasColumnName("ID_TipoDocumento");

                entity.Property(e => e.Instrucciones).HasMaxLength(100);

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.NumeroDocumento).HasMaxLength(8);

                entity.HasOne(d => d.IdLocalidadNavigation)
                    .WithMany(p => p.RepresentantesLegales)
                    .HasForeignKey(d => d.IdLocalidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Represent__ID_Lo__5CD6CB2B");

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.RepresentantesLegales)
                    .HasForeignKey(d => d.IdProvincia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Represent__ID_Pr__5BE2A6F2");

                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.RepresentantesLegales)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Represent__ID_Ti__5FB337D6");
            });

            modelBuilder.Entity<Sucursales>(entity =>
            {
                entity.HasKey(e => e.IdSucursal)
                    .HasName("PK__Sucursal__D09FC76550699FF5");

                entity.Property(e => e.IdSucursal).HasColumnName("ID_Sucursal");

                entity.Property(e => e.Calle).HasMaxLength(50);

                entity.Property(e => e.Departamento).HasMaxLength(50);

                entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");

                entity.Property(e => e.IdLocalidad).HasColumnName("ID_Localidad");

                entity.Property(e => e.IdPartido).HasColumnName("ID_Partido");

                entity.Property(e => e.IdProvincia).HasColumnName("ID_Provincia");

                entity.Property(e => e.Instrucciones).HasMaxLength(100);

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Sucursales)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sucursale__ID_Em__571DF1D5");

                entity.HasOne(d => d.IdLocalidadNavigation)
                    .WithMany(p => p.Sucursales)
                    .HasForeignKey(d => d.IdLocalidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sucursale__ID_Lo__5629CD9C");

                entity.HasOne(d => d.IdPartidoNavigation)
                    .WithMany(p => p.Sucursales)
                    .HasForeignKey(d => d.IdPartido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sucursale__ID_Pa__5441852A");

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Sucursales)
                    .HasForeignKey(d => d.IdProvincia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sucursale__ID_Pr__5535A963");
            });

            modelBuilder.Entity<TipoDocumentos>(entity =>
            {
                entity.HasKey(e => e.IdTipoDocumento)
                    .HasName("PK__TipoDocu__C4F1D09D6C91C7A2");

                entity.Property(e => e.IdTipoDocumento).HasColumnName("ID_TipoDocumento");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Trabajadores>(entity =>
            {
                entity.HasKey(e => e.IdTrabajador)
                    .HasName("PK__Trabajad__0B43E91B31B3B0B3");

                entity.Property(e => e.IdTrabajador)
                    .HasColumnName("ID_Trabajador")
                    .ValueGeneratedNever();

                entity.Property(e => e.Apellido).HasMaxLength(50);

                entity.Property(e => e.Calle).HasMaxLength(50);

                entity.Property(e => e.CorreoElectronicoLaboral).HasMaxLength(100);

                entity.Property(e => e.Cuil).HasColumnName("CUIL");

                entity.Property(e => e.Departamento).HasMaxLength(25);

                entity.Property(e => e.FechaClaveAltaTemprana).HasColumnType("date");

                entity.Property(e => e.FechaInicioTeletrabajo).HasColumnType("date");

                entity.Property(e => e.IdArt).HasColumnName("ID_Art");

                entity.Property(e => e.IdCategoria).HasColumnName("ID_Categoria");

                entity.Property(e => e.IdGenero).HasColumnName("ID_Genero");

                entity.Property(e => e.IdJornadaLaboral).HasColumnName("ID_JornadaLaboral");

                entity.Property(e => e.IdLocalidad).HasColumnName("ID_Localidad");

                entity.Property(e => e.IdModalidadDeContratacion).HasColumnName("ID_ModalidadDeContratacion");

                entity.Property(e => e.IdObraSocial).HasColumnName("ID_ObraSocial");

                entity.Property(e => e.IdPais).HasColumnName("ID_Pais");

                entity.Property(e => e.IdPartido).HasColumnName("ID_Partido");

                entity.Property(e => e.IdProvincia).HasColumnName("ID_Provincia");

                entity.Property(e => e.IdPuesto).HasColumnName("ID_Puesto");

                entity.Property(e => e.IdSucursal).HasColumnName("ID_Sucursal");

                entity.Property(e => e.IdTramiteFormulario).HasColumnName("ID_TramiteFormulario");

                entity.Property(e => e.Instrucciones).HasMaxLength(100);

                entity.Property(e => e.MetadataAcreditacion).HasMaxLength(4000);

                entity.Property(e => e.MetadataContrato).HasMaxLength(4000);

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.NombreArchivoAcreditacion).HasMaxLength(300);

                entity.Property(e => e.NombreArchivoContrato).HasMaxLength(300);

                entity.HasOne(d => d.IdArtNavigation)
                    .WithMany(p => p.Trabajadores)
                    .HasForeignKey(d => d.IdArt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Trabajado__ID_Ar__37703C52");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Trabajadores)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Trabajado__ID_Ca__3587F3E0");

                entity.HasOne(d => d.IdGeneroNavigation)
                    .WithMany(p => p.Trabajadores)
                    .HasForeignKey(d => d.IdGenero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Trabajado__ID_Ge__3493CFA7");

                entity.HasOne(d => d.IdJornadaLaboralNavigation)
                    .WithMany(p => p.Trabajadores)
                    .HasForeignKey(d => d.IdJornadaLaboral)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Trabajado__ID_Jo__3F115E1A");

                entity.HasOne(d => d.IdLocalidadNavigation)
                    .WithMany(p => p.Trabajadores)
                    .HasForeignKey(d => d.IdLocalidad)
                    .HasConstraintName("FK__Trabajado__ID_Lo__3A4CA8FD");

                entity.HasOne(d => d.IdModalidadDeContratacionNavigation)
                    .WithMany(p => p.Trabajadores)
                    .HasForeignKey(d => d.IdModalidadDeContratacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Trabajado__ID_Mo__395884C4");

                entity.HasOne(d => d.IdObraSocialNavigation)
                    .WithMany(p => p.Trabajadores)
                    .HasForeignKey(d => d.IdObraSocial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Trabajado__ID_Ob__3864608B");

                entity.HasOne(d => d.IdPaisNavigation)
                    .WithMany(p => p.Trabajadores)
                    .HasForeignKey(d => d.IdPais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Trabajado__ID_Pa__3D2915A8");

                entity.HasOne(d => d.IdPartidoNavigation)
                    .WithMany(p => p.Trabajadores)
                    .HasForeignKey(d => d.IdPartido)
                    .HasConstraintName("FK__Trabajado__ID_Pa__3B40CD36");

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Trabajadores)
                    .HasForeignKey(d => d.IdProvincia)
                    .HasConstraintName("FK__Trabajado__ID_Pr__3C34F16F");

                entity.HasOne(d => d.IdPuestoNavigation)
                    .WithMany(p => p.Trabajadores)
                    .HasForeignKey(d => d.IdPuesto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Trabajado__ID_Pu__367C1819");

                entity.HasOne(d => d.IdSucursalNavigation)
                    .WithMany(p => p.Trabajadores)
                    .HasForeignKey(d => d.IdSucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Trabajado__ID_Su__3E1D39E1");

                entity.HasOne(d => d.IdTramiteFormularioNavigation)
                    .WithMany(p => p.Trabajadores)
                    .HasForeignKey(d => d.IdTramiteFormulario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Trabajado__ID_Tr__339FAB6E");
            });

            modelBuilder.Entity<TramiteFormularios>(entity =>
            {
                entity.HasKey(e => e.IdTramiteFormulario)
                    .HasName("PK__TramiteF__A8401EB803320CD9");

                entity.Property(e => e.IdTramiteFormulario)
                    .HasColumnName("ID_TramiteFormulario")
                    .ValueGeneratedNever();

                entity.Property(e => e.FechaAlta).HasColumnType("date");

                entity.Property(e => e.FechaModificacion).HasColumnType("date");

                entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");

                entity.Property(e => e.IdEstado).HasColumnName("ID_Estado");

                entity.Property(e => e.IdRepresentanteLegal).HasColumnName("ID_RepresentanteLegal");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

                entity.Property(e => e.Observacion).HasMaxLength(50);

                entity.Property(e => e.Otros).HasMaxLength(60);

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.TramiteFormularios)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TramiteFo__ID_Em__17036CC0");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.TramiteFormularios)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TramiteFo__ID_Es__18EBB532");

                entity.HasOne(d => d.IdRepresentanteLegalNavigation)
                    .WithMany(p => p.TramiteFormularios)
                    .HasForeignKey(d => d.IdRepresentanteLegal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TramiteFo__ID_Re__17F790F9");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.TramiteFormularios)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TramiteFo__ID_Us__160F4887");
            });

            modelBuilder.Entity<UsuarioXperfil>(entity =>
            {
                entity.HasKey(e => new { e.IdUsuarioXperfil, e.IdUsuario, e.IdPerfil })
                    .HasName("USU_PER");

                entity.ToTable("UsuarioXPerfil");

                entity.Property(e => e.IdUsuarioXperfil)
                    .HasColumnName("ID_UsuarioXPerfil")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

                entity.Property(e => e.IdPerfil).HasColumnName("ID_Perfil");

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.UsuarioXperfil)
                    .HasForeignKey(d => d.IdPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UsuarioXP__ID_Pe__14270015");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuarioXperfil)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PER_USU");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__DE4431C53638CE8E");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("ID_Usuario")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
