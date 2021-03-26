using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using VedaSystemProject.Domain.Interfaces;

namespace VedaSystemProject.Domain.Models
{
    [Table("Paciente")]
    public class Paciente : IBaseModel
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
        public virtual ICollection<Prescricao> Prescricoes { get; set; }
        public virtual ICollection<Terapeuta> Terapeutas { get; set; }
        public virtual ICollection<Agenda> Agendas { get; set; }
    }
}
