using Microsoft.EntityFrameworkCore;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Mappings;

namespace VedaSystem.Infra.Data.Context
{
    public class TerapiaContext : DbContext
    {
        public TerapiaContext(DbContextOptions<TerapiaContext> options) : base(options)
        {
        }
        public DbSet<Terapia> Terapias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TerapiaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
