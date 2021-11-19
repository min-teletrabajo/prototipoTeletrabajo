using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
                optionsBuilder.UseSqlServer("Server=tcp:teletrabajodb.database.windows.net,1433;Initial Catalog=TeletrabajoBaseDeDatos;Persist Security Info=False;User ID=admin123;Password=Teletrabajo123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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
                    .HasMaxLength(1000)
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
                    .HasConstraintName("FK__Form__SistemaId__619B8048");
            });

            modelBuilder.Entity<FormData>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Data).IsUnicode(false);

                entity.Property(e => e.EstadoTramiteId).HasColumnName("EstadoTramiteID");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(2000)
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
                    .HasConstraintName("FK__FormData__FormId__6477ECF3");
            });

            modelBuilder.Entity<FormDataAdjunto>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.Adjunto)
                    .WithMany()
                    .HasForeignKey(d => d.AdjuntoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FormDataA__Adjun__778AC167");

                entity.HasOne(d => d.FormData)
                    .WithMany()
                    .HasForeignKey(d => d.FormDataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FormDataA__FormD__76969D2E");
            });

            modelBuilder.Entity<Sistema>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
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
