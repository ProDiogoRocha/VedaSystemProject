using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VedaSystem.Domain.Models;

namespace VedaSystem.Infra.Data.Mappings
{
    public class HorarioMap : IEntityTypeConfiguration<Horario>
    {
        public void Configure(EntityTypeBuilder<Horario> builder)
        {
            builder.HasKey(h => h.Id);

            builder.HasOne(h => h.Terapeuta)
            .WithMany(t => t.Horarios)
            .HasForeignKey(a => a.TerapeutaId);

            builder.Property(h => h.Hora)
                   .IsRequired();

            builder.Property(h => h.Reservado)
                   .IsRequired();

            builder.Property(h => h.Dia)
                   .IsRequired();

            builder.Property(h => h.Mes)
                   .IsRequired();

            builder.Property(h => h.Ano)
                   .IsRequired();

            builder.Property(h => h.DuracaoConsultaEmMinutos)
                    .IsRequired();

            builder.Property(h => h.Intervalo);
        }
    }
}
