using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Interfaces.Services;
using VedaSystem.UI.Web.Controllers.Interface;

namespace VedaSystem.UI.Web.Controllers
{
    public class MaterialTerapiaController : BaseController<MaterialTerapia, MaterialTerapiaViewModel>, IController<MaterialTerapia, MaterialTerapiaViewModel>
    {
        public MaterialTerapiaController(ILogService logService, IMaterialTerapiaService service) : base(logService, service)
        {
        }
    }
}
