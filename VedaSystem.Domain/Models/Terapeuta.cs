using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using VedaSystem.Domain.Enums;

namespace VedaSystem.Domain.Models
{
    [Table("Terapeutas")]
    public class Terapeuta
    {
        [Key]
        public Guid? Id { get; set; }
        public string NomeCompleto { get; set; }
        public string NomeDeUsuario { get; set; }
        public string Senha { get; set; }
        public string ConfirmeSenha { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public bool WhatsApp { get; set; }
        public string Email { get; set; }
        public virtual Email EmailConfig { get; set; }
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
        public virtual IList<FichaClinicaPaciente> FichaClinicaPacientes { get; set; }
        public virtual IList<QuestionarioPosDiagnostico> QuestionarioPosDiagnosticos { get; set; }
        public virtual IList<Terapia> Terapias { get; set; }
        public virtual IList<TerapiaPrincipal> TerapiasPrincipais { get; set; }
        public virtual IList<Prescricao> Precricoes { get; set; } //
        public virtual IList<Paciente> Pacientes { get; set; }
        public byte[] Logo { get; set; }

        [JsonIgnore]
        public virtual IList<Transmissao> Transmissoes { get; set; } //
        public virtual IList<Agenda> Agendas { get; set; } //
        public virtual IList<Horario> Horarios { get; set; } //
    }
}
