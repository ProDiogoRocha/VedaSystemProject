using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VedaSystemProject.Domain.Models
{
    [Table("Transmissao")]
    public class Transmissao
    {
        public Guid? Id { get; set; }
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        public string TextoAntesDoVideo { get; set; }
        public string CodigoDeIncorporacaoDeVideo { get; set; }
        public string TextoDepoisDoVideo { get; set; }
        public string Rodape { get; set; }
        public bool Ativo { get; set; }
        public Guid TerapeutaId { get; set; }
        public virtual Terapeuta Terapeuta { get; set; }
    }
}
