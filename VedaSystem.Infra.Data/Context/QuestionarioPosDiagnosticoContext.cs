using Microsoft.EntityFrameworkCore;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Mappings;

namespace VedaSystem.Infra.Data.Context
{
    public class QuestionarioPosDiagnosticoContext : DbContext
    {
        public QuestionarioPosDiagnosticoContext(DbContextOptions<QuestionarioPosDiagnosticoContext> options) : base(options)
        {
        }

        public DbSet<QuestionarioPosDiagnostico> QuestionarioPosDiagnostico { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new QuestionarioPosDiagnosticoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
