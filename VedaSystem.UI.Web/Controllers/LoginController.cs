using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.Utils;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Enums;
using VedaSystem.Domain.Models;

namespace VedaSystem.UI.Web.Controllers
{
    public class LoginController : BaseController<Usuario, UsuarioViewModel>
    {
        private readonly IUsuarioService _usuarioService;
        public LoginController(IUsuarioService usuarioService, ILogService logService) : base(logService, usuarioService)
        {
            _usuarioService = usuarioService;
            _httpContext = HttpContext;
        }

        [AllowAnonymous]
        public override IActionResult Index()
        {
            UsuarioViewModel usuario = new UsuarioViewModel();

            _log.RegistrarLog(
                  Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Iniciando Módulo {this.GetType().GetMethod("Index").Name}",
                  Controller_Action: $@"[HttpPost]-{this.GetType().Name}/{this.GetType().GetMethod("Index").Name}");

            var usuarios = _usuarioService.GetAll();

            if (usuarios.ToList().Count() == 0)
            {
                usuario = new UsuarioViewModel(Guid.NewGuid(), "VedaAdmin", Cripto<LoginViewModel>.Criptografar("VedaAdmin"), DateTime.Now, "VedaCorp", "vedaadmin@vedasystem.com.br", DateTime.Now, TipoUsuario.Administrador);
                _usuarioService.Add(usuario);
            }

            _log.RegistrarLog(
                    Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Finalizando Módulo {this.GetType().GetMethod("Index").Name}"
                  , Controller_Action: $@"[HttpPost]-{this.GetType().Name}/{this.GetType().GetMethod("Index").Name}"
                  , ObjetoJson: JsonConvert.SerializeObject(usuario)
                  );

            return base.Index();
        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult EfetuarLogin(LoginViewModel login)
        {
            if (User.Identity.IsAuthenticated)
            {
                HttpContext.SignOutAsync();
            }

            Usuario usuario = null;

            _log.RegistrarLog(
                  Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Iniciando Módulo {this.GetType().GetMethod("EfetuarLogin").Name}",
                  Controller_Action: $@"[HttpPost]-{this.GetType().Name}/{this.GetType().GetMethod("EfetuarLogin").Name}"
                , ObjetoJson: JsonConvert.SerializeObject(login));

            try
            {
                usuario = _usuarioService.GetUsuarioPorLogin(login.Email, Cripto<LoginViewModel>.Criptografar(login.Senha)).Result;
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                      Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Finalizando Módulo {this.GetType().GetMethod("EfetuarLogin").Name}"
                    , Controller_Action: $@"[HttpPost]-{this.GetType().Name}/{this.GetType().GetMethod("EfetuarLogin").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(login)
                    , Erro: e.Message
                    , Excecao: e.ToString());
            }

            var controller = "";

            if (usuario != null)
            {
                _httpContext = HttpContext;
                GravarAutenticacao(usuario);

                _log.RegistrarLog(
                      Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Usuario Encontrado--> Gravando Cookie {this.GetType().GetMethod("EfetuarLogin").Name}"
                    , Controller_Action: $@"[HttpPost]-{this.GetType().Name}/{this.GetType().GetMethod("EfetuarLogin").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(usuario));

                controller = "Home";
            }
            else
            {
                _log.RegistrarLog(
                       Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Usuario não encontrado {this.GetType().GetMethod("EfetuarLogin").Name}"
                     , Controller_Action: $@"[HttpPost]-{this.GetType().Name}/{this.GetType().GetMethod("EfetuarLogin").Name}"
                     , ObjetoJson: JsonConvert.SerializeObject(usuario));

                controller = "Login";
            }

            _log.RegistrarLog(
                 Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Finalizando Módulo {this.GetType().GetMethod("EfetuarLogin").Name}",
                 Controller_Action: $@"[HttpPost]-{this.GetType().Name}/{this.GetType().GetMethod("EfetuarLogin").Name}"
               , ObjetoJson: JsonConvert.SerializeObject(usuario));

            return RedirectToAction("Index", controller);
        }

        [HttpGet]
        public ActionResult EfetuarLogoff()
        {
            _log.RegistrarLog(
                      Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Inciando Módulo {this.GetType().GetMethod("EfetuarLogoff").Name}"
                    , Controller_Action: $@"[HttpGet]-{this.GetType().Name}/{this.GetType().GetMethod("EfetuarLogoff").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(User));

            if (User.Identity.IsAuthenticated)
            {
                LogOut();

                _log.RegistrarLog(
                      Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Finalizando Módulo {this.GetType().GetMethod("EfetuarLogoff").Name}"
                    , Controller_Action: $@"[HttpGet]-{this.GetType().Name}/{this.GetType().GetMethod("EfetuarLogoff").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(User));
            }
            return RedirectToAction("Index");
        }
    }
}
