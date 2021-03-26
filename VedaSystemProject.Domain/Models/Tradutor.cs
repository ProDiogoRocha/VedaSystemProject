using System;
using System.ComponentModel.DataAnnotations.Schema;
using VedaSystemProject.Domain.Interfaces;

namespace VedaSystemProject.Domain.Models
{
    [Table("ConteudoPt")]
    public class Tradutor : IBaseModel
    {
        public Guid? Id { get; set; }
        public string Categoria { get; set; }
        public string Texto { get; set; }
    }
}
