using System;
using System.ComponentModel.DataAnnotations;

namespace VedaSystem.Application.ViewModels
{
    public class LoginViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo E-mail é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Senha é obrigatório", AllowEmptyStrings = false)]
        [StringLength(9, ErrorMessage = "A senha deve conter entre 6 e 8 caracteres", MinimumLength = 6)]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
