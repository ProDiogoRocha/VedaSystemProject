using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VedaSystem.Domain.Models;

namespace VedaSystem.Infra.Data.Mappings
{
    class FichaClinicaPacienteMap : IEntityTypeConfiguration<FichaClinicaPaciente>
    {
        public void Configure(EntityTypeBuilder<FichaClinicaPaciente> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Paciente)
                .WithMany(a => a.FichasClinicas)
                .HasForeignKey(a => a.PacienteId);
            builder.HasOne(a => a.Terapeuta)
                .WithMany(a => a.FichaClinicaPacientes)
                .HasForeignKey(a => a.TerapeutaId);
            builder.Property(a => a.EstadoCivil);
            builder.Property(a => a.Profissao);
            builder.Property(a => a.QuixasPrincipais);
            builder.Property(a => a.Sintomas);
            builder.Property(a => a.TempoSintomas);
            builder.Property(a => a.PioramOuMelhoram);
            builder.Property(a => a.PulsoVikriti);
            builder.Property(a => a.CaracteristicasLingua);
            builder.Property(a => a.CaracteristicasUnhas);
            builder.Property(a => a.AspectoFisico);
            builder.Property(a => a.Palpacao);
            builder.Property(a => a.HoraQueAcorda);
            builder.Property(a => a.OqueFazAoAcordar);
            builder.Property(a => a.HoraQueDorme);
            builder.Property(a => a.ComoEOSono);
            builder.Property(a => a.OQueFazACadaHoraDoDia);
            builder.Property(a => a.OQueComeACadaRefeicao);
            builder.Property(a => a.HorariosDasRefeicoes);
            builder.Property(a => a.Apetite);
            builder.Property(a => a.MotivoFome);
            builder.Property(a => a.TempoFomeNovamente);
            builder.Property(a => a.QtdSuor);
            builder.Property(a => a.CheiroSuor);
            builder.Property(a => a.ConsistenciaSuor);
            builder.Property(a => a.QtdFezes);
            builder.Property(a => a.CheiroFezes);
            builder.Property(a => a.CorFezes);
            builder.Property(a => a.ConsistenciaFezes);
            builder.Property(a => a.QtdUrina);
            builder.Property(a => a.CorUrina);
            builder.Property(a => a.CheiroUrina);
            builder.Property(a => a.DesconfortoEliminacoes);
            builder.Property(a => a.TipoExercicio);
            builder.Property(a => a.Regularidade);
            builder.Property(a => a.QtdHorasPorDia);
            builder.Property(a => a.SeSenteBemAoAcordar);
            builder.Property(a => a.SeSenteBemAoLongoDoDia);
            builder.Property(a => a.SenteDisposicaoSeExercitar);
            builder.Property(a => a.RegularidadeDuracaoDoCiclo);
            builder.Property(a => a.Fluxo);
            builder.Property(a => a.AlgumDisturbio);
            builder.Property(a => a.SenteQueDormeBem);
            builder.Property(a => a.AcordaANoiteQuantasVezesPorQue);
            builder.Property(a => a.SeSenteRestauradoPelaManha);
            builder.Property(a => a.SonhaComoSaoOsSonhos);
            builder.Property(a => a.TomaAlgumMedicamento);
            builder.Property(a => a.FazUsoDeAlgumaSubstânciaViciante);
            builder.Property(a => a.AlgumOutroDadoImportante);
        }
    }
}
