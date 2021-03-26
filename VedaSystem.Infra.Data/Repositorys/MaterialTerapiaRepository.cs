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
                materialTerapias = DbSet.Where(mt => mt.TerapiaId == IdTerapia).Select(mt => mt).ToList();
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
    }
}
