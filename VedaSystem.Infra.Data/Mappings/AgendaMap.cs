using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VedaSystem.Domain.Models;

namespace VedaSystem.Infra.Data.Mappings
{
    public class AgendaMap : IEntityTypeConfiguration<Agenda>
    {
        public void Configure(EntityTypeBuilder<Agenda> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Terapeuta)
            .WithMany(a => a.Agendas)
            .HasForeignKey(a => a.TerapeutaId);

            builder.HasOne(a => a.Paciente)
            .WithMany(a => a.Agendas)
            .HasForeignKey(a => a.PacienteId);

            builder.HasOne(a => a.Terapia)
            .WithMany(a => a.Agendas)
            .HasForeignKey(a => a.TerapiaId);

            builder.Property(a => a.DiaSemana)
                    .IsRequired();

            builder.Property(a => a.DiaMes)
                    .IsRequired();

            builder.Property(a => a.Mes)
                    .IsRequired();

            builder.Property(a => a.Ano)
                    .IsRequired();
        }
    }
}
