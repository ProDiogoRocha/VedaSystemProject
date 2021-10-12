using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;
using VedaSystem.Web.Controllers.Interface;

namespace VedaSystem.Web.Controllers
{
    public class FichaClinicaPacienteController : BaseController<FichaClinicaPaciente, FichaClinicaPacienteViewModel>, IController<FichaClinicaPaciente, FichaClinicaPacienteViewModel>
    {
        private readonly IFichaClinicaPacienteService _fichaClinicaService;
        public FichaClinicaPacienteController(ILogService logService, IFichaClinicaPacienteService service) : base(logService, service)
        {
            _fichaClinicaService = service;
        }

        public override IActionResult Index()
        {
            _log.RegistrarLog
                 (
                     Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Iniciando Módulo Index",
                     Controller_Action: $@"[HttpGet]-{this.GetType().Name}/Index"
                 );

            var t = _fichaClinicaService.GetAll();

            _log.RegistrarLog
                  (
                      Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Finalizando Módulo Index",
                      Controller_Action: $@"[HttpGet]-{GetType().Name}/Index",
                      ObjetoJson: JsonConvert.SerializeObject(t)
                  );
            return _PartilView("Index", "", t);
        }

        public override IActionResult Create()
        {
            FichaClinicaPacienteViewModel vm = new FichaClinicaPacienteViewModel();
            return _PartilView("Create", "", vm);
        }
    }
}
