using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VedaSystem.Domain.Models;

namespace VedaSystem.Infra.Data.Mappings
{
    public class InfoMailMap : IEntityTypeConfiguration<InfoMail>
    {
        public void Configure(EntityTypeBuilder<InfoMail> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.TerapeutaId);
            builder.Property(e => e.Order);
            builder.Property(e => e.Lido);
            builder.Property(e => e.Grupo);
            builder.Property(e => e.Tag);
            builder.Property(e => e.Benchmark);
            builder.Property(e => e.Rascunho);
            builder.Property(e => e.Enviado);
            builder.Property(e => e.Excluido);
            builder.Property(e => e.To);
            builder.Property(e => e.Subject);
            builder.Property(e => e.Body);
            builder.Property(e => e.DataDeEnvio);
        }
    }
}
