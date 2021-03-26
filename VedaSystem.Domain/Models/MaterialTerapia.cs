using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VedaSystem.Domain.Models
{
    [Table("MaterialTerapias")]
    public class MaterialTerapia
    {
        public Guid? Id { get; set; }
        public Guid? EstoqueMaterialId { get; set; }
        public Guid? TerapiaId { get; set; }
        public virtual Terapia Terapia { get; set; }
        public virtual TerapiaPrincipal TerapiaPrincipal { get; set; }
        public int Quantidade { get; set; }
    }
}
