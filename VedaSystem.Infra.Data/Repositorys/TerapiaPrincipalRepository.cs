using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using VedaSystem.Domain.Interfaces;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Context;

namespace VedaSystem.Infra.Data.Repositorys
{
    public class TerapiaPrincipalRepository : Repository<TerapiaPrincipal>, ITerapiaPrincipalRepository
    {
        TerapiaPrincipalContext Db;
        DbSet<TerapiaPrincipal> DbSet;

        public TerapiaPrincipalRepository(TerapiaPrincipalContext context, ILogRepository logger = null) : base(context, logger)
        {
            Db = context;
            DbSet = Db.Set<TerapiaPrincipal>();
        }

        public IEnumerable<TerapiaPrincipal> BuscarPorNome(string nome)
        {
            IEnumerable<TerapiaPrincipal> terapiaPrincipals = new List<TerapiaPrincipal>();

            _log.RegistrarLog
                 (
                       Informacao: $@"3º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("BuscarPorNome").Name}"
                     , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("BuscarPorNome").Name}"
                     , ObjetoJson: JsonConvert.SerializeObject(nome)
                 );

            try
            {
                terapiaPrincipals = DbSet.Where(t => t.NomeTerapia.Contains(nome)).Select(t => t).ToList();
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                  Informacao: $@"3º Passo | {this.GetType().Name}, Entity {this.GetType().GetMethod("BuscarPorNome").Name}"
                , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("BuscarPorNome").Name}"
                , ObjetoJson: JsonConvert.SerializeObject(nome)
                , Erro: e.Message
                , Excecao: e.ToString());
            }

            _log.RegistrarLog
               (
                     Informacao: $@"3º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("BuscarPorNome").Name}"
                   , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("BuscarPorNome").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(nome)
               );
            return terapiaPrincipals;
        }
    }
}
