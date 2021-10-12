using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VedaSystem.Domain.Models;

namespace VedaSystem.Infra.Data.Mappings
{
    class TerapeutaMap : IEntityTypeConfiguration<Terapeuta>
    {
        public void Configure(EntityTypeBuilder<Terapeuta> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.NomeCompleto)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.NomeDeUsuario)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(t => t.Senha)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(t => t.ConfirmeSenha)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(t => t.Telefone)
                .HasMaxLength(30);

            builder.Property(t => t.Celular)
                .HasMaxLength(30);

            builder.Property(t => t.Email)
                .HasMaxLength(50);

            builder.Property(t => t.WhatsApp)
                .IsRequired();

            builder.HasOne(t => t.EmailConfig)
                .WithOne(e => e.Terapeuta)
                .HasForeignKey<Email>(e=> e.TerapeutaId);

            builder.Property(t => t.Site)
                .HasMaxLength(100);

            builder.Property(t => t.Endereco)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(t => t.Cep)
                .HasMaxLength(9)
                .IsRequired();

            builder.Property(t => t.Estado)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.Cidade)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(t => t.Bairro)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.CPF)
                .HasMaxLength(11);

            builder.Property(t => t.CNPJ)
                .HasMaxLength(20);

            builder.Property(t => t.TipoPessoa);

            builder.Property(t => t.Apresentacao)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.Observacoes)
                .HasMaxLength(300);

            builder.Property(t => t.DataCadastro)
                .IsRequired();

            builder.Property(t => t.DataNascimento)
                .IsRequired();

            builder.HasMany(t => t.Pacientes)
              .WithMany(p => p.Terapeutas);

            builder.Property(t => t.Logo);

            builder.HasMany(t => t.Terapias)
                .WithMany(t => t.Terapeutas)
                .UsingEntity(j => j.ToTable("TerapeutaTerapia"));

            builder.HasMany(t => t.TerapiasPrincipais)
                .WithMany(t => t.Terapeutas)
                .UsingEntity(j => j.ToTable("TerapeutaTerapiaPrincipal"));

            builder.HasMany(t => t.Pacientes)
                .WithMany(t => t.Terapeutas)
                .UsingEntity(j => j.ToTable("PacienteTerapeuta"));
        }
    }
}
