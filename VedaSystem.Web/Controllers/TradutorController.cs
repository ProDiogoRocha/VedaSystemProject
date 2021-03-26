using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;
using VedaSystem.Web.Controllers.Interface;

namespace VedaSystem.Web.Controllers
{
    public class TradutorController : BaseController<Tradutor, TradutorViewModel>, IController<Tradutor, TradutorViewModel>
    {
        public TradutorController(ILogService logService, ITradutorService service) : base(logService, service)
        {
        }
    }
}
