using Microsoft.EntityFrameworkCore;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Mappings;

namespace VedaSystem.Infra.Data.Context
{
    public class EstoqueMaterialContext : DbContext
    {
        public EstoqueMaterialContext(DbContextOptions<EstoqueMaterialContext> options) : base(options)
        {
        }
        public DbSet<EstoqueMaterial> EstoqueMateriais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EstoqueMaterialMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
