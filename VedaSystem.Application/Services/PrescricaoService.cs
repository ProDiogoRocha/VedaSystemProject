using AutoMapper;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Interfaces;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.Services
{
    public class PrescricaoService : Service<Prescricao, PrescricaoViewModel>, IPrescricaoService
    {
        private readonly IMapper _mapper;
        private readonly IPrescricaoRepository _repository;
        public PrescricaoService(IMapper mapper, IPrescricaoRepository repository, ILogService logger) : base(mapper, repository, logger)
        {
            _mapper = mapper;
            _repository = repository;
        }
    }
}
