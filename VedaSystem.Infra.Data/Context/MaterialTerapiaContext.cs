using Microsoft.EntityFrameworkCore;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Mappings;

namespace VedaSystem.Infra.Data.Context
{
    public class MaterialTerapiaContext : DbContext
    {
        public MaterialTerapiaContext(DbContextOptions<MaterialTerapiaContext> options) : base(options)
        {
        }
        public DbSet<MaterialTerapia> MaterialTerapias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MaterialTerapiaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
