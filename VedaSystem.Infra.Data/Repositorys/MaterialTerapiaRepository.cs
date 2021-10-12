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
    public class MaterialTerapiaRepository : Repository<MaterialTerapia>, IMaterialTerapiaRepository
    {
        private readonly MaterialTerapiaContext Db;
        private readonly DbSet<MaterialTerapia> DbSet;
        public MaterialTerapiaRepository(MaterialTerapiaContext context, ILogRepository logger = null) : base(context, logger)
        {
            Db = context;
            DbSet = Db.Set<MaterialTerapia>();
        }

        public IEnumerable<MaterialTerapia> GetPorIdTerapia(Guid? IdTerapia)
        {
            IEnumerable<MaterialTerapia> materialTerapias = new List<MaterialTerapia>();

            _log.RegistrarLog
                 (
                       Informacao: $@"3º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("GetPorIdTerapia").Name}"
                     , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetPorIdTerapia").Name}"
                     , ObjetoJson: JsonConvert.SerializeObject(IdTerapia)
                 );
            try
            {
                materialTerapias = DbSet.Where(mt => mt.TerapiaId == IdTerapia && mt.Ativo == true).Select(mt => mt).ToList();
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                   Informacao: $@"3º Passo | {this.GetType().Name}, Entity {this.GetType().GetMethod("GetPorIdTerapia").Name}"
                 , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetPorIdTerapia").Name}"
                 , ObjetoJson: JsonConvert.SerializeObject(IdTerapia)
                 , Erro: e.Message
                 , Excecao: e.ToString());
            }

            _log.RegistrarLog
              (
                    Informacao: $@"3º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("GetPorIdTerapia").Name}"
                  , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetPorIdTerapia").Name}"
                  , ObjetoJson: JsonConvert.SerializeObject(materialTerapias)
              );
            return materialTerapias;
        }

        public override IEnumerable<MaterialTerapia> GetAll()
        {
            return DbSet.Where(mt => mt.Ativo == true).ToList();
        }

        public override MaterialTerapia GetById(Guid id, bool ativo)
        {
            if (ativo)
            {
                return DbSet.Where(mt => mt.Id == id && mt.Ativo == true).FirstOrDefault();
            }
            else
            {
                return DbSet.Find(id);
            }
        }

        public override void Add(MaterialTerapia t)
        {
            try
            {
                int Ativo = t.Ativo == true ? 1 : 0;

                Db.Database.ExecuteSqlRaw($@"INSERT INTO MaterialTerapias (Id, EstoqueMaterialId, TerapiaId, Quantidade, Ativo)  
                         VALUES ('{t.Id}', '{t.EstoqueMaterialId}', '{t.TerapiaId}', {t.Quantidade}, {Ativo})");

                //DbSet.FromSqlRaw
                //    (
                //        $@"INSERT INTO MaterialTerapias (Id, EstoqueMaterialId, TerapiaId, Quantidade, Ativo)  
                //         VALUES ('{t.Id}', '{t.EstoqueMaterialId}', '{t.TerapiaId}', {t.Quantidade}, {Ativo})"
                //    );
                //Db.SaveChanges();
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"3º Passo | {_nomeEntidade}, Entity {this.GetType().GetMethod("Add").Name}"
                   , Repositorio_Metodo: $@"{_nomeEntidade}/{this.GetType().GetMethod("Add").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(t)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }
        }

        public override void Update(MaterialTerapia t)
        {
            try
            {
                base.DetachLocal(_ => _.Id == t.Id);
                base.Update(t);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"3º Passo | {_nomeEntidade}, Entity Update"
                   , Repositorio_Metodo: $@"{_nomeEntidade}/Update"
                   , ObjetoJson: JsonConvert.SerializeObject(t)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }
        }

        public override void Remove(MaterialTerapia t)
        {
            try
            {
                base.DetachLocal(_ => _.Id == t.Id);
                base.Remove(t);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"3º Passo | {_nomeEntidade}, Entity Update"
                   , Repositorio_Metodo: $@"{_nomeEntidade}/Update"
                   , ObjetoJson: JsonConvert.SerializeObject(t)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }
        }
    }
}
