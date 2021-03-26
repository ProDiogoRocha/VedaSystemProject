using AutoMapper;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Interfaces;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.Services
{
    public class EstoqueMaterialService : Service<EstoqueMaterial, EstoqueMaterialViewModel>, IEstoqueMaterialService
    {
        public EstoqueMaterialService(IMapper mapper, IEstoqueMaterialRepository repository, ILogService logger) : base(mapper, repository, logger)
        {
        }
    }
}
