using System;
using System.ComponentModel.DataAnnotations;

namespace VedaSystem.Application.ViewModels
{
    public class TratamentoViewModel
    {
        [Key]
        public Guid? Id { get; set; }
        public int Ordem { get; set; }
        public string DescricaoTratamento { get; set; }
        public Guid MeidcamentoId { get; set; }
        public string Medicamento { get; set; }
        public Guid PrescricaoId { get; set; }
    }
}