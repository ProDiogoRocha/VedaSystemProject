using Microsoft.EntityFrameworkCore;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Mappings;

namespace VedaSystem.Infra.Data.Context
{
    public class DepoimentoContext : DbContext
    {
        public DepoimentoContext(DbContextOptions<DepoimentoContext> options) : base(options)
        {
        }
        public DbSet<Depoimento> Depoimentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepoimentoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
