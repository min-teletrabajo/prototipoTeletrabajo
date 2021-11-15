using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Teletrabajo.Models
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

        public virtual DbSet<Adjunto> Adjunto { get; set; }
        public virtual DbSet<Form> Form { get; set; }
        public virtual DbSet<FormData> FormData { get; set; }
        public virtual DbSet<FormDataAdjunto> FormDataAdjunto { get; set; }
        public virtual DbSet<Sistema> Sistema { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:teletrabajodb.database.windows.net,1433;Initial Catalog=Teletrabajo;Persist Security Info=False;User ID=admin123;Password=Teletrabajo123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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

                entity.HasOne(d => d.Sistema)
                    .WithMany(p => p.Form)
                    .HasForeignKey(d => d.SistemaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Form__SistemaId__6D0D32F4");
            });

            modelBuilder.Entity<FormData>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Data).IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("date");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(20)
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
                    .HasConstraintName("FK__FormData__FormId__6FE99F9F");
            });

            modelBuilder.Entity<FormDataAdjunto>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.Adjunto)
                    .WithMany()
                    .HasForeignKey(d => d.AdjuntoId)
                    .HasConstraintName("FK__FormDataA__Adjun__74AE54BC");

                entity.HasOne(d => d.FormData)
                    .WithMany()
                    .HasForeignKey(d => d.FormDataId)
                    .HasConstraintName("FK__FormDataA__FormD__73BA3083");
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
