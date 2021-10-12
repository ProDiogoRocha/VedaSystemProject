using AutoMapper;
using System;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Interfaces;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.Services
{
    public class DepoimentoService : Service<Depoimento, DepoimentoViewModel>, IDepoimentoService
    {
        private readonly IDepoimentoRepository _depoimentoRepository;
        public DepoimentoService(IMapper mapper, IDepoimentoRepository repository, ILogService logger) : base(mapper, repository, logger)
        {
            _depoimentoRepository = repository;
        }

        public DepoimentoViewModel GetDepoimentoByIdUsuario(Guid usuarioId)
        {
            return _mapper.Map<DepoimentoViewModel>(_depoimentoRepository.GetDepoimentoByIdUsuario(usuarioId));
        }
    }
}
