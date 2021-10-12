using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.Utils;
using VedaSystem.Web.Controllers.Interface;
using VedaSystem.Web.Extensions;

namespace VedaSystem.Web.Controllers
{
    public abstract class BaseController<T, Vm> : Controller, IController<T, Vm> where T : class where Vm : class
    {
        public LogApp _log;
        public IService<T, Vm> _service;
        public Vm vm;
        public HttpContext _httpContext;
        private string _entityName = "";

        public BaseController(ILogService logService, IService<T, Vm> service = null, string entityName = null)
        {
            _log = RetornaObjetoLog(logService: logService, NomeDoUsuario: User != null ? User.Identity.Name : null);
            _service = service;
            _entityName = this.GetType().Name;
        }

        private LogApp RetornaObjetoLog(ILogService logService, string NomeDoUsuario = null)
        {
            LogApp logApp = new LogApp(logService, NomeDoUsuario);

            return logApp;
        }

        public virtual IActionResult Create()
        {
            _log.RegistrarLog
                (
                    Informacao: $@"1º Passo | Contexto de {_entityName.Replace("Controller", "")}, Iniciando Módulo Create",
                    Controller_Action: $@"[HttpGet]-{_entityName}/Create"
                );
            if (vm == null)
            {
                return View();
            }
            else
            {
                return View(vm);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual IActionResult Create(Vm entity, string returnUrl = null)
        {
            entity.GetType().GetProperty("Id").SetValue(entity, Guid.NewGuid());
            _log.RegistrarLog
                (
                    Informacao: $@"1º Passo | Contexto de {_entityName.Replace("Controller", "")}, Iniciando Módulo Create",
                    Controller_Action: $@"[HttpPost]-{_entityName}/Create",
                    ObjetoJson: JsonConvert.SerializeObject(entity)
                );

            if (ModelState.IsValid)
            {
                _service.Add(entity);
                return RedirectToAction(nameof(Index));
            }

            return View(entity);
        }

        public virtual IActionResult Delete(Guid id)
        {
            _log.RegistrarLog
                   (
                       Informacao: $@"1º Passo | Contexto de {_entityName.Replace("Controller", "")}, Iniciando Módulo Delete",
                       Controller_Action: $@"[HttpGet]-{_entityName}/Delete",
                       ObjetoJson: JsonConvert.SerializeObject(id)
                   );

            Vm vm = _service.GetById(id);

            _log.RegistrarLog
                   (
                       Informacao: $@"1º Passo | Contexto de {_entityName.Replace("Controller", "")}, Finalizando Módulo Delete",
                       Controller_Action: $@"[HttpGet]-{_entityName}/Delete",
                       ObjetoJson: JsonConvert.SerializeObject(vm)
                   );

            if (vm == null)
            {
                return NotFound();
            }

            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual IActionResult DeleteConfirmed(Guid id)
        {
            _log.RegistrarLog
                   (
                       Informacao: $@"1º Passo | Contexto de {_entityName.Replace("Controller", "")}, Iniciando Módulo DeleteConfirmed",
                       Controller_Action: $@"[HttpPost]-{_entityName}/DeleteConfirmed",
                       ObjetoJson: JsonConvert.SerializeObject(id)
                   );

            var t = _service.GetById(id);
            _service.Remove(t);

            _log.RegistrarLog
                   (
                       Informacao: $@"1º Passo | Contexto de {_entityName.Replace("Controller", "")}, Finalizando Módulo DeleteConfirmed",
                       Controller_Action: $@"[HttpPost]-{_entityName}/DeleteConfirmed",
                       ObjetoJson: JsonConvert.SerializeObject(t)
                   );

            return RedirectToAction(nameof(Index));
        }

        public virtual IActionResult Details(Guid id)
        {
            _log.RegistrarLog
                   (
                       Informacao: $@"1º Passo | Contexto de {_entityName.Replace("Controller", "")}, Iniciando Módulo DeleteConfirmed",
                       Controller_Action: $@"[HttpGet]-{_entityName}/DeleteConfirmed",
                       ObjetoJson: JsonConvert.SerializeObject(id)
                   );

            var t = _service.GetById(id);

            _log.RegistrarLog
                   (
                       Informacao: $@"1º Passo | Contexto de {_entityName.Replace("Controller", "")}, Finalizando Módulo DeleteConfirmed",
                       Controller_Action: $@"[HttpGet]-{_entityName}/DeleteConfirmed",
                       ObjetoJson: JsonConvert.SerializeObject(t)
                   );

            if (t == null)
            {
                return NotFound();
            }

            return View(t);
        }

        public virtual IActionResult Edit(Guid id)
        {
            _log.RegistrarLog
                  (
                      Informacao: $@"1º Passo | Contexto de {_entityName.Replace("Controller", "")}, Iniciando Módulo Edit",
                      Controller_Action: $@"[HttpGet]-{_entityName}/Edit",
                      ObjetoJson: JsonConvert.SerializeObject(id)
                  );

            var t = _service.GetById(id);

            _log.RegistrarLog
                   (
                       Informacao: $@"1º Passo | Contexto de {_entityName.Replace("Controller", "")}, Finalizando Módulo Edit",
                       Controller_Action: $@"[HttpGet]-{_entityName}/DeleteConfirmed",
                       ObjetoJson: JsonConvert.SerializeObject(t)
                   );

            if (t == null)
            {
                return NotFound();
            }
            return _PartilView("Edit", null, t);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual IActionResult Edit(Guid id, Vm entity)
        {
            if (ModelState.IsValid)
            {
                _log.RegistrarLog
                  (
                      Informacao: $@"1º Passo | Contexto de {_entityName.Replace("Controller", "")}, Iniciando Módulo Edit",
                      Controller_Action: $@"[HttpPost]-{_entityName}/Edit",
                      ObjetoJson: JsonConvert.SerializeObject(entity)
                  );

                try
                {
                    _service.Update(entity);

                    _log.RegistrarLog
                  (
                      Informacao: $@"1º Passo | Contexto de {_entityName.Replace("Controller", "")}, Finalizando Módulo Edit",
                      Controller_Action: $@"[HttpPost]-{_entityName}/Edit",
                      ObjetoJson: JsonConvert.SerializeObject(entity)
                  );
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Login");
        }

        public virtual IActionResult Index()
        {
            _log.RegistrarLog
                  (
                      Informacao: $@"1º Passo | Contexto de {_entityName.Replace("Controller", "")}, Iniciando Módulo Index",
                      Controller_Action: $@"[HttpGet]-{_entityName}/Index"
                  );

            var t = _service.GetAll();

            _log.RegistrarLog
                  (
                      Informacao: $@"1º Passo | Contexto de {_entityName.Replace("Controller", "")}, Finalizando Módulo Index",
                      Controller_Action: $@"[HttpGet]-{_entityName}/Index",
                      ObjetoJson: JsonConvert.SerializeObject(t)
                  );
            return View(t);
        }

        public virtual JsonResult GetByName(string name, string propertyName, string partialName, string divRender = null)
        {
            _log.RegistrarLog
                  (
                        Informacao: $@"1º Passo | Contexto de {_entityName.Replace("Controller", "")}, Iniciando Módulo GetByName"
                      , Controller_Action: $@"[HttpGet]-{_entityName}/GetByName"
                      , ObjetoJson: JsonConvert.SerializeObject(name)
                  );

            var t = _service.GetByName(name, propertyName);

            _log.RegistrarLog
                 (
                     Informacao: $@"1º Passo | Contexto de {_entityName.Replace("Controller", "")}, Finalizando Módulo GetByName",
                     Controller_Action: $@"[HttpGet]-{_entityName}/GetByName",
                     ObjetoJson: JsonConvert.SerializeObject(t)
                 );
            return _PartilView(partialName, divRender, t);
        }

        public ActionResult ValidaSeLogadoRetornandoView(Vm t, string viewRetornoSeLogado, string controllerSeDeslogado, string actionSeDeslogado)
        {
            if (t != null)
            {
                return View(viewRetornoSeLogado);
            }
            else
            {
                return RedirectToAction(actionSeDeslogado, controllerSeDeslogado);
            }
        }

        public JsonResult _PartilView(string NomePartial, string DivRender, object Model = null)
        {
            dynamic ret = new
            {
                View = this.RenderViewAsync(viewName: NomePartial, model: Model, partial: true),
                RenderView = "true",
                DivRender = DivRender,
                DivExibir = "true"
            };

            JsonResult jsonResult = Json(ret);

            return jsonResult;
        }

        public bool UsuarioExists(Guid id)
        {
            return _service.GetById(id) != null ? true : false;
        }

        public virtual IActionResult CreateWithJson(string entity)
        {
            try
            {
                Vm vm = JsonConvert.DeserializeObject<Vm>(entity);

                vm.GetType().GetProperty("Id").SetValue(vm, Guid.NewGuid());

                _log.RegistrarLog
                    (
                        Informacao: $@"1º Passo | Contexto de {_entityName.Replace("Controller", "")}, Iniciando Módulo Create",
                        Controller_Action: $@"[HttpPost]-{_entityName}/Create",
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

        public virtual IActionResult EditWithJson(string entity)
        {
            Vm vm = JsonConvert.DeserializeObject<Vm>(entity);

            _log.RegistrarLog
              (
                  Informacao: $@"1º Passo | Contexto de {_entityName.Replace("Controller", "")}, Iniciando Módulo Edit",
                  Controller_Action: $@"[HttpPost]-{_entityName}/Edit",
                  ObjetoJson: JsonConvert.SerializeObject(entity)
              );

            try
            {
                _service.Update(vm);

                _log.RegistrarLog
              (
                  Informacao: $@"1º Passo | Contexto de {_entityName.Replace("Controller", "")}, Finalizando Módulo Edit",
                  Controller_Action: $@"[HttpPost]-{_entityName}/Edit",
                  ObjetoJson: JsonConvert.SerializeObject(entity)
              );
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        public virtual IActionResult DeleteWithJson(string ids)
        {
            List<string> Ids = ids.Split(",").ToList().Where(a => !string.IsNullOrEmpty(a)).Select(a => a).ToList();

            _log.RegistrarLog
              (
                  Informacao: $@"1º Passo | Contexto de {_entityName.Replace("Controller", "")}, Iniciando Módulo DeleteWithJson",
                  Controller_Action: $@"[HttpPost]-{_entityName}/DeleteWithJson",
                  ObjetoJson: JsonConvert.SerializeObject(ids)
              );

            try
            {
                foreach (var id in Ids)
                {
                    vm = _service.GetById(Guid.Parse(id));
                    _service.Remove(vm) ;
                }

                _log.RegistrarLog
              (
                  Informacao: $@"1º Passo | Contexto de {_entityName.Replace("Controller", "")}, Finalizando Módulo DeleteWithJson",
                  Controller_Action: $@"[HttpPost]-{_entityName}/DeleteWithJson",
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
