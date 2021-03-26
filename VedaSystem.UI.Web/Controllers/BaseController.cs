using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.Utils;
using VedaSystem.Domain.Enums;
using VedaSystem.Domain.Models;
using VedaSystem.UI.Web.Controllers.Interface;
using VedaSystem.UI.Web.Extensions;

namespace VedaSystem.UI.Web.Controllers
{
    public abstract class BaseController<T, Vm> : Controller, IController<T, Vm> where T : class where Vm : class
    {
        public LogApp _log;
        public IService<T, Vm> _service;
        public Vm vm;
        public HttpContext _httpContext;

        public BaseController(ILogService logService, IService<T, Vm> service = null)
        {
            _log = RetornaObjetoLog(logService: logService, NomeDoUsuario: User != null ? User.Identity.Name : null);
            _service = service;
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
                    Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Iniciando Módulo {this.GetType().GetMethod("Create").Name}",
                    Controller_Action: $@"[HttpGet]-{this.GetType().Name}/{this.GetType().GetMethod("Create").Name}",
                    ObjetoJson: JsonConvert.SerializeObject(this.GetType().GetMethod("Create").GetParameters())
                );
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual IActionResult Create(Vm entity)
        {
            _log.RegistrarLog
                (
                    Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Iniciando Módulo {this.GetType().GetMethod("Create").Name}",
                    Controller_Action: $@"[HttpPost]-{this.GetType().Name}/{this.GetType().GetMethod("Create").Name}",
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
                       Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Iniciando Módulo {this.GetType().GetMethod("Delete").Name}",
                       Controller_Action: $@"[HttpGet]-{this.GetType().Name}/{this.GetType().GetMethod("Delete").Name}",
                       ObjetoJson: JsonConvert.SerializeObject(id)
                   );

            Vm vm = _service.GetById(id);

            _log.RegistrarLog
                   (
                       Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Finalizando Módulo {this.GetType().GetMethod("Delete").Name}",
                       Controller_Action: $@"[HttpGet]-{this.GetType().Name}/{this.GetType().GetMethod("Delete").Name}",
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
                       Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Iniciando Módulo {this.GetType().GetMethod("DeleteConfirmed").Name}",
                       Controller_Action: $@"[HttpPost]-{this.GetType().Name}/{this.GetType().GetMethod("DeleteConfirmed").Name}",
                       ObjetoJson: JsonConvert.SerializeObject(id)
                   );

            var t = _service.GetById(id);
            _service.Remove(t);

            _log.RegistrarLog
                   (
                       Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Finalizando Módulo {this.GetType().GetMethod("DeleteConfirmed").Name}",
                       Controller_Action: $@"[HttpPost]-{this.GetType().Name}/{this.GetType().GetMethod("DeleteConfirmed").Name}",
                       ObjetoJson: JsonConvert.SerializeObject(t)
                   );

            return RedirectToAction(nameof(Index));
        }

        public virtual IActionResult Details(Guid id)
        {
            _log.RegistrarLog
                   (
                       Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Iniciando Módulo {this.GetType().GetMethod("Details").Name}",
                       Controller_Action: $@"[HttpGet]-{this.GetType().Name}/{this.GetType().GetMethod("Details").Name}",
                       ObjetoJson: JsonConvert.SerializeObject(id)
                   );

            var t = _service.GetById(id);

            _log.RegistrarLog
                   (
                       Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Finalizando Módulo {this.GetType().GetMethod("Details").Name}",
                       Controller_Action: $@"[HttpGet]-{this.GetType().Name}/{this.GetType().GetMethod("Details").Name}",
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
                      Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Iniciando Módulo {this.GetType().GetMethod("Edit").Name}",
                      Controller_Action: $@"[HttpGet]-{this.GetType().Name}/{this.GetType().GetMethod("Edit").Name}",
                      ObjetoJson: JsonConvert.SerializeObject(id)
                  );

            var t = _service.GetById(id);

            _log.RegistrarLog
                   (
                       Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Finalizando Módulo {this.GetType().GetMethod("Edit").Name}",
                       Controller_Action: $@"[HttpGet]-{this.GetType().Name}/{this.GetType().GetMethod("Edit").Name}",
                       ObjetoJson: JsonConvert.SerializeObject(t)
                   );

            if (t == null)
            {
                return NotFound();
            }
            return View(t);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual IActionResult Edit(Guid id, Vm entity)
        {
            if (ModelState.IsValid)
            {
                _log.RegistrarLog
                  (
                      Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Iniciando Módulo {this.GetType().GetMethod("Edit").Name}",
                      Controller_Action: $@"[HttpPost]-{this.GetType().Name}/{this.GetType().GetMethod("Edit").Name}",
                      ObjetoJson: JsonConvert.SerializeObject(entity)
                  );

                try
                {
                    _service.Update(entity);

                    _log.RegistrarLog
                  (
                      Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Finalizando Módulo {this.GetType().GetMethod("Edit").Name}",
                      Controller_Action: $@"[HttpPost]-{this.GetType().Name}/{this.GetType().GetMethod("Edit").Name}",
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
            return RedirectToAction("Index");
        }

        public virtual IActionResult Index()
        {
            _log.RegistrarLog
                  (
                      Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Iniciando Módulo {this.GetType().GetMethod("Index").Name}",
                      Controller_Action: $@"[HttpGet]-{this.GetType().Name}/{this.GetType().GetMethod("Index").Name}"
                  );

            var t = _service.GetAll();

            _log.RegistrarLog
                  (
                      Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Finalizando Módulo {this.GetType().GetMethod("Index").Name}",
                      Controller_Action: $@"[HttpGet]-{this.GetType().Name}/{this.GetType().GetMethod("Index").Name}",
                      ObjetoJson: JsonConvert.SerializeObject(t)
                  );
            return View();
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

        public void GravarAutenticacao(Usuario user)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, user.NomeDeUsuario));
            claims.Add(new Claim(ClaimTypes.Role, RetornaPerfil(user.TipoUsuario)));

            foreach (var prop in user.GetType().GetProperties())
            {
                claims.Add(new Claim(prop.Name.ToString(), prop.GetValue(user).ToString()));
            }

            var identidadeDeUsuario = new ClaimsIdentity(claims, user.GetType().Name.Replace("ViewModel", ""));
            ClaimsPrincipal claimPrincipal = new ClaimsPrincipal(identidadeDeUsuario);

            var propriedadesDeAutenticacao = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTime.Now.ToLocalTime().AddHours(2),
                IsPersistent = true
            };
            _httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, propriedadesDeAutenticacao);
        }

        private string RetornaPerfil(TipoUsuario tipoUsuario)
        {
            string tipo = "";
            switch (tipoUsuario)
            {
                case TipoUsuario.Administrador:
                    tipo = "admin";
                    break;
                case TipoUsuario.Terapeuta:
                    tipo = "terapeuta";
                    break;
                case TipoUsuario.Paciente:
                    tipo = "paciente";
                    break;
                case TipoUsuario.FreeUser:
                    tipo = "freeUser";
                    break;
            }

            return tipo;
        }

        public void LogOut()
        {
            HttpContext.SignOutAsync();
        }
    }
}
