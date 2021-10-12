using Microsoft.EntityFrameworkCore;
using VedaSystem.Domain.Interfaces;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Context;

namespace VedaSystem.Infra.Data.Repositorys
{
    public class QuestionarioPosDiagnosticoRepository : Repository<QuestionarioPosDiagnostico>, IQuestionarioPosDiagnosticoRepository
    {
        private readonly QuestionarioPosDiagnosticoContext Db;
        private readonly DbSet<QuestionarioPosDiagnostico> DbSet;
        public QuestionarioPosDiagnosticoRepository(QuestionarioPosDiagnosticoContext context, ILogRepository logger = null) : base(context, logger)
        {
            Db = context;
            DbSet = Db.Set<QuestionarioPosDiagnostico>();
        }
    }
}
