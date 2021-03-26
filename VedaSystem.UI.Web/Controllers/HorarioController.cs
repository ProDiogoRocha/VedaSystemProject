using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Interfaces.Services;
using VedaSystem.UI.Web.Controllers.Interface;

namespace VedaSystem.UI.Web.Controllers
{
    public class HorarioController : BaseController<Horario, HorarioTerapeutaViewModel>, IController<Horario, HorarioTerapeutaViewModel>
    {
        public HorarioController(ILogService logService, IHorarioService service) : base(logService, service)
        {
        }
    }
}
