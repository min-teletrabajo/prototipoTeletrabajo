using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Migracion.Models
{
    public class TeletrabajoDbContext : DbContext
    {
        public TeletrabajoDbContext()
        {

        }
        public TeletrabajoDbContext(DbContextOptions<TeletrabajoDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Adjunto> Adjunto { get; set; }
        public virtual DbSet<Form> Form { get; set; }
        public virtual DbSet<FormData> FormData { get; set; }
        public virtual DbSet<FormDataAdjunto> FormDataAdjunto { get; set; }
        public virtual DbSet<Sistema> Sistema { get; set; }
    }
}
