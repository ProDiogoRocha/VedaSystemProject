using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using VedaSystem.Domain.Models;

namespace VedaSystem.Infra.Data.Mappings
{
    public class TerapiaPrincipalMap : IEntityTypeConfiguration<TerapiaPrincipal>
    {
        public void Configure(EntityTypeBuilder<TerapiaPrincipal> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.NomeTerapia)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.Duracao)
                .IsRequired();

            //builder.HasMany(t => t.Materiais)
            //    .WithOne(m => m.TerapiaPrincipal)
            //    .HasForeignKey(m => m.TerapiaId);

            builder.Property(t => t.Observacao)
                .HasMaxLength(300);

            builder.HasMany(t => t.Terapeutas)
                .WithMany(t => t.TerapiasPrincipais);
        }
    }
}
