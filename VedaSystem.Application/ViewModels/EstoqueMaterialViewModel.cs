using System;
using System.ComponentModel.DataAnnotations;

namespace VedaSystem.Application.ViewModels
{
    public class EstoqueMaterialViewModel
    {
        public EstoqueMaterialViewModel()
        {
            this.Id = Guid.NewGuid();
        }
        [Key]
        public Guid? Id { get; set; }
        public string Descricao { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int Quantidade { get; set; }
    }
}
