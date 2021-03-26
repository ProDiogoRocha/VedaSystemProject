using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;
using VedaSystem.UI.Web.Controllers.Interface;

namespace VedaSystem.UI.Web.Controllers
{
    public class PacienteController : BaseController<Paciente, PacienteViewModel>, IController<Paciente, PacienteViewModel>
    {
        public PacienteController(ILogService logService, IPacienteService service) : base(logService, service)
        {
        }
    }
}
