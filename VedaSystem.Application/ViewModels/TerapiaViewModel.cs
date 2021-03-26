using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VedaSystem.Application.ViewModels
{
    [Serializable]
    public class TerapiaViewModel
    {
        public TerapiaViewModel()
        {
            
        }

        [Key]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Nome da Terapia é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nome da Terapia")]
        public string NomeTerapia { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Duração é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Duração")]
        public TimeSpan Duracao { get; set; }

        [Display(Name = "List de Materiais")]
        public List<MaterialTerapiaViewModel> Materiais { get; set; }

        [Display(Name = "Observações")]
        public string Observacao { get; set; }

        public IList<TerapiaViewModel> TerapiasAdmin { get; set; }
    }
}