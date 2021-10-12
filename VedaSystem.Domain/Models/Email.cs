using Microsoft.AspNetCore.Http;
using Microsoft.Web.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Net.Mail;

namespace VedaSystem.Domain.Models
{
    [Table("Emails")]
    [Serializable]
    public class Email
    {
        public Guid Id { get; set; }
        public Guid TerapeutaId { get; set; }
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

        [NotMapped]
        public IFormFile Anexo { get; set; }

        [NotMapped]
        private IList<IFormFile> Anexos { get; set; }

        public IList<IFormFile> GetAnexos()
        {
            return Anexos;
        }
    }
}
