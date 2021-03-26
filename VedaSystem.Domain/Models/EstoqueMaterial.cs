using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VedaSystem.Domain.Models
{
    [Table("EstoqueMateriais")]
    public class EstoqueMaterial
    {
        public Guid? Id { get; set; }
        public string Descricao { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int Quantidade { get; set; }
    }
}
