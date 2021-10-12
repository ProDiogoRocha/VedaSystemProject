using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;
using VedaSystem.Web.Controllers.Interface;
using VedaSystem.Web.Utils;

namespace VedaSystem.Web.Controllers
{
    public class TransmissaoController : BaseController<Transmissao, TransmissaoViewModel>, IController<Transmissao, TransmissaoViewModel>
    {
        private readonly IDepoimentoService _depoimentoService;
        public TransmissaoController(ILogService logService, ITransmissaoService service, IDepoimentoService depoimentoService) : base(logService, service)
        {
            _depoimentoService = depoimentoService;
        }

        public override IActionResult Index()
        {
            _log.RegistrarLog
                  (
                      Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Iniciando Módulo Index",
                      Controller_Action: $@"[HttpGet]-{this.GetType()}/Index"
                  );

            var t = _service.GetAll();

            _log.RegistrarLog
                  (
                      Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Finalizando Módulo Index",
                      Controller_Action: $@"[HttpGet]-{this.GetType()}/Index",
                      ObjetoJson: JsonConvert.SerializeObject(t)
                  );
            return _PartilView("Index", "div-principal", t);
        }

        public override IActionResult Create()
        {
            _log.RegistrarLog
                (
                    Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Iniciando Módulo Create",
                    Controller_Action: $@"[HttpGet]-{this.GetType().Name}/Create"
                );
            if (vm == null)
            {
                TransmissaoViewModel tvm = new TransmissaoViewModel();
                tvm.Depoimentos = _depoimentoService.GetAll().ToList();

                return _PartilView("Create","", tvm);
            }
            else
            {
                return _PartilView("Create", "", vm);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public override IActionResult Create(TransmissaoViewModel entity, string returnUrl = null)
        {
            entity.GetType().GetProperty("Id").SetValue(entity, Guid.NewGuid());
            _log.RegistrarLog
                (
                    Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Iniciando Módulo Create",
                    Controller_Action: $@"[HttpPost]-{this.GetType()}/Create",
                    ObjetoJson: JsonConvert.SerializeObject(entity)
                );
            
            entity.TerapeutaId = new DadosExpress().GetTerapeuta().Id;

            if (ModelState.IsValid)
            {
                _service.Add(entity);
                return RedirectToAction(nameof(Index));
            }

            return View(entity);
        }

        public override IActionResult CreateWithJson(string entity)
        {
            try
            {
                TransmissaoViewModel vm = JsonConvert.DeserializeObject<TransmissaoViewModel>(entity);
                vm.Id =  Guid.NewGuid();

                _log.RegistrarLog
                    (
                        Informacao: $@"1º Passo | Contexto de Transmissão, Iniciando Módulo Create",
                        Controller_Action: $@"[HttpPost]-Transmissao/Create",
                        ObjetoJson: JsonConvert.SerializeObject(entity)
                    );

                if (ModelState.IsValid)
                {
                    _service.Add(vm);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                return _PartilView("Create", null, vm);
            }

            return _PartilView("Create", null, vm);
        }
        public override IActionResult Edit(Guid id)
        {
            _log.RegistrarLog
                 (
                     Informacao: $@"1º Passo | Contexto de Transmissao, Iniciando Módulo Edit",
                     Controller_Action: $@"[HttpGet]-Transmissao/Edit",
                     ObjetoJson: JsonConvert.SerializeObject(id)
                 );

            var t = _service.GetById(id);
            var vetorDepo = t.IdsDepoimentos.Trim().Split(',');
            var depoimentos = _depoimentoService.GetAll().ToList();

            foreach (var depoimento in depoimentos)
            {
                foreach(var i in vetorDepo)
                {
                    if (!string.IsNullOrEmpty(i))
                    {
                        if (depoimento.Id == Guid.Parse(i))
                        {
                            depoimento.Selected = true;
                        }
                    }
                }
            }

            t.Depoimentos = depoimentos;

            _log.RegistrarLog
                   (
                       Informacao: $@"1º Passo | Contexto de Transmissao, Finalizando Módulo Edit",
                       Controller_Action: $@"[HttpGet]-Transmissao/DeleteConfirmed",
                       ObjetoJson: JsonConvert.SerializeObject(t)
                   );

            if (t == null)
            {
                return NotFound();
            }
            return _PartilView("Edit", null, t);
        }

        public override IActionResult Details(Guid id)
        {
            _log.RegistrarLog
                   (
                       Informacao: $@"1º Passo | Contexto de Transmissao, Iniciando Módulo DeleteConfirmed",
                       Controller_Action: $@"[HttpGet]-Transmissao/DeleteConfirmed",
                       ObjetoJson: JsonConvert.SerializeObject(id)
                   );

            var t = _service.GetById(id); 
            var vetorDepo = t.IdsDepoimentos.Trim().Split(',');
            var depoimentos = _depoimentoService.GetAll().ToList();

            foreach (var depoimento in depoimentos)
            {
                foreach (var i in vetorDepo)
                {
                    if (!string.IsNullOrEmpty(i))
                    {
                        if (depoimento.Id == Guid.Parse(i))
                        {
                            depoimento.Selected = true;
                        }
                    }
                }
            }

            t.Depoimentos = depoimentos;

            _log.RegistrarLog
                   (
                       Informacao: $@"1º Passo | Contexto de Transmissao, Finalizando Módulo DeleteConfirmed",
                       Controller_Action: $@"[HttpGet]-Transmissao/DeleteConfirmed",
                       ObjetoJson: JsonConvert.SerializeObject(t)
                   );

            if (t == null)
            {
                return NotFound();
            }

            return _PartilView("Details",null, t);
        }
    }
}
