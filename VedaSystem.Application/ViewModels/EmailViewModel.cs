using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Net.Mail;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.ViewModels
{
    public class EmailViewModel
    {
        public Guid Id { get; set; }
        public virtual Terapeuta Terapeuta { get; set; }
        public bool EnableSsl { get; set; }
        public int Port { get; set; }
        public SmtpDeliveryMethod DeliveryMethod { get; set; }
        public bool UseDefaultCredentials { get; set; } = false;
        public string EmailAdress { get; set; }
        public string Password { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsBodyHtml { get; set; } = false;
        public string Smtp { get; set; }
        public SelectListItem DeliveryMethodText { get; set; }
    }
}
