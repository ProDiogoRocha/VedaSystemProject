using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using VedaSystemProject.Domain.Enums;
using VedaSystemProject.Domain.Interfaces;

namespace VedaSystemProject.Domain.Models
{
    [Table("Terapeuta")]
    public class Terapeuta : IBaseModel
    {
        public Guid? Id { get; set; }
        public string NomeCompleto { get; set; }
        public string NomeDeUsuario { get; set; }
        public string Senha { get; set; }
        public string ConfirmeSenha { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public bool WhatsApp { get; set; }
        public virtual Email Email { get; set; }
        public string Site { get; set; }
        public string Endereco { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public string Apresentacao { get; set; }
        public string Observacoes { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataNascimento { get; set; }
        public virtual ICollection<Terapia> Terapias { get; set; }
        public virtual ICollection<TerapiaPrincipal> TerapiasPrincipais { get; set; }
        public virtual ICollection<Prescricao> Precricoes { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
        public byte[] Logo { get; set; }
        public virtual ICollection<Transmissao> Transmissoes { get; set; }
        public virtual ICollection<Agenda> Agendas { get; set; }
        public virtual ICollection<Horario> Horarios { get; set; }
    }
}
