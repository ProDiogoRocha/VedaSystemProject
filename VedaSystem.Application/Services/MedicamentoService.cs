using AutoMapper;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Interfaces;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.Services
{
    public class MedicamentoService : Service<Medicamento, MedicamentoViewModel>, IMedicamentoService
    {
        public MedicamentoService(IMapper mapper, IMedicamentoRepository repository, ILogService logger) : base(mapper, repository, logger)
        {
        }
    }
}
