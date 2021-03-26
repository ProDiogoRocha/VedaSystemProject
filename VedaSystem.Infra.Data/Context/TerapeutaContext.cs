using Microsoft.EntityFrameworkCore;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Mappings;

namespace VedaSystem.Infra.Data.Context
{
    public class TerapeutaContext : DbContext
    {
        public TerapeutaContext(DbContextOptions<TerapeutaContext> options) : base(options)
        {
        }
        public DbSet<Terapeuta> Terapeutas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TerapeutaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
