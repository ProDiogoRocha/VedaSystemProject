using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VedaSystem.Domain.Models
{
    [Table("QuestionarioPosDiagnostico")]
    public class QuestionarioPosDiagnostico
    {
        public Guid? Id { get; set; }
        public Guid PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public Guid TerapeutaId { get; set; }
        public Terapeuta Terapeuta { get; set; }
        public string PeriodoShamana { get; set; }
        public string SeguiuAdequadamente { get; set; }
        public string BeneficiosTratamento { get; set; }
        public string QueixasPersistentes { get; set; }
        public string CaracteristicasFezes { get; set; }
        public string CaracteristicasUrina { get; set; }
        public string Apetite { get; set; }
        public string Disposição { get; set; }
        public string Sono { get; set; }
        public string ComentarioAdicional { get; set; }
    }
}
