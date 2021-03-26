using System;
using VedaSystemProject.Domain.Interfaces;

namespace VedaSystemProject.Domain.Models
{
    public class Usuario : IBaseModel
    {
        public Guid? Id { get; set; }
        public string NomeDeUsuario { get; set; }
        public string Senha { get; set; }
        public string ConfirmeSenha { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public int TipoUsuario { get; set; }
    }
}
