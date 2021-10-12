using System;
using VedaSystem.Domain.Enums;

namespace VedaSystem.Domain.Models
{
    public class InfoMail
    {
        public string Id { get; set; }
        public int Order { get; set; }
        public Guid TerapeutaId { get; set; }
        public bool Lido { get; set; }
        public Grupo Grupo { get; set; }
        public Tag Tag { get; set; }
        public bool Benchmark { get; set; }
        public bool Rascunho { get; set; }  
        public bool Enviado { get; set; }
        public bool Excluido { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime DataDeEnvio { get; set; }
    }
}
