using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VedaSystem.Domain.Models
{
    [Table("Logs")]
    public sealed class Log
    {
        static Log _instancia;

        public static Log Instancia(Usuario usuario)
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
                    return new Log(idUsuario: usuario.Id, nomeUsuario: usuario.NomeDeUsuario);
                }
            }
            else
            {
                if (usuario != null)
                {
                    _instancia = new Log(idUsuario: usuario.Id, nomeUsuario: usuario.NomeDeUsuario);
                }
                else
                {
                    _instancia = new Log();
                }

                return _instancia;
            }
        }

        public void InstanciaContext() { }

        private Log()
        {
            Id = Guid.NewGuid();
        }

        private Log(Guid? idUsuario, string nomeUsuario)
        {
            Id = Guid.NewGuid();
            IdUsuario = idUsuario;
            NomeUsuario = nomeUsuario;
        }

        public Guid? Id { get; set; }
        public DateTime? Data { get; set; } = DateTime.Now;
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
