using AutoMapper;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Interfaces;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.Services
{
    public class HorarioService : Service<Horario, HorarioTerapeutaViewModel>, IHorarioService
    {
        public HorarioService(IMapper mapper, IHorarioRepository repository, ILogService logger) : base(mapper, repository, logger)
        {
        }
    }
}
