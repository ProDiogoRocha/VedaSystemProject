using System;
using System.ComponentModel.DataAnnotations;

namespace VedaSystem.Application.ViewModels
{
    public class TerapeutaParaTerapiaViewModel
    {
        [Key]
        public Guid? Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}