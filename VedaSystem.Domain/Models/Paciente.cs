using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VedaSystem.Domain.Models
{
    [Table("Pacientes")]
    public class Paciente
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public float Peso { get; set; }
        public float Altura { get; set; }
        public string RedeSocial { get; set; }
        public string MotivoConsulta { get; set; }
        public virtual IList<Prescricao> Prescricoes { get; set; }
        public virtual IList<Terapeuta> Terapeutas { get; set; }
        public virtual IList<Agenda> Agendas { get; set; }
        public virtual IList<FichaClinicaPaciente> FichasClinicas { get; set; }
        public virtual IList<QuestionarioPosDiagnostico> QuestionariosPosDiagnosticos { get; set; }
    }
}
