using System;
using System.ComponentModel.DataAnnotations.Schema;
using VedaSystemProject.Domain.Interfaces;

namespace VedaSystemProject.Domain.Models
{
    [Table("Tratamento")]
    public class Tratamento : IBaseModel
    {
        public Guid? Id { get; set; }
        public int Ordem { get; set; }
        public string DescricaoTratamento { get; set; }
        public Guid MedicamentoId { get; set; }
        public string Medicamento { get; set; }
        public Guid PrescricaoId { get; set; }
        public virtual Prescricao Prescricao { get; set; }
    }
}
