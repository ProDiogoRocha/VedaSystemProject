using System;
using System.ComponentModel.DataAnnotations.Schema;
using VedaSystemProject.Domain.Interfaces;

namespace VedaSystemProject.Domain.Models
{
    [Table("MaterialTerapia")]
    public class MaterialTerapia : IBaseModel
    {
        public Guid? Id { get; set; }
        public Guid? EstoqueMaterialId { get; set; }
        public Guid? TerapiaId { get; set; }
        public virtual Terapia Terapia { get; set; }
        public virtual TerapiaPrincipal TerapiaPrincipal { get; set; }
        public int Quantidade { get; set; }
    }
}
