using System;

namespace VedaSystem.Domain.Models
{
    public class FichaClinicaPaciente
    {
        #region Dados pessoais
        public Guid Id { get; set; }
        public Guid TerapeutaId { get; set; }
        public virtual Terapeuta Terapeuta { get; set; }
        public Guid PacienteId { get; set; }
        public virtual Paciente Paciente { get; set; }
        public string EstadoCivil { get; set; }
        public string Profissao { get; set; }
        #endregion

        #region Queixas do paciente
        public string QuixasPrincipais { get; set; }
        public string Sintomas { get; set; }
        public string TempoSintomas { get; set; }
        public string PioramOuMelhoram { get; set; }
        #endregion

        #region Diagnóstico
        public string PulsoVikriti { get; set; }
        public string CaracteristicasLingua { get; set; }
        public string CaracteristicasUnhas { get; set; }
        public string AspectoFisico { get; set; }
        public string Palpacao { get; set; }
        #endregion

        #region Rotina diária
        public string HoraQueAcorda { get; set; }
        public string OqueFazAoAcordar { get; set; }
        public string HoraQueDorme { get; set; }
        public string ComoEOSono { get; set; }
        public string OQueFazACadaHoraDoDia { get; set; }
        public string OQueComeACadaRefeicao { get; set; }
        public string HorariosDasRefeicoes { get; set; }
        #endregion

        #region Agni
        public string Apetite { get; set; }
        public string MotivoFome { get; set; }
        public string TempoFomeNovamente { get; set; }
        #endregion

        #region Malas
        public string QtdSuor { get; set; }
        public string CheiroSuor { get; set; }
        public string ConsistenciaSuor { get; set; }
        public string QtdFezes { get; set; }
        public string CheiroFezes { get; set; }
        public string CorFezes { get; set; }
        public string ConsistenciaFezes { get; set; }
        public string QtdUrina { get; set; }
        public string CorUrina { get; set; }
        public string CheiroUrina { get; set; }
        public string DesconfortoEliminacoes { get; set; }
        #endregion

        #region Vyayama(Exercicios)
        public string TipoExercicio { get; set; }
        public string Regularidade { get; set; }
        public string QtdHorasPorDia { get; set; }
        #endregion

        #region Bala(Disposição)
        public string SeSenteBemAoAcordar { get; set; }
        public string SeSenteBemAoLongoDoDia { get; set; }
        public string SenteDisposicaoSeExercitar { get; set; }
        #endregion

        #region Raja(Menstruação)
        public string RegularidadeDuracaoDoCiclo { get; set; }
        public string Fluxo { get; set; }
        public string AlgumDisturbio { get; set; }
        #endregion

        #region Sono
        public string SenteQueDormeBem { get; set; }
        public string AcordaANoiteQuantasVezesPorQue { get; set; }
        public string SeSenteRestauradoPelaManha { get; set; }
        public string SonhaComoSaoOsSonhos { get; set; }
        #endregion

        #region Outras informações importantes
        public string TomaAlgumMedicamento { get; set; }
        public string FazUsoDeAlgumaSubstânciaViciante { get; set; }
        public string AlgumOutroDadoImportante  { get; set; }
        #endregion
    }
}
