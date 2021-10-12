using Microsoft.AspNetCore.Http;
using MimeKit;
using OpenPop.Mime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using VedaSystem.Domain.Enums;

namespace VedaSystem.Application.ViewModels
{
    public class EmailMessageViewModel
    {
        public string Id { get; set; }
        public int Order { get; set; }
        public Guid TerapeutaId { get; set; }
        public bool Selected { get; set; }
        public bool Benchmark { get; set; }
        public char PrimeiraLetraDoNome { get; set; }
        public CorRadius CorRadius { get; set; }
        public string De { get; set; }
        public Tag Tag { get; set; }
        public Grupo Grupo { get; set; }
        public string Titulo { get; set; }
        public bool ExistemAnexos { get; set; }
        public string Horario { get; set; }
        public DateTime Data { get; set; }
        public bool Lido { get; set; }
        public string Para { get; set; }
        public string Subject { get; set; }
        public IList<MimeEntity> Anexos { get; set; }
        public string BodyText { get; set; }
        public string BodyHtml { get; set; }
        public bool Rascunho { get; set; }
        public bool Enviado { get; set; }
        public bool Excluido { get; set; }
        public string To { get; set; }
    }
}
