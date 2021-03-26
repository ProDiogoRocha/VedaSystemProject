using Microsoft.EntityFrameworkCore;
using VedaSystem.Domain.Interfaces;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Context;

namespace VedaSystem.Infra.Data.Repositorys
{
    public class MedicamentoRepository : Repository<Medicamento>, IMedicamentoRepository
    {
        private readonly MedicamentoContext Db;
        private readonly DbSet<Medicamento> DbSet;
        public MedicamentoRepository(MedicamentoContext context, ILogRepository logger = null) : base(context, logger)
        {
            Db = context;
            DbSet = Db.Set<Medicamento>();
        }
    }
}
