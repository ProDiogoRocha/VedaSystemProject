using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using VedaSystem.Domain.Interfaces;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Context;

namespace VedaSystem.Infra.Data.Repositorys
{
    public class DepoimentoRepository : Repository<Depoimento>, IDepoimentoRepository
    {
        private readonly DepoimentoContext Db;
        private readonly DbSet<Depoimento> DbSet;
        public DepoimentoRepository(DepoimentoContext context, ILogRepository logger = null) : base(context, logger)
        {
            Db = context;
            DbSet = Db.Set<Depoimento>();
        }

        public Depoimento GetDepoimentoByIdUsuario(Guid usuarioId)
        {
            return DbSet.Where(d => d.UsuarioId == usuarioId).FirstOrDefault();
        }
    }
}
