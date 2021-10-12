using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.Utils;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Enums;
using VedaSystem.Domain.Models;

namespace VedaSystem.Web.Controllers
{
    [AllowAnonymous]
    public class LoginController : BaseController<Usuario, UsuarioViewModel>
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ITerapeutaService _terapeutaService;
        private readonly IEmailService _emailService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public LoginController(
              IUsuarioService usuarioService
            , ITerapeutaService terapeutaService
            , IEmailService emailService
            , ILogService logService
            , RoleManager<IdentityRole> roleManager
            , UserManager<ApplicationUser> userManager
            , SignInManager<ApplicationUser> signInManager
            )
            : base(logService, usuarioService)
        {
            _usuarioService = usuarioService;
            _terapeutaService = terapeutaService;
            _emailService = emailService;
            _httpContext = HttpContext;
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public override IActionResult Index()
        {
            UsuarioViewModel usuario = new UsuarioViewModel();

            if (User.Identity.Name != null)
            {
                LogOut(User.Identity.Name);
            }

            _log.RegistrarLog(
                  Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Iniciando Módulo {this.GetType().GetMethod("Index").Name}",
                  Controller_Action: $@"[HttpPost]-{this.GetType().Name}/{this.GetType().GetMethod("Index").Name}");

            var usuarios = _usuarioService.GetAll();

            if (usuarios.ToList().Count() == 0)
            {
                usuario = new UsuarioViewModel("VedaAdmin", "VedaAdmin", DateTime.Now, "VedaCorp", "vedaadmin@vedasystem.com.br", DateTime.Now, TipoUsuario.Admin);

                _usuarioService.Add(usuario);

                _log.RegistrarLog(
                        Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Finalizando Módulo {this.GetType().GetMethod("Index").Name}"
                      , Controller_Action: $@"[HttpPost]-{this.GetType().Name}/{this.GetType().GetMethod("Index").Name}"
                      , ObjetoJson: JsonConvert.SerializeObject(usuario)
                      );
            }
            return View();
        }


        [HttpPost]
        public IActionResult EfetuarLogin(LoginViewModel login)
        {
            if (User.Identity.IsAuthenticated)
            {
                LogOut(User.Identity.Name);
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

            string controller = "";

            if (usuario != null)
            {
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
        public IActionResult ColetarDados()
        {
            var teste = Response.Cookies;

            return Json("teste");
        }

        [HttpGet]
        public IActionResult EfetuarLogoff()
        {
            _log.RegistrarLog(
                      Informacao: $@"1º Passo | Contexto de Login , Inciando Módulo EfetuarLogoff"
                    , Controller_Action: $@"[HttpGet]-{this.GetType().Name}/{this.GetType().GetMethod("EfetuarLogoff").Name}");

            if (User.Identity.IsAuthenticated)
            {
                LogOut(User.Identity.Name);

                _log.RegistrarLog(
                      Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Finalizando Módulo {this.GetType().GetMethod("EfetuarLogoff").Name}"
                    , Controller_Action: $@"[HttpGet]-{this.GetType().Name}/{this.GetType().GetMethod("EfetuarLogoff").Name}");
            }
            return RedirectToAction("Index");
        }

        public void GravarAutenticacao(Usuario user)
        {
            ApplicationUser usuario = _userManager.FindByIdAsync(userId: user.Id.ToString()).Result;

            var claims = new List<Claim>();

            var roles = _userManager.GetRolesAsync(usuario).Result;

            foreach (var roleName in roles)
            {
                claims.Add(new Claim(IdentityModel.JwtClaimTypes.Role, roleName));
                if (_roleManager.SupportsRoleClaims)
                {
                    var role = _roleManager.FindByNameAsync(roleName).Result;
                    if (role != null)
                    {
                        claims.AddRange(_roleManager.GetClaimsAsync(role).Result);
                    }
                }
            }

            var propriedadesDeAutenticacao = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTime.Now.ToLocalTime().AddHours(2),
                IsPersistent = true
            };

            _signInManager.SignInAsync(usuario, isPersistent: false);

            var identidadeDeUsuario = new ClaimsIdentity(claims, "Login");
            ClaimsPrincipal claimPrincipal = new ClaimsPrincipal(identidadeDeUsuario);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, propriedadesDeAutenticacao);
        }

        private async void LogOut(string nomeCookie)
        {
            await _signInManager.SignOutAsync();
        }
    }
}
