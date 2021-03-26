using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Interfaces.Services;
using VedaSystem.UI.Web.Controllers.Interface;

namespace VedaSystem.UI.Web.Controllers
{
    public class TradutorController : BaseController<Tradutor, TradutorViewModel>, IController<Tradutor, TradutorViewModel>
    {
        public TradutorController(ILogService logService, ITradutorService service) : base(logService, service)
        {
        }
    }
}
