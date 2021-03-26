using System;
using System.ComponentModel.DataAnnotations;

namespace VedaSystem.Application.ViewModels
{
    public class TradutorViewModel
    {
        [Key]
        public Guid? Id { get; set;}
        
        [Required(ErrorMessage = "O preenchimento do campo Categoria é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Categoria")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Texto é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Texto")]
        [StringLength(3900, MinimumLength = 2, ErrorMessage = "O texto deve conter entre 2 e 3900 caracteres")]
        public string Texto { get; set; }
    }
}