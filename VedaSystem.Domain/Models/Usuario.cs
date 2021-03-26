using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using VedaSystem.Domain.Enums;

namespace VedaSystem.Domain.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        private Guid? idUsuario;
        private string nomeUsuario;

        public Usuario()
        {
        }

        public Usuario(Guid? idUsuario, string nomeUsuario)
        {
            this.idUsuario = idUsuario;
            this.nomeUsuario = nomeUsuario;
        }
        
        public Guid? Id { get; set; }
        public string NomeDeUsuario { get; set; }
        public string Senha { get; set; }
        public string ConfirmeSenha { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public TipoUsuario TipoUsuario{ get; set; }
        public byte[] Foto { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> TiposUsuario { get; set; }

    }
}
