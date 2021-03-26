using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;
using VedaSystem.Web.Controllers.Interface;

namespace VedaSystem.Web.Controllers
{
    public class TerapiaController : BaseController<Terapia, TerapiaViewModel>, IController<Terapia, TerapiaViewModel>
    {
        public TerapiaController(ILogService logService, ITerapiaService service) : base(logService, service)
        {
        }
    }
}
