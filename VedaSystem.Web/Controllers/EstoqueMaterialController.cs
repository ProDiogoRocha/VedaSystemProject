using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
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

        public override IActionResult Index()
        {
            _log.RegistrarLog
                  (
                      Informacao: $@"1º Passo | Contexto de EstoqueMaterial , Iniciando Módulo Index",
                      Controller_Action: $@"[HttpGet]-EstoqueMaterialController/Index"
                  );

            var t = _service.GetAll();

            _log.RegistrarLog
                  (
                      Informacao: $@"1º Passo | Contexto de EstoqueMaterial, Finalizando Módulo Index",
                      Controller_Action: $@"[HttpGet]-EstoqueMaterialController/Index",
                      ObjetoJson: JsonConvert.SerializeObject(t)
                  );
            return _PartilView("Index", null, t);
        }

        public override IActionResult Edit(Guid id)
        {
            _log.RegistrarLog
                  (
                      Informacao: $@"1º Passo | Contexto de EstoqueMaterial, Iniciando Módulo Edit",
                      Controller_Action: $@"[HttpGet]-EstoqueMaterial/Edit",
                      ObjetoJson: JsonConvert.SerializeObject(id)
                  );

            var t = _service.GetById(id);

            _log.RegistrarLog
                   (
                       Informacao: $@"1º Passo | Contexto de EstoqueMaterial, Finalizando Módulo Edit",
                       Controller_Action: $@"[HttpGet]-EstoqueMaterial/DeleteConfirmed",
                       ObjetoJson: JsonConvert.SerializeObject(t)
                   );

            if (t == null)
            {
                return NotFound();
            }
            return _PartilView("Edit",null,t);
        }

        public override IActionResult Create()
        {
            _log.RegistrarLog
                (
                    Informacao: $@"1º Passo | Contexto de EstoqueMaterial, Iniciando Módulo Create",
                    Controller_Action: $@"[HttpGet]-EstoqueMaterial/Create"
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
    }
}
