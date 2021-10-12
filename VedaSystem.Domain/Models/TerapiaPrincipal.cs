using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VedaSystem.Domain.Models
{
    [Table("TerapiaPrincipais")]
    public class TerapiaPrincipal
    {
        public Guid? Id { get; set; }
        public Guid? TerapiaId { get; set; }
        public string NomeTerapia { get; set; }
        public TimeSpan Duracao { get; set; }
        public virtual IList<Terapeuta> Terapeutas { get; set; }
        public virtual IList<Agenda> Agendas { get; set; }
        public string Observacao { get; set; }
    }
}
