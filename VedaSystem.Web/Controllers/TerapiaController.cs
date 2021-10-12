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

namespace VedaSystem.Web.Controllers
{
    public class TerapiaController : BaseController<Terapia, TerapiaViewModel>, IController<Terapia, TerapiaViewModel>
    {
        private readonly ITerapiaService _terapiaService;
        private readonly IEstoqueMaterialService _estoqueMaterialService;
        private readonly IMaterialTerapiaService _materialTerapiaService;


        public TerapiaController(ILogService logService, ITerapiaService service, IEstoqueMaterialService estoqueMaterialService, IMaterialTerapiaService materialTerapiaService) : base(logService, service)
        {
            _terapiaService = service;
            _estoqueMaterialService = estoqueMaterialService;
            _materialTerapiaService = materialTerapiaService;
        }

        public override IActionResult Index()
        {
            _log.RegistrarLog
                  (
                      Informacao: $@"1º Passo | Contexto de Terapia , Iniciando Módulo Index",
                      Controller_Action: $@"[HttpGet]-TerapiaController/Index"
                  );

            var t = _service.GetAll();

            _log.RegistrarLog
                  (
                      Informacao: $@"1º Passo | Contexto de Terapia, Finalizando Módulo Index",
                      Controller_Action: $@"[HttpGet]-TerapiaController/Index",
                      ObjetoJson: JsonConvert.SerializeObject(t)
                  );
            return _PartilView("Index", null, t);
        }

        public override IActionResult Create()
        {
            _log.RegistrarLog
                (
                    Informacao: $@"1º Passo | Contexto de Terapia, Iniciando Módulo Create",
                    Controller_Action: $@"[HttpGet]-Terapia/Create"
                );

            TerapiaViewModel terapia = new TerapiaViewModel();
            terapia.Estoque = _estoqueMaterialService.GetAll().ToList();
            terapia.Id = Guid.NewGuid();

            if (vm == null)
            {
                return _PartilView("Create", null, terapia);
            }
            else
            {
                return _PartilView("Create", null, vm);
            }
        }

        public override IActionResult Edit(Guid id)
        {
            _log.RegistrarLog
                  (
                      Informacao: $@"1º Passo | Contexto de Terapia, Iniciando Módulo Edit",
                      Controller_Action: $@"[HttpGet]-Terapia/Edit",
                      ObjetoJson: JsonConvert.SerializeObject(id)
                  );

            var t = _service.GetById(id);
            t.Estoque = _estoqueMaterialService.GetAll().ToList();
            t.Materiais = _materialTerapiaService.BuscarPorIdTerapia(t.Id).ToList();

            foreach (var m in t.Materiais)
            {
                m.Descricao = _estoqueMaterialService.GetById((Guid)m.EstoqueMaterialId).Descricao;
            }

            _log.RegistrarLog
                   (
                       Informacao: $@"1º Passo | Contexto de Terapia, Finalizando Módulo Edit",
                       Controller_Action: $@"[HttpGet]-Terapia/DeleteConfirmed",
                       ObjetoJson: JsonConvert.SerializeObject(t)
                   );

            if (t == null)
            {
                return NotFound();
            }
            return _PartilView("Edit", null, t);
        }

        public override IActionResult CreateWithJson(string terapia)
        {
            var entity = JsonConvert.DeserializeObject<TerapiaViewModel>(terapia);

            entity.Ativo = true;

            _log.RegistrarLog
                (
                    Informacao: $@"1º Passo | Contexto de Terapia, Iniciando Módulo Create",
                    Controller_Action: $@"[HttpPost]-Terapia/Create",
                    ObjetoJson: JsonConvert.SerializeObject(entity)
                );


            _service.Update(entity);
            IList<MaterialTerapiaViewModel> materiais = _materialTerapiaService.BuscarPorIdTerapia(entity.Id).ToList();

            foreach (var m in materiais)
            {
                m.Ativo = true;
                _materialTerapiaService.Update(m);
            }

            return RedirectToAction(nameof(Index));
        }


        public IActionResult CriarMaterial(Guid id, Guid terapiaId)
        {
            var estoque = _estoqueMaterialService.GetById(id);

            MaterialTerapiaViewModel material = new MaterialTerapiaViewModel()
            {
                Id = Guid.NewGuid(),
                TerapiaId = terapiaId,
                EstoqueMaterialId = estoque.Id,
                Descricao = estoque.Descricao,
                Quantidade = estoque.Quantidade
            };

            if (_terapiaService.GetById(terapiaId) == null)
            {
                _terapiaService.Add(new TerapiaViewModel() { Id = terapiaId });
            }
            _materialTerapiaService.Add(material);

            return _PartilView("_MaterialTerapiaList", null, material);
        }

        public override IActionResult DeleteWithJson(string ids)
        {
            List<string> Ids = ids.Split(",").ToList().Where(a => !string.IsNullOrEmpty(a)).Select(a => a).ToList();

            _log.RegistrarLog
              (
                  Informacao: $@"1º Passo | Contexto de Terapia, Iniciando Módulo DeleteWithJson",
                  Controller_Action: $@"[HttpPost]-Terapia/DeleteWithJson",
                  ObjetoJson: JsonConvert.SerializeObject(ids)
              );

            try
            {
                foreach (var id in Ids)
                {
                    TerapiaViewModel terapia = _terapiaService.GetById(Guid.Parse(id));

                    IList<MaterialTerapiaViewModel> materiais = _materialTerapiaService.BuscarPorIdTerapia(Guid.Parse(id)).ToList();

                    foreach (var material in materiais)
                    {
                        _materialTerapiaService.Remove(material);
                    }
                    _terapiaService.Remove(terapia);
                }

                _log.RegistrarLog
              (
                  Informacao: $@"1º Passo | Contexto de Terapia, Finalizando Módulo DeleteWithJson",
                  Controller_Action: $@"[HttpPost]-Terapia/DeleteWithJson",
                  ObjetoJson: JsonConvert.SerializeObject(ids)
              );
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
