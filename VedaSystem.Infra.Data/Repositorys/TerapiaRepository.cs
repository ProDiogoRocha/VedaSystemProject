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
    }
}
