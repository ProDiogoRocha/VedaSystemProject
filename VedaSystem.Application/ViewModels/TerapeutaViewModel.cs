using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VedaSystem.Domain.Enums;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.ViewModels
{
    [Serializable]
    public class TerapeutaViewModel
    {
        [Key]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Nome Completo é obrigatório", AllowEmptyStrings = false)]
        [StringLength(80, ErrorMessage = "O Nome deve conter entre 5 e 80 caracteres", MinimumLength = 5)]
        [Display(Name = "Nome Completo")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Nome Completo é obrigatório", AllowEmptyStrings = false)]
        [StringLength(15, ErrorMessage = "O Nome de Usuario deve conter entre 5 e 15 caracteres", MinimumLength = 5)]
        [Display(Name = "Nome de Usuario")]
        public string NomeDeUsuario { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Senha é obrigatório", AllowEmptyStrings = false)]
        [StringLength(9, ErrorMessage = "A senha deve conter entre 6 e 8 caracteres", MinimumLength = 6)]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Confirmar Senha é obrigatório")]
        [StringLength(9, ErrorMessage = "A senha deve conter entre 6 e 8 caracteres", MinimumLength = 6)]
        [Display(Name = "Confirmar Senha")]
        [DataType(DataType.Password)]
        [Compare("Senha")]
        public string ConfirmeSenha { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Telefone Fixo é obrigatório", AllowEmptyStrings = false)]
        //[RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "O numero de telefone não é valido.")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:(###) ####-####}")]
        [Display(Name = "Telefone Fixo")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Celular é obrigatório", AllowEmptyStrings = false)]
        //[RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "O numero de celular não é valido.")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:(###) #####-####}")]
        [Display(Name = "Celular")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo WhatsApp é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "WhatsApp")]
        public bool WhatsApp { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo E-mail é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Site")]
        public string Site { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Endereço é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Cep é obrigatório", AllowEmptyStrings = false)]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "O numero de cep não é valido.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: #####-###}")]
        [Display(Name = "Cep")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Estado é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Cidade é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Bairro é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [RegularExpression(@"[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}", ErrorMessage = "O numero de cpf não é valido.")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: ###.###.###-##}")]
        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [RegularExpression(@"/^(\d{2}\.?\d{3}\.?\d{3}\/?\d{4}-?\d{2})$/", ErrorMessage = "O numero de cnpj não é valido.")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: ##.###.###/####-##}")]
        [Display(Name = "CNPJ")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Apresentação é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Apresentação")]
        public string Apresentacao { get; set; }

        [Display(Name = "Observações")]
        public string Observacoes { get; set; }

        public TipoPessoa TipoPessoa { get; set; }
        public DateTime? DataCadastro { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Data de nascimento é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Data de nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime? DataNascimento { get; set; }
        
        
        [Required]
        [DataType(DataType.Upload)]
        [Display(Name = "Imagem ou Logo")]
        public IFormFile? ImagemUpload { get; set; }

        public byte[]? Logo { get; set; }

        [Display(Name = "Qtd Terapias")]
        public IList<Terapia> Terapias { get; set; }

        public IList<Prescricao> Precricoes { get; set; }

        [Display(Name = "Qtd Pacientes")]
        public IList<Paciente> Pacientes { get; set; }
    }
}