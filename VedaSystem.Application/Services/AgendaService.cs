using AutoMapper;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Interfaces;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.Services
{
    public class AgendaService : Service<Agenda, AgendaViewModel>, IAgendaService
    {
        public AgendaService(IMapper mapper, IAgendaRepository repository, ILogService logger) : base(mapper, repository, logger)
        {
        }
    }
}
