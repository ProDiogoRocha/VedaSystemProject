using System;
using System.ComponentModel.DataAnnotations;

namespace VedaSystemProject.Application.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Nome de Usuario é obrigatório", AllowEmptyStrings = false)]
        [StringLength(80, ErrorMessage = "O Nome deve conter entre 5 e 80 caracteres", MinimumLength = 5)]
        [Display(Name = "Nome de Usuario")]
        public string NomeDeUsuario { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Senha é obrigatório", AllowEmptyStrings = false)]
        [StringLength(9, ErrorMessage = "A senha deve conter entre 6 e 9 caracteres", MinimumLength = 6)]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Confirmar Senha é obrigatório")]
        [StringLength(9, ErrorMessage = "A senha deve conter entre 6 e 9 caracteres", MinimumLength = 6)]
        [Display(Name = "Confirmar Senha")]
        [DataType(DataType.Password)]
        [Compare("ConfirmeSenha")]
        public string ConfirmeSenha { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Data de Nascimento é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Endereço é obrigatório", AllowEmptyStrings = false)]
        [StringLength(80, ErrorMessage = "O endereço deve conter entre 20 e 80 caracteres", MinimumLength = 20)]

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo E-mail é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public int TipoUsuario { get; set; } = 2;
    }
}
