using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VedaSystem.Domain.Models
{
    [Table("Prescricoes")]
    public class Prescricao
    {
        public Guid? Id { get; set; }
        public byte[] Logo { get; set; }
        public Guid? TerapeutaId { get; set; }
        public virtual Terapeuta Terapeuta { get; set; }
        public Guid PacienteId { get; set; }
        public virtual Paciente Paciente { get; set; }
        [NotMapped]
        public Guid MedicamentoId { get; set; }
        public virtual IList<Medicamento> Medicamentos { get; set; }
        public virtual IList<Tratamento> Tratamentos { get; set; }
        public DateTime DataDaPrescricao { get; set; }
        public DateTime ValidadeDaPrescricao { get; set; }
    }
}
