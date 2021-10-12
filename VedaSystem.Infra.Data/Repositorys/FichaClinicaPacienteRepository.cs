using Microsoft.EntityFrameworkCore;
using VedaSystem.Domain.Interfaces;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Context;

namespace VedaSystem.Infra.Data.Repositorys
{
    public class FichaClinicaPacienteRepository : Repository<FichaClinicaPaciente>, IFichaClinicaPacienteRepository
    {
        private readonly FichaClinicaPacienteContext Db;
        private readonly DbSet<FichaClinicaPaciente> DbSet;
        public FichaClinicaPacienteRepository(FichaClinicaPacienteContext context, ILogRepository logger = null) : base(context, logger)
        {
            Db = context;
            DbSet = Db.Set<FichaClinicaPaciente>();
        }
    }
}
