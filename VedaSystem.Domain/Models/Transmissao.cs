using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VedaSystem.Domain.Models
{
    [Table("Transmissoes")]
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
        public string IdsDepoimentos { get; set; }
        public Guid TerapeutaId { get; set; }
        [JsonIgnore]
        public virtual Terapeuta Terapeuta { get; set; }
    }
}
