using System;
using VedaSystem.Domain.Models;

namespace VedaSystem.Domain.Interfaces
{
    public interface ILogRepository : IRepository<Log>
    {
        void Register(Log log);
        void RegistrarLog(
              Guid? IdUsuario = null
            , string NomeUsuario = null
            , string NomeComputador = null
            , string Controller_Action = null
            , string Servico_Metodo = null
            , string Repositorio_Metodo = null
            , string Informacao = null
            , string ObjetoJson = null
            , string Erro = null
            , string Excecao = null);
    }
}
