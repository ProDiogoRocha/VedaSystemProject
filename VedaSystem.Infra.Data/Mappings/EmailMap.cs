using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VedaSystem.Domain.Models;

namespace VedaSystem.Infra.Data.Mappings
{
    public class EmailMap : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.Terapeuta)
                .WithOne(t => t.EmailConfig)
                .HasForeignKey<Email>(e => e.TerapeutaId);
            builder.Property(e => e.EnableSsl).IsRequired();
            builder.Property(e => e.Port).IsRequired();
            builder.Property(e => e.DeliveryMethod).IsRequired();
            builder.Property(e => e.UseDefaultCredentials);
            builder.Property(e => e.EmailAdress).IsRequired();
            builder.Property(e => e.Password).IsRequired();
            builder.Property(e => e.To);
            builder.Property(e => e.Subject);
            builder.Property(e => e.Body);
            builder.Property(e => e.IsBodyHtml).IsRequired();
            builder.Property(e => e.Smtp).IsRequired();
        }
    }
}
