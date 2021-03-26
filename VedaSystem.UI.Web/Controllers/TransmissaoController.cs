using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Interfaces.Services;
using VedaSystem.UI.Web.Controllers.Interface;

namespace VedaSystem.UI.Web.Controllers
{
    public class TransmissaoController : BaseController<Transmissao, TransmissaoViewModel>, IController<Transmissao, TransmissaoViewModel>
    {
        public TransmissaoController(ILogService logService, ITransmissaoService service) : base(logService, service)
        {
        }
    }
}
