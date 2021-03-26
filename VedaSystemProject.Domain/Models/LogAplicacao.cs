using System;
using System.ComponentModel.DataAnnotations.Schema;
using VedaSystemProject.Domain.Interfaces;

namespace VedaSystemProject.Domain.Models
{
    [Table("LogAplicacao")]
    public sealed class LogAplicacao : IBaseModel
    {
        static LogAplicacao _instancia;

        public static LogAplicacao Instancia(Usuario usuario)
        {
            if (_instancia != null && _instancia.IdUsuario != null)
            {
                if (_instancia.IdUsuario == usuario.Id)
                {
                    _instancia.Id = Guid.NewGuid();
                    return _instancia;
                }
                else
                {
                    return new LogAplicacao(idUsuario: usuario.Id, nomeUsuario: usuario.NomeDeUsuario);
                }
            }
            else
            {
                if (usuario != null)
                {
                    _instancia = new LogAplicacao(idUsuario: usuario.Id, nomeUsuario: usuario.NomeDeUsuario);
                }
                else
                {
                    _instancia = new LogAplicacao();
                }

                return _instancia;
            }
        }

        private LogAplicacao()
        {
            Id = Guid.NewGuid();
        }

        private LogAplicacao(Guid? idUsuario, string nomeUsuario)
        {
            Id = Guid.NewGuid();
            IdUsuario = idUsuario;
            NomeUsuario = nomeUsuario;
        }

        public Guid? Id { get; set; }
        public DateTime? Data { get; set; }
        public Guid? IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string NomeComputador { get; set; }
        public string Controller_Action { get; set; }
        public string Servico_Metodo { get; set; }
        public string Repositorio_Metodo { get; set; }
        public string Informacao { get; set; }
        public string ObjetoJson { get; set; }
        public string Erro { get; set; }
        public string Excecao { get; set; }
    }
}
