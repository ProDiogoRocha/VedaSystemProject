using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;
using VedaSystem.Web.Controllers.Interface;
using VedaSystem.Web.Utils;

namespace VedaSystem.Web.Controllers
{
    public class PrescricaoController : BaseController<Prescricao, PrescricaoViewModel>, IController<Prescricao, PrescricaoViewModel>
    {
        private readonly ITerapeutaService _terapeutaService;
        private readonly IPacienteService _pacienteService;
        private readonly IMedicamentoService _medicamentoService;
        public PrescricaoController(ILogService logService, IPrescricaoService service, ITerapeutaService terapeutaService, IPacienteService pacienteService, IMedicamentoService medicamentoService) : base(logService, service)
        {
            _terapeutaService = terapeutaService;
            _pacienteService = pacienteService;
            _medicamentoService = medicamentoService;
        }

        public override IActionResult Index()
        {
            _log.RegistrarLog
                  (
                      Informacao: $@"1º Passo | Contexto de Prescricao , Iniciando Módulo Index",
                      Controller_Action: $@"[HttpGet]-PrescricaoController/Index"
                  );

            var t = _service.GetAll();

            _log.RegistrarLog
                  (
                      Informacao: $@"1º Passo | Contexto de Prescricao, Finalizando Módulo Index",
                      Controller_Action: $@"[HttpGet]-PrescricaoController/Index",
                      ObjetoJson: JsonConvert.SerializeObject(t)
                  );
            return _PartilView("Index", null, t);
        }

        public override IActionResult Create()
        {
            _log.RegistrarLog
                (
                    Informacao: $@"1º Passo | Contexto de Prescricao, Iniciando Módulo Create",
                    Controller_Action: $@"[HttpGet]-Prescricao/Create"
                );

            vm = new PrescricaoViewModel();
            vm.Terapeuta = _terapeutaService.GetTerapeutaPorNomeDeUsuario(new DadosExpress().GetUsuario().NomeDeUsuario);
            vm.Pacientes = _pacienteService.BuscarPorIdTerapeuta(vm.Terapeuta.Id).ToList();
            vm.Medicamentos = _medicamentoService.GetAll().ToList();
            //vm.PacienteSelecionado = new PacienteViewModel();

            return _PartilView("Create", null, vm);
        }
    }
}
