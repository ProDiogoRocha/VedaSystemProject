using System;
using System.ComponentModel.DataAnnotations;

namespace VedaSystem.Application.ViewModels
{
    public class PacienteViewModel
    {
        public PacienteViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Nome Completo é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nome Completo")]
        public string Nome { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Data de nascimento é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Data de nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Numero do Telefone é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Numero do Telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Peso(Kg) é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Peso(Kg)")]
        public float Peso { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Altura(m) é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Altura(m)")]
        public float Altura { get; set; }
        public string RedeSocial { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Motivo da consulta é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Motivo da consulta")]
        public string MotivoConsulta { get; set; }
    }
}
