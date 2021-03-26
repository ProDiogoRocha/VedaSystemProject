using Microsoft.EntityFrameworkCore;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Mappings;

namespace VedaSystem.Infra.Data.Context
{
    public class HorarioContext : DbContext
    {
        public HorarioContext(DbContextOptions<HorarioContext> options) : base(options)
        {
        }
        public DbSet<Horario> Horarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HorarioMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
