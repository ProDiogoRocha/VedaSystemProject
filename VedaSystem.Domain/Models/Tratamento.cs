using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VedaSystem.Domain.Models
{
    [Table("Tratamentos")]
    public class Tratamento
    {
        public Guid? Id { get; set; }
        public int Ordem { get; set; }
        public string DescricaoTratamento { get; set; }
        public Guid MeidcamentoId { get; set; }
        public string Medicamento { get; set; }
        public Guid PrescricaoId { get; set; }
        public virtual Prescricao Prescricao { get; set; }
    }
}
