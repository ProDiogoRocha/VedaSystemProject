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
    public class TransmissaoRepository : Repository<Transmissao>, ITransmissaoRepository
    {
        private readonly TransmissaoContext Db;
        private readonly DbSet<Transmissao> DbSet;

        public TransmissaoRepository(TransmissaoContext context, ILogRepository logger = null) : base(context, logger)
        {
            Db = context;
            DbSet = Db.Set<Transmissao>();
        }

        public IEnumerable<Transmissao> GetTransmissaoPorTerapeuta(Guid? idTerapeuta)
        {
            IEnumerable<Transmissao> transmissoes = new List<Transmissao>();

            _log.RegistrarLog
                 (
                       Informacao: $@"3º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("GetTransmissaoPorTerapeuta").Name}"
                     , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetTransmissaoPorTerapeuta").Name}"
                     , ObjetoJson: JsonConvert.SerializeObject(idTerapeuta)
                 );

            try
            {
                transmissoes = DbSet.Where(t => t.TerapeutaId == idTerapeuta).ToList();
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                  Informacao: $@"3º Passo | {this.GetType().Name}, Entity {this.GetType().GetMethod("GetTransmissaoPorTerapeuta").Name}"
                , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetTransmissaoPorTerapeuta").Name}"
                , ObjetoJson: JsonConvert.SerializeObject(idTerapeuta)
                , Erro: e.Message
                , Excecao: e.ToString());
            }

            _log.RegistrarLog
               (
                     Informacao: $@"3º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("GetTransmissaoPorTerapeuta").Name}"
                   , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetTransmissaoPorTerapeuta").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(transmissoes)
               );
            return transmissoes;
        }

        public IEnumerable<Transmissao> GetTransmissaoPorTitulo(string titulo)
        {
            IEnumerable<Transmissao> transmissoes = new List<Transmissao>();

            _log.RegistrarLog
                 (
                       Informacao: $@"3º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("GetTransmissaoPorTitulo").Name}"
                     , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetTransmissaoPorTitulo").Name}"
                     , ObjetoJson: JsonConvert.SerializeObject(titulo)
                 );
            try
            {
                transmissoes = DbSet.Where(t => t.Titulo.Contains(titulo)).ToList();
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                  Informacao: $@"3º Passo | {this.GetType().Name}, Entity {this.GetType().GetMethod("GetTransmissaoPorTitulo").Name}"
                , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetTransmissaoPorTitulo").Name}"
                , ObjetoJson: JsonConvert.SerializeObject(titulo)
                , Erro: e.Message
                , Excecao: e.ToString());
            }

            _log.RegistrarLog
               (
                     Informacao: $@"3º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("GetTransmissaoPorTitulo").Name}"
                   , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetTransmissaoPorTitulo").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(transmissoes)
               );
            return transmissoes;
        }

        public override void Update(Transmissao t)
        {
            try
            {
                base.DetachLocal(_ => _.Id == t.Id);
                base.Update(t);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"3º Passo | Transmissao, Entity Update"
                   , Repositorio_Metodo: $@"Transmissao/Update"
                   , ObjetoJson: JsonConvert.SerializeObject(t)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }
        }
    }
}
