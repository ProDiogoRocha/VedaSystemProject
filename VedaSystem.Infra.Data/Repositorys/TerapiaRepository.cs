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
    public class TerapiaRepository : Repository<Terapia>, ITerapiaRepository
    {
        private readonly TerapiaContext Db;
        private readonly DbSet<Terapia> DbSet;

        public TerapiaRepository(TerapiaContext context, ILogRepository logger = null) : base(context, logger)
        {
            Db = context;
            DbSet = Db.Set<Terapia>();
        }

        public IEnumerable<Terapia> BuscarPorNome(string nome)
        {
            IEnumerable<Terapia> terapias = new List<Terapia>();

            _log.RegistrarLog
                 (
                       Informacao: $@"3º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("BuscarPorNome").Name}"
                     , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("BuscarPorNome").Name}"
                     , ObjetoJson: JsonConvert.SerializeObject(nome)
                 );

            try
            {
                terapias = DbSet.Where(t => t.NomeTerapia.Contains(nome)).Select(t => t).ToList();
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
            return terapias;
        }

        public override IEnumerable<Terapia> GetAll()
        {
            return DbSet.Where(t => t.Ativo == true).Select(t => t).ToList();
        }

        public override Terapia GetById(Guid id, bool ativo = true)
        {
            return DbSet.Where(t => t.Id == id && t.Ativo == true).Select(t => t).FirstOrDefault();
        }

        public override void Remove(Terapia t)
        {
            try
            {
                base.DetachLocal(_ => _.Id == t.Id);
                base.Remove(t);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"3º Passo | {_nomeEntidade}, Entity Remove"
                   , Repositorio_Metodo: $@"{_nomeEntidade}/Remove"
                   , ObjetoJson: JsonConvert.SerializeObject(t)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }
        }

    }
}
