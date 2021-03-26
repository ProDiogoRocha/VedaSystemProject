using Microsoft.EntityFrameworkCore;
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
    }
}
