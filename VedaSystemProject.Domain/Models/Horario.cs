using System;
using System.ComponentModel.DataAnnotations.Schema;
using VedaSystemProject.Domain.Interfaces;

namespace VedaSystemProject.Domain.Models
{
    [Table("Horario")]
    public class Horario : IBaseModel
    {
        public Guid? Id { get; set; }
        public Guid TerapeutaId { get; set; }
        public virtual Terapeuta Terapeuta { get; set; }
        public DateTime Hora { get; set; }
        public bool Reservado { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
    }
}
