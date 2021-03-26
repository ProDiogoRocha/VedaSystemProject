using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VedaSystem.Domain.Models;

namespace VedaSystem.Infra.Data.Mappings
{
    public class PacienteMap : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                    .HasMaxLength(50)
                    .IsRequired();

            builder.Property(p => p.Email)
                    .HasMaxLength(30)
                    .IsRequired();

            builder.Property(p => p.DataNascimento)
                    .IsRequired();

            builder.Property(p => p.Telefone)
                    .HasMaxLength(30)
                    .IsRequired();

            builder.Property(p => p.Peso)
                    .IsRequired();

            builder.Property(p => p.Altura)
                    .IsRequired();

            builder.Property(p => p.RedeSocial)
                    .HasMaxLength(30);

            builder.Property(p => p.MotivoConsulta)
                    .HasMaxLength(60);

            builder.HasMany(p => p.Prescricoes)
                .WithOne(p=>p.Paciente)
                .HasForeignKey(p => p.PacienteId);

            builder.HasMany(p => p.Agendas)
                .WithOne(p=>p.Paciente)
                .HasForeignKey(p => p.PacienteId);
        }
    }
}
