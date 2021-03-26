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
    public class TratamentoRepository : Repository<Tratamento>, ITratamentoRepository
    {
        private readonly TratamentoContext Db;
        private readonly DbSet<Tratamento> DbSet;
        public TratamentoRepository(TratamentoContext context, ILogRepository logger = null) : base(context, logger)
        {
            Db = context;
            DbSet = Db.Set<Tratamento>();
        }

        public IEnumerable<Tratamento> GetPorIdPrescricao(Guid? IdPrescricao)
        {
            IEnumerable<Tratamento> tratamentos = new List<Tratamento>();

            _log.RegistrarLog
                 (
                       Informacao: $@"3º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("GetPorIdPrescricao").Name}"
                     , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetPorIdPrescricao").Name}"
                     , ObjetoJson: JsonConvert.SerializeObject(IdPrescricao)
                 );
            try
            {
                tratamentos = DbSet.Where(t => t.PrescricaoId == IdPrescricao).Select(t => t).ToList();
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                  Informacao: $@"3º Passo | {this.GetType().Name}, Entity {this.GetType().GetMethod("GetPorIdPrescricao").Name}"
                , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetPorIdPrescricao").Name}"
                , ObjetoJson: JsonConvert.SerializeObject(IdPrescricao)
                , Erro: e.Message
                , Excecao: e.ToString());
            }

            _log.RegistrarLog
               (
                     Informacao: $@"3º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("GetPorIdPrescricao").Name}"
                   , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetPorIdPrescricao").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(tratamentos)
               );
            return tratamentos;
        }
    }
}
