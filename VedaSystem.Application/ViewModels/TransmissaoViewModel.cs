using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VedaSystem.Application.ViewModels
{
    public class TransmissaoViewModel
    {
        public Guid? Id { get; set; }
        
        [Display(Name="Título")]
        [Required(ErrorMessage ="O campo Titulo é obrigatório!")]
        public string Titulo { get; set; }

        [Display(Name = "Sub-Título")]
        public string SubTitulo { get; set; }
        
        [Display(Name = "Texto antes do vídeo")]
        public string TextoAntesDoVideo { get; set; }

        [Display(Name = "Código do video")]
        [Required(ErrorMessage = "O campo Código do video é obrigatório!")]
        public string CodigoDeIncorporacaoDeVideo { get; set; }

        [Display(Name = "Texto depois do vídeo")]
        public string TextoDepoisDoVideo { get; set; }

        [Display(Name = "Título do Rodapé")]
        public string TituloRodape { get; set; }

        [Display(Name = "Rodapé")]
        public string Rodape { get; set; }

        [Display(Name = "Link Ativo?")]
        public bool Ativo { get; set; }

        public bool EmailLead { get; set; }
        public string IdsDepoimentos { get; set; }
        public IList<DepoimentoViewModel> Depoimentos { get; set; }

        public Guid? TerapeutaId { get; set; }
    }
}