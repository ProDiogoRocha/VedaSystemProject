using System;

namespace VedaSystem.Domain.Models
{
    public class Depoimento
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public int QuantidadeEstrelas { get; set; }
        public string Avaliação { get; set; }
        public string Nome { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
