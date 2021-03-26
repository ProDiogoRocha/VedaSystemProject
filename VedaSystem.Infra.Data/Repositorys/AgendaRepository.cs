using Microsoft.EntityFrameworkCore;
using VedaSystem.Domain.Interfaces;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Context;

namespace VedaSystem.Infra.Data.Repositorys
{
    public class AgendaRepository : Repository<Agenda>, IAgendaRepository
    {
        private readonly AgendaContext Db;
        private readonly DbSet<Agenda> DbSet;
        public AgendaRepository(AgendaContext context, ILogRepository logger = null) : base(context, logger)
        {
            Db = context;
            DbSet = Db.Set<Agenda>();
        }
    }
}
