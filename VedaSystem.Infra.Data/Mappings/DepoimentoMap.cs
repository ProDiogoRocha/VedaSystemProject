using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VedaSystem.Domain.Models;

namespace VedaSystem.Infra.Data.Mappings
{
    public class DepoimentoMap : IEntityTypeConfiguration<Depoimento>
    {
        public void Configure(EntityTypeBuilder<Depoimento> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Titulo);
            builder.Property(a => a.QuantidadeEstrelas);
            builder.Property(a => a.Avaliação);
            builder.Property(a => a.Nome);
            builder.HasOne(a => a.Usuario)
                .WithOne(a => a.Depoimento);
        }
    }
}
