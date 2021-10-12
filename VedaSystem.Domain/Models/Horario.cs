using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VedaSystem.Domain.Models
{
    [Table("Horarios")]
    public class Horario
    {
        public Guid? Id { get; set; }
        public Guid TerapeutaId { get; set; }
        public virtual Terapeuta Terapeuta { get; set; }
        public Guid TerapiaId { get; set; }
        public DateTime Hora { get; set; }
        public int DuracaoConsultaEmMinutos { get; set; }
        public int Intervalo { get; set; }
        public bool Reservado { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
    }
}
