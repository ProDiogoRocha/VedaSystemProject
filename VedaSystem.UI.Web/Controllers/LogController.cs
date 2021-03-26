using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;
using VedaSystem.UI.Web.Controllers.Interface;

namespace VedaSystem.UI.Web.Controllers
{
    public class LogController : BaseController<Log, LogViewModel>, IController<Log, LogViewModel>
    {
        public LogController(ILogService logService) : base(logService)
        {
        }
    }
}
