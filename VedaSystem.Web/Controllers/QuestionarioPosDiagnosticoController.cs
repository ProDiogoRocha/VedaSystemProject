using Microsoft.AspNetCore.Mvc;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;
using VedaSystem.Web.Controllers.Interface;

namespace VedaSystem.Web.Controllers
{
    public class QuestionarioPosDiagnosticoController : BaseController<QuestionarioPosDiagnostico, QuestionarioPosDiagnosticoViewModel>, IController<QuestionarioPosDiagnostico, QuestionarioPosDiagnosticoViewModel>
    {
        private readonly IQuestionarioPosDiagnosticoService _questionarioPosDiagnosticoService;
        public QuestionarioPosDiagnosticoController(ILogService logService, IQuestionarioPosDiagnosticoService service) : base(logService, service)
        {
            _questionarioPosDiagnosticoService = service;
        }

        public override IActionResult Index()
        {
            var t = _questionarioPosDiagnosticoService.GetAll();

            return _PartilView("Index", "", t);
        }
    }
}
