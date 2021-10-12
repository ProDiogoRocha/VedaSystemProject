using MimeKit;
using System;
using System.Collections.Generic;

namespace VedaSystem.Domain.Models
{
    public class EmailMessageTran
    { 
        public string Id {get; set;}
        public int Order { get; set; }
        public string Subject { get; set; }
        public DateTime Data { get; set; }
        public string De { get; set; }
        public string Horario { get; set; }
        public char PrimeiraLetraDoNome { get; set; }
        public bool ExistemAnexos { get; set; }
        public Guid TerapeutaId { get; set; }
        public string Titulo { get; set; }
        public string BodyText { get; set; }
        public string BodyHtml { get; set; }
        public string Para { get; set; }
        public IList<MimeEntity> Anexos { get; set; }

    }
}
