using System;
using System.Collections.Generic;

namespace VedaSystem.Application.ViewModels
{
    public class PrescricaoViewModel
    {
        public Guid? Id { get; set; }
        public byte[] Logo { get; set; }
        public Guid IdTerapeuta { get; set; }
        public TerapeutaViewModel Terapeuta { get; set; }
        public Guid IdPaciente { get; set; }
        public PacienteViewModel Paciente { get; set; }
        public Guid MedicamentoId { get; set; }
        public IList<PacienteViewModel> Pacientes { get; set; }
        public PacienteViewModel PacienteSelecionado { get; set; }
        public IList<MedicamentoViewModel> Medicamentos { get; set; }
        public MedicamentoViewModel MedicamentoSelecionado { get; set; }
        public IList<TratamentoViewModel> Tratamentos { get; set; }
        public DateTime DataDaPrescricao { get; set; }
        public DateTime ValidadeDaPrescricao { get; set; }
        public string DescricaoTratamento { get; set; }
        public bool EnviarPorEmail { get; set; }
    }
}