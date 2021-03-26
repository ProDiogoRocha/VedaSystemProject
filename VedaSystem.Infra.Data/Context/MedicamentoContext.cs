using Microsoft.EntityFrameworkCore;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Mappings;

namespace VedaSystem.Infra.Data.Context
{
    public class MedicamentoContext : DbContext
    {
        public MedicamentoContext(DbContextOptions<MedicamentoContext> options) : base(options)
        {
        }
        public DbSet<Medicamento> Medicamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MedicamentoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
