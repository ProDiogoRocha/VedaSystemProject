using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Interfaces.Services;
using VedaSystem.UI.Web.Controllers.Interface;

namespace VedaSystem.UI.Web.Controllers
{
    public class EmailController : BaseController<Email, EmailViewModel>, IController<Email, EmailViewModel>
    {
        public EmailController(ILogService logService, IEmailService service) : base(logService, service)
        {
        }
    }
}
