using System;

namespace VedaSystem.Application.ViewModels
{
    [Serializable]
    public class MaterialTerapiaViewModel
    {

        public Guid? Id { get; set; }
        public Guid? EstoqueMaterialId { get; set; }
        public Guid? TerapiaId { get; set; }
        public int Quantidade { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
    }
}