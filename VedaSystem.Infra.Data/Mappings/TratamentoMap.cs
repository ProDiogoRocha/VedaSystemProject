using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VedaSystem.Domain.Models;

namespace VedaSystem.Infra.Data.Mappings
{
    public class TratamentoMap : IEntityTypeConfiguration<Tratamento>
    {
        public void Configure(EntityTypeBuilder<Tratamento> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.DescricaoTratamento)
                    .HasMaxLength(300)
                    .IsRequired();
        }
    }
}
