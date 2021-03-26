using Microsoft.EntityFrameworkCore;
using VedaSystem.Domain.Interfaces;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Context;

namespace VedaSystem.Infra.Data.Repositorys
{
    public class HorarioRepository : Repository<Horario>, IHorarioRepository
    {
        private readonly HorarioContext Db;
        private readonly DbSet<Horario> DbSet;
        public HorarioRepository(HorarioContext context, ILogRepository logger = null) : base(context, logger)
        {
            Db = context;
            DbSet = Db.Set<Horario>();
        }
    }
}
