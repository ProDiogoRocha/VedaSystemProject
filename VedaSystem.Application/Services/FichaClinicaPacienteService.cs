using AutoMapper;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Interfaces;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.Services
{
    public class FichaClinicaPacienteService : Service<FichaClinicaPaciente, FichaClinicaPacienteViewModel>, IFichaClinicaPacienteService
    {
        public FichaClinicaPacienteService(IMapper mapper, IFichaClinicaPacienteRepository repository, ILogService logger) : base(mapper, repository, logger)
        {
        }
    }
}
