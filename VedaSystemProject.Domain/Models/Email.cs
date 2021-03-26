using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;
using VedaSystemProject.Domain.Interfaces;

namespace VedaSystemProject.Domain.Models
{
    [Table("Email")]
    public class Email : IBaseModel
    {
        public Guid? Id { get; set; }
        public virtual Terapeuta Terapeuta { get; set; }
        public bool EnableSsl { get; set; }
        public int Port { get; set; }
        public SmtpDeliveryMethod DeliveryMethod { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public string EmailAdress { get; set; }
        public string Password { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsBodyHtml { get; set; }
        public string Smtp { get; set; }
    }
}
