using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.ViewModels
{
    public class FichaClinicaPacienteViewModel
    {
        public FichaClinicaPacienteViewModel()
        {
            TiposApetites = new[]
            {
                new SelectListItem {Value = "1", Text = "baixo"},
                new SelectListItem {Value = "2", Text = "médio"},
                new SelectListItem {Value = "3", Text = "alto"},
                new SelectListItem {Value = "4", Text = "irregular"}
            };

            QtdsSuor = new[]
            {
                new SelectListItem {Value = "1", Text = "pouco"},
                new SelectListItem {Value = "2", Text = "médio"},
                new SelectListItem {Value = "3", Text = "muito"}
            };

            QtdsFezes = new[]
            {
                new SelectListItem {Value = "1", Text = "pouco"},
                new SelectListItem {Value = "2", Text = "médio"},
                new SelectListItem {Value = "3", Text = "muito"}
            };

            QtdsUrina = new[]
            {
                new SelectListItem {Value = "1", Text = "pouco"},
                new SelectListItem {Value = "2", Text = "médio"},
                new SelectListItem {Value = "3", Text = "muito"}
            };
        }
        #region Dados pessoais
        public Guid Id { get; set; }
        public Guid PacienteId { get; set; }
        public Paciente Paciente { get; set; }

        [Display(Name = "Estado Civil")]
        public string EstadoCivil { get; set; }

        [Display(Name = "Profissão")]
        public string Profissao { get; set; }
        #endregion

        #region Queixas do paciente
        [Display(Name = "Queixas principais")]
        public string QuixasPrincipais { get; set; }
        [Display(Name = "Sintomas")]
        public string Sintomas { get; set; }
        [Display(Name = "A quanto tempo existem?")]
        public string TempoSintomas { get; set; }
        [Display(Name = "Pioram ou melhoram em alguma condição?")]
        public string PioramOuMelhoram { get; set; }
        #endregion

        #region Diagnóstico
        [Display(Name = "Pulso (vikriti)")]
        public string PulsoVikriti { get; set; }
        [Display(Name = "Observação da língua, características")]
        public string CaracteristicasLingua { get; set; }
        [Display(Name = "Observação das unhas, características")]
        public string CaracteristicasUnhas { get; set; }
        [Display(Name = "Observação do aspecto físico, características")]
        public string AspectoFisico { get; set; }
        [Display(Name = "Palpação, abdomen, parte do corpo (tecido) afetada")]
        public string Palpacao { get; set; }
        #endregion

        #region Rotina diária
        [Display(Name = "Que horas acorda")]
        public string HoraQueAcorda { get; set; }
        [Display(Name = "O que faz ao acordar")]
        public string OqueFazAoAcordar { get; set; }
        [Display(Name = "Que horas se deita para dormir")]
        public string HoraQueDorme { get; set; }
        [Display(Name = "Como é o Sono")]
        public string ComoEOSono { get; set; }
        [Display(Name = "O que faz a cada hora do dia")]
        public string OQueFazACadaHoraDoDia { get; set; }
        [Display(Name = "O que come em cada refeição")]
        public string OQueComeACadaRefeicao { get; set; }
        [Display(Name = "Horários das refeições")]
        public string HorariosDasRefeicoes { get; set; }
        #endregion

        #region Agni
        [Display(Name = "Como é o apetite do paciente?")]
        public string Apetite { get; set; }
        public IList<SelectListItem> TiposApetites { get; set; } 
        [Display(Name = "Sente fome verdadeira ou come por algum outro motivo? Hábito, ansiedade, conveniência, etc...")]
        public string MotivoFome { get; set; }
        [Display(Name = "Quanto tempo após a última refeição tem fome de novo?")]
        public string TempoFomeNovamente { get; set; }
        #endregion

        #region Malas
        [Display(Name = "Suor: pouco, médio, muito")]
        public string QtdSuor { get; set; }
        public IList<SelectListItem> QtdsSuor { get; set; }

        [Display(Name = "Tem cheiro? Descreva")]
        public string CheiroSuor { get; set; }
        [Display(Name ="Consistência do Suor")]
        public string ConsistenciaSuor { get; set; }
        [Display(Name = "Fezes: pouco, médio, muito")]
        public string QtdFezes { get; set; }
        public IList<SelectListItem> QtdsFezes { get; set; }
        [Display(Name ="Cheiro das fezes")]
        public string CheiroFezes { get; set; }
        [Display(Name = "Cor das fezes")]
        public string CorFezes { get; set; }
        [Display(Name = "Consistência das fezes")]
        public string ConsistenciaFezes { get; set; }
        [Display(Name = "Urina: pouco, médio")]
        public string QtdUrina { get; set; }
        public IList<SelectListItem> QtdsUrina { get; set; }
        [Display(Name = "Cor da urina")]
        public string CorUrina { get; set; }
        [Display(Name = "Cheiro da urina")]
        public string CheiroUrina { get; set; }
        [Display(Name = "Desconforto nas eliminações")]
        public string DesconfortoEliminacoes { get; set; }
        #endregion

        #region Vyayama(Exercicios)
        [Display(Name = "Tipo de exercício")]
        public string TipoExercicio { get; set; }
        [Display(Name = "Regularidade")]
        public string Regularidade { get; set; }
        [Display(Name = "Quantas horas (dia)")]
        public string QtdHorasPorDia { get; set; }
        #endregion

        #region Bala(Disposição)
        [Display(Name = "Se sente bem ao acordar?")]
        public string SeSenteBemAoAcordar { get; set; }
        [Display(Name = "Se sente bem ao longo do dia?")]
        public string SeSenteBemAoLongoDoDia { get; set; }
        [Display(Name = "Sente disposição ao se exercitar?")]
        public string SenteDisposicaoSeExercitar { get; set; }
        #endregion

        #region Raja(Menstruação)
        [Display(Name = "Regularidade/duração do ciclo")]
        public string RegularidadeDuracaoDoCiclo { get; set; }
        [Display(Name = "Fluxo")]
        public string Fluxo { get; set; }
        [Display(Name = "Algum distúrbio")]
        public string AlgumDisturbio { get; set; }
        #endregion

        #region Sono
        [Display(Name = "Sente que dorme bem")]
        public string SenteQueDormeBem { get; set; }
        [Display(Name = "Acorda a noite? Quantas vezes? Por quê?")]
        public string AcordaANoiteQuantasVezesPorQue { get; set; }
        [Display(Name = "Se sente restaurado pela manhã?")]
        public string SeSenteRestauradoPelaManha { get; set; }
        [Display(Name = "Sonha? Como são os sonhos?")]
        public string SonhaComoSaoOsSonhos { get; set; }
        #endregion

        #region Outras informações importantes
        [Display(Name = "Toma algum medicamento?")]
        public string TomaAlgumMedicamento { get; set; }
        [Display(Name = "Faz uso de alguma substância viciante (álcool, tabaco, etc)?")]
        public string FazUsoDeAlgumaSubstânciaViciante { get; set; }
        [Display(Name = "OBS: Algum outro dado importante ou histórico de doenças da família")]
        public string AlgumOutroDadoImportante { get; set; }
        #endregion
    }
}
