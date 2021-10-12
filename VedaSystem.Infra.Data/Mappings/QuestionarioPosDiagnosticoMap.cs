using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VedaSystem.Domain.Models;

namespace VedaSystem.Infra.Data.Mappings
{
    public class QuestionarioPosDiagnosticoMap : IEntityTypeConfiguration<QuestionarioPosDiagnostico>
    {
        public void Configure(EntityTypeBuilder<QuestionarioPosDiagnostico> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasOne(a => a.Paciente)
                .WithMany(a => a.QuestionariosPosDiagnosticos)
                .HasForeignKey(a => a.PacienteId);
            builder.HasOne(a => a.Terapeuta)
            .WithMany(a => a.QuestionarioPosDiagnosticos)
            .HasForeignKey(a => a.TerapeutaId);
            builder.Property(a => a.Apetite).IsRequired();
            builder.Property(a => a.BeneficiosTratamento).IsRequired();
            builder.Property(a => a.CaracteristicasFezes).IsRequired();
            builder.Property(a => a.CaracteristicasUrina).IsRequired();
            builder.Property(a => a.ComentarioAdicional);
            builder.Property(a => a.Disposição).IsRequired();
            builder.Property(a => a.PeriodoShamana).IsRequired();
            builder.Property(a => a.QueixasPersistentes);
            builder.Property(a => a.SeguiuAdequadamente).IsRequired();
            builder.Property(a => a.Sono).IsRequired();
        }
    }
}
