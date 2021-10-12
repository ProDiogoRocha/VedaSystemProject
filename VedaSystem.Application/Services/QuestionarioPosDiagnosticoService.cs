using AutoMapper;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Interfaces;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.Services
{
    public class QuestionarioPosDiagnosticoService : Service<QuestionarioPosDiagnostico, QuestionarioPosDiagnosticoViewModel>, IQuestionarioPosDiagnosticoService
    {
        public QuestionarioPosDiagnosticoService(IMapper mapper, IQuestionarioPosDiagnosticoRepository repository, ILogService logger) : base(mapper, repository, logger)
        {
        }
    }
}
