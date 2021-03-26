using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;
using VedaSystem.Web.Controllers.Interface;

namespace VedaSystem.Web.Controllers
{
    public class EstoqueMaterialController : BaseController<EstoqueMaterial, EstoqueMaterialViewModel>, IController<EstoqueMaterial, EstoqueMaterialViewModel>
    {
        public EstoqueMaterialController(ILogService logService, IEstoqueMaterialService service) : base(logService, service)
        {
        }
    }
}
