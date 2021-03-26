using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;
using VedaSystem.Web.Controllers.Interface;

namespace VedaSystem.Web.Controllers
{
    public class LogController : BaseController<Log, LogViewModel>, IController<Log, LogViewModel>
    {
        public LogController(ILogService logService) : base(logService)
        {
        }
    }
}
