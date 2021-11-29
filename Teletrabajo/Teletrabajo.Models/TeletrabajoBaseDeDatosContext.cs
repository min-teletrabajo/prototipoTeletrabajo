using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Teletrabajo.Models
{
    public partial class TeletrabajoBaseDeDatosContext : DbContext
    {
        public TeletrabajoBaseDeDatosContext()
        {
        }

        public TeletrabajoBaseDeDatosContext(DbContextOptions<TeletrabajoBaseDeDatosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adjunto> Adjunto { get; set; }
        public virtual DbSet<Form> Form { get; set; }
        public virtual DbSet<FormData> FormData { get; set; }
        public virtual DbSet<FormDataAdjunto> FormDataAdjunto { get; set; }
        public virtual DbSet<Sistema> Sistema { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=TeletrabajoBaseDeDatos;Trusted_Connection=True;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adjunto>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Metadata)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.NombreArchivo)
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Form>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.VersionActual)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Sistema)
                    .WithMany(p => p.Form)
                    .HasForeignKey(d => d.SistemaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Form__SistemaId__267ABA7A");
            });

            modelBuilder.Entity<FormData>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Data).IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Version)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.FormData)
                    .HasForeignKey(d => d.FormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FormData__FormId__2B3F6F97");
            });

            modelBuilder.Entity<FormDataAdjunto>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.Adjunto)
                    .WithMany()
                    .HasForeignKey(d => d.AdjuntoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FormDataA__Adjun__300424B4");

                entity.HasOne(d => d.FormData)
                    .WithMany()
                    .HasForeignKey(d => d.FormDataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FormDataA__FormD__2F10007B");
            });

            modelBuilder.Entity<Sistema>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
