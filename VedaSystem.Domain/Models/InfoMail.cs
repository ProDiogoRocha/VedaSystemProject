using System;
using VedaSystem.Domain.Enums;

namespace VedaSystem.Domain.Models
{
    public class InfoMail
    {
        public string Id { get; set; }
        public Guid TerapeutaId { get; set; }
        public bool Lido { get; set; }
        public Grupo Grupo { get; set; }
        public Tag Tag { get; set; }
        public bool Benchmark { get; set; }
    }
}
