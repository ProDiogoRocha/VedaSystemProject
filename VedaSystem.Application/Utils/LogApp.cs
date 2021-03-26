using System;
using System.Net;
using VedaSystem.Application.Interfaces;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.Utils
{
    public class LogApp
    {
        private readonly ILogService _logService;
        private Log _log;
        private string NomeComputador = null;
        private string NomeUsuario = null;

        public LogApp(ILogService logService = null)
        {
            _logService = logService;
        }

        public LogApp(ILogService logService = null, string NomeUsuario = null)
        {
            _logService = logService;
            NomeComputador = Dns.GetHostEntry(Environment.MachineName).HostName;
            this.NomeUsuario = NomeUsuario;
        }

        public void RegistrarLog(
              Guid? IdUsuario = null
            , string Controller_Action = null
            , string Servico_Metodo = null
            , string Repositorio_Metodo = null
            , string Informacao = null
            , string ObjetoJson = null
            , string Erro = null
            , string Excecao = null)
        {
            _log = Log.Instancia(IdUsuario != null ? new Usuario(IdUsuario, NomeUsuario) : null);
            _log.IdUsuario = IdUsuario ?? _log.IdUsuario;
            _log.NomeUsuario = NomeUsuario ?? _log.NomeUsuario;
            _log.NomeComputador = NomeComputador ?? _log.NomeComputador;
            _log.Controller_Action = Controller_Action ?? _log.Controller_Action;
            _log.Servico_Metodo = Servico_Metodo ?? _log.Servico_Metodo;
            _log.Repositorio_Metodo = Repositorio_Metodo ?? _log.Repositorio_Metodo;
            _log.Informacao = Informacao ?? _log.Informacao;
            _log.ObjetoJson = ObjetoJson ?? _log.ObjetoJson;
            _log.Erro = Erro ?? _log.Erro;
            _log.Excecao = Excecao ?? _log.Excecao;

            _logService.Register(_log);
        }

        public void RegistrarLog(Log log)
        {
            _logService.Register(log);
        }
    }
}
