using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;
using VedaSystem.Web.Controllers.Interface;

namespace VedaSystem.Web.Controllers
{
    public class MedicamentoController : BaseController<Medicamento, MedicamentoViewModel>, IController<Medicamento, MedicamentoViewModel>
    {
        public MedicamentoController(ILogService logService, IMedicamentoService service) : base(logService, service)
        {
        }
    }
}
