using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using VedaSystem.Domain.Interfaces;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Context;

namespace VedaSystem.Infra.Data.Repositorys
{
    public class EstoqueMaterialRepository : Repository<EstoqueMaterial>, IEstoqueMaterialRepository
    {
        private readonly EstoqueMaterialContext Db;
        private readonly DbSet<EstoqueMaterial> DbSet;
        public EstoqueMaterialRepository(EstoqueMaterialContext context, ILogRepository logger = null) : base(context, logger)
        {
            Db = context;
            DbSet = Db.Set<EstoqueMaterial>();
        }

        public override void Update(EstoqueMaterial em)
        {
            try
            {
                base.DetachLocal(_ => _.Id == em.Id);
                base.Update(em);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"3º Passo | {_nomeEntidade}, Entity Remove"
                   , Repositorio_Metodo: $@"{_nomeEntidade}/Remove"
                   , ObjetoJson: JsonConvert.SerializeObject(em)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }
        }

        public override void Remove(EstoqueMaterial em)
        {
            try
            {
                base.DetachLocal(_ => _.Id == em.Id);
                base.Remove(em);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"3º Passo | {_nomeEntidade}, Entity Remove"
                   , Repositorio_Metodo: $@"{_nomeEntidade}/Remove"
                   , ObjetoJson: JsonConvert.SerializeObject(em)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }
        }
    }
}
