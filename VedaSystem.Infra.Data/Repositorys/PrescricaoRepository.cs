using Microsoft.EntityFrameworkCore;
using System;
using VedaSystem.Domain.Interfaces;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Context;

namespace VedaSystem.Infra.Data.Repositorys
{
    public class PrescricaoRepository : Repository<Prescricao>, IPrescricaoRepository
    {
        private readonly PrescricaoContext Db;
        private readonly DbSet<Prescricao> DbSet;
        public PrescricaoRepository(PrescricaoContext context, ILogRepository logger = null) : base(context, logger)
        {
            Db = context;
            DbSet = Db.Set<Prescricao>();
        }
    }
}
