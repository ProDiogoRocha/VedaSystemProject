using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;
using VedaSystem.Web.Controllers.Interface;

namespace VedaSystem.Web.Controllers
{
    public class MaterialTerapiaController : BaseController<MaterialTerapia, MaterialTerapiaViewModel>, IController<MaterialTerapia, MaterialTerapiaViewModel>
    {
        public MaterialTerapiaController(ILogService logService, IMaterialTerapiaService service) : base(logService, service)
        {
        }
    }
}
