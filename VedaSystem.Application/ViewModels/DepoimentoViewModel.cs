using System;
using System.ComponentModel.DataAnnotations;

namespace VedaSystem.Application.ViewModels
{
    public class DepoimentoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Título Resumo é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Titulo Resumo")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Nota é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nota")]
        public int QuantidadeEstrelas { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Descrição da avaliação é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Descrição da avaliação")]
        public string Avaliacao { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Nome é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        public bool Selected { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
