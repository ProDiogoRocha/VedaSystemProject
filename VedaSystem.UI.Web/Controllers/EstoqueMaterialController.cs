using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Interfaces.Services;
using VedaSystem.UI.Web.Controllers.Interface;

namespace VedaSystem.UI.Web.Controllers
{
    public class EstoqueMaterialController : BaseController<EstoqueMaterial, EstoqueMaterialViewModel>, IController<EstoqueMaterial, EstoqueMaterialViewModel>
    {
        public EstoqueMaterialController(ILogService logService, IEstoqueMaterialService service) : base(logService, service)
        {
        }
    }
}
