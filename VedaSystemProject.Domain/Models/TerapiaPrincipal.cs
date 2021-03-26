using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using VedaSystemProject.Domain.Interfaces;

namespace VedaSystemProject.Domain.Models
{
    [Table("TerapiaPrincipal")]
    public class TerapiaPrincipal : IBaseModel
    {
        public Guid? Id { get; set; }
        public Guid? IdTerapia { get; set; }
        public string NomeTerapia { get; set; }
        public TimeSpan Duracao { get; set; }
        public virtual ICollection<MaterialTerapia> Materiais { get; set; }
        public virtual ICollection<Terapeuta> Terapeutas { get; set; }
        public virtual ICollection<Agenda> Agendas { get; set; }
        public string Observacao { get; set; }
    }
}
