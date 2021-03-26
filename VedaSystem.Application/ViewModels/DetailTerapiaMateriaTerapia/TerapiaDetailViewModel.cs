using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VedaSystem.Application.ViewModels.CadastroMateriaisTerapia;

namespace VedaSystem.Application.ViewModels.DetailTerapiaMateriaTerapia
{
    public class TerapiaDetailViewModel
    {
        public TerapiaDetailViewModel() { }

        public TerapiaDetailViewModel(Guid? id, string nomeTerapia, TimeSpan duracao, List<ListaMateriaisTerapiaViewModel> materiais, string observacao)
        {
            Id = id;
            NomeTerapia = nomeTerapia;
            Duracao = duracao;
            Materiais = materiais;
            Observacao = observacao;
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
        public List<ListaMateriaisTerapiaViewModel> Materiais { get; set; }

        [Display(Name = "Observações")]
        public string Observacao { get; set; }

       
    }
}