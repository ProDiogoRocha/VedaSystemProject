using System;
using System.ComponentModel.DataAnnotations;

namespace VedaSystem.Application.ViewModels
{
    public class SendViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Destinatário é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Destinatário")]
        public string To { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Corpo do E-mail é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Corpo do E-mail")]
        public string Body { get; set; }

        [Display(Name = "Html no corpo do E-mail")]
        public bool IsBodyHtml { get; set; }

        [Display(Name = "Assunto")]
        public string Subject { get; set; }

        public Guid IdPrescricao { get; set; }
    }
}