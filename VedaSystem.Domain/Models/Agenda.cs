using System;
using System.ComponentModel.DataAnnotations.Schema;
using VedaSystem.Domain.Enums;

namespace VedaSystem.Domain.Models
{
    [Table("Agendas")]
    public class Agenda 
    { 
        public Guid? Id { get; set; }
        public Guid? PacienteId { get; set; }
        public virtual Paciente Paciente { get; set; }
        public DiaSemana DiaSemana { get; set; }
        public int DiaMes { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public Guid? TerapiaId { get; set; }
        public virtual Terapia Terapia { get; set; }
        public Guid? TerapeutaId { get; set; }
        public virtual Terapeuta Terapeuta { get; set; }
    }
}
