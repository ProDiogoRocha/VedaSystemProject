using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;
using VedaSystem.Web.Controllers.Interface;

namespace VedaSystem.Web.Controllers
{
    public class PrescricaoController : BaseController<Prescricao, PrescricaoViewModel>, IController<Prescricao, PrescricaoViewModel>
    {
        public PrescricaoController(ILogService logService, IPrescricaoService service) : base(logService, service)
        {
        }
    }
}
