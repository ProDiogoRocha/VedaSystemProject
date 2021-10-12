using Microsoft.EntityFrameworkCore;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Mappings;

namespace VedaSystem.Infra.Data.Context
{
    public class FichaClinicaPacienteContext : DbContext
    {
        public FichaClinicaPacienteContext(DbContextOptions<FichaClinicaPacienteContext> options) : base(options)
        {
        }

        public DbSet<FichaClinicaPaciente> FichaClinicaPaciente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FichaClinicaPacienteMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
