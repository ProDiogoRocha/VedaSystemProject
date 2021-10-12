using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;
using VedaSystem.Web.Controllers.Interface;
using Microsoft.AspNetCore.Http;

namespace VedaSystem.Web.Controllers
{
    public class TradutorController : BaseController<Tradutor, TradutorViewModel>, IController<Tradutor, TradutorViewModel>
    {
        private readonly ITradutorService _tradutorService;
        public TradutorController(ILogService logService, ITradutorService service) : base(logService, service)
        {
            _tradutorService = service;
        }

        public override IActionResult Index()
        {
            _log.RegistrarLog
                  (
                      Informacao: $@"1º Passo | Contexto de Tradutor , Iniciando Módulo Index",
                      Controller_Action: $@"[HttpGet]-TradutorController/Index"
                  );

            var t = _service.GetAll();

            _log.RegistrarLog
                  (
                      Informacao: $@"1º Passo | Contexto de Tradutor, Finalizando Módulo Index",
                      Controller_Action: $@"[HttpGet]-TradutorController/Index",
                      ObjetoJson: JsonConvert.SerializeObject(t)
                  );
            return _PartilView("Index", null, t);
        }

        public override IActionResult Create()
        {
            _log.RegistrarLog
                (
                    Informacao: $@"1º Passo | Contexto de Tradutor, Iniciando Módulo Create",
                    Controller_Action: $@"[HttpGet]-Tradutor/Create"
                );
            if (vm == null)
            {
                return _PartilView("Create", null, null);
            }
            else
            {
                return _PartilView("Create", null, vm);
            }
        }

        public override IActionResult Create(TradutorViewModel entity, string returnUrl = null)
        {
            _tradutorService.CarregarPagina();
            _tradutorService.PreencherTextoEmIngles(entity.Texto);
            entity.Texto = _tradutorService.GetTextoEmPortugues(entity.Texto);
            _tradutorService.Fechar();

            return base.Create(entity);
        }

        public override IActionResult CreateWithJson(string entity)
        {
            var objeto = JsonConvert.DeserializeObject<TradutorViewModel>(entity);
            _tradutorService.CarregarPagina();
            _tradutorService.PreencherTextoEmIngles(objeto.Texto);
            objeto.Texto = _tradutorService.GetTextoEmPortugues(objeto.Texto);
            _tradutorService.Fechar();

            return base.Create(objeto);
        }
    }
}
