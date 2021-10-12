using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VedaSystem.Domain.Interfaces;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Context;

namespace VedaSystem.Infra.Data.Repositorys
{
    public class LogRepository : Repository<Log>, ILogRepository
    {
        private readonly LogContext Db;
        private readonly DbSet<Log> DbSet;
        private Log logIn;

        public LogRepository(LogContext context) : base(context)
        {
            Db = context;
            DbSet = Db.Set<Log>();
        }

        public override IEnumerable<Log> GetAll()
        {
            return DbSet.ToList();
        }

        public override Log GetById(Guid id, bool ativo = true)
        {
            return DbSet.Find(id);
        }

        public void Register(Log log)
        {
            DbSet.Add(log);
            Db.SaveChanges();
        }

        public override void Remove(Log log)
        {
            DbSet.Remove(log);
        }

        public void RegistrarLog(
              Guid? IdUsuario = null
            , string NomeUsuario = null
            , string NomeComputador = null
            , string Controller_Action = null
            , string Servico_Metodo = null
            , string Repositorio_Metodo = null
            , string Informacao = null
            , string ObjetoJson = null
            , string Erro = null
            , string Excecao = null)
        {
            logIn = Log.Instancia(IdUsuario != null ? new Usuario(IdUsuario, NomeUsuario) : null);
            logIn.IdUsuario = IdUsuario ?? logIn.IdUsuario;
            logIn.NomeUsuario = NomeUsuario ?? logIn.NomeUsuario;
            logIn.NomeComputador = NomeComputador ?? logIn.NomeComputador;
            logIn.Controller_Action = Controller_Action ?? logIn.Controller_Action;
            logIn.Servico_Metodo = Servico_Metodo ?? logIn.Servico_Metodo;
            logIn.Repositorio_Metodo = Repositorio_Metodo ?? logIn.Repositorio_Metodo;
            logIn.Informacao = Informacao ?? logIn.Informacao;
            logIn.ObjetoJson = ObjetoJson ?? logIn.ObjetoJson;
            logIn.Erro = Erro ?? logIn.Erro;
            logIn.Excecao = Excecao ?? logIn.Excecao;

            Register(logIn);
        }
    }
}
