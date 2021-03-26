using Microsoft.AspNetCore.Mvc;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;
using VedaSystem.Web.Controllers.Interface;

namespace VedaSystem.Web.Controllers
{
    public class AgendaController : BaseController<Agenda, AgendaViewModel>, IController<Agenda, AgendaViewModel>
    {
        public AgendaController(ILogService logService, IAgendaService service) : base(logService, service)
        {
        }

        public IActionResult Calendario()
        {
            return View();
        }
    }
}
