using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VedaSystem.Domain.Models;

namespace VedaSystem.Infra.Data.Mappings
{
    public class PrescricaoMap : IEntityTypeConfiguration<Prescricao>
    {
        public void Configure(EntityTypeBuilder<Prescricao> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Logo);

            builder.HasOne(p => p.Terapeuta)
                .WithMany(t => t.Precricoes)
                .HasForeignKey(p => p.TerapeutaId);

            builder.HasOne(p => p.Paciente)
                .WithMany(pa => pa.Prescricoes)
                .HasForeignKey(p => p.PacienteId);

            builder.Property(p => p.DataDaPrescricao)
                .IsRequired();

            builder.Property(p => p.ValidadeDaPrescricao)
                .IsRequired();

            builder.HasMany(p => p.Tratamentos)
                .WithOne(t => t.Prescricao)
                .HasForeignKey(p => p.PrescricaoId);

            builder.HasMany(p => p.Medicamentos)
                .WithMany(m => m.Prescricoes)
                .UsingEntity(j => j.ToTable("MedicamentoPrescricao"));
        }
    }
}
