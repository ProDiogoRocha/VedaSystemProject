using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Interfaces.Services;
using VedaSystem.UI.Web.Controllers.Interface;

namespace VedaSystem.UI.Web.Controllers
{
    public class TerapiaController : BaseController<Terapia, TerapiaViewModel>, IController<Terapia, TerapiaViewModel>
    {
        public TerapiaController(ILogService logService, ITerapiaService service) : base(logService, service)
        {
        }
    }
}
