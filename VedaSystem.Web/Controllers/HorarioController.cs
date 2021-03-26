using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;
using VedaSystem.Web.Controllers.Interface;

namespace VedaSystem.Web.Controllers
{
    public class HorarioController : BaseController<Horario, HorarioTerapeutaViewModel>, IController<Horario, HorarioTerapeutaViewModel>
    {
        public HorarioController(ILogService logService, IHorarioService service) : base(logService, service)
        {
        }
    }
}
