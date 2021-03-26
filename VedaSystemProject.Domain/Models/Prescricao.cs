using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using VedaSystemProject.Domain.Interfaces;

namespace VedaSystemProject.Domain.Models
{
    [Table("Prescricao")]
    public class Prescricao : IBaseModel
    {
        public Guid? Id { get; set; }
        public byte[] Logo { get; set; }
        public Guid? TerapeutaId { get; set; }
        public virtual Terapeuta Terapeuta { get; set; }
        public Guid PacienteId { get; set; }
        public virtual Paciente Paciente { get; set; }
        [NotMapped]
        public Guid MedicamentoId { get; set; }
        [NotMapped]
        public ICollection<Medicamento> Medicamentos { get; set; }
        public virtual ICollection<Tratamento> Tratamentos { get; set; }
        public DateTime DataDaPrescricao { get; set; }
        public DateTime ValidadeDaPrescricao { get; set; }
    }
}
