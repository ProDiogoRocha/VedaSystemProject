using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VedaSystem.Domain.Models
{
    [Table("ConteudosPt")]
    public class Tradutor
    {
        public Guid? Id { get; set; }
        public string Categoria { get; set; }
        public string Texto { get; set; }
    }
}
