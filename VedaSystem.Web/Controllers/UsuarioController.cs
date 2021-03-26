using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.Utils;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;
using VedaSystem.Web.Controllers.Interface;
using VedaSystem.Web.Models;

namespace VedaSystem.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsuarioController : BaseController<Usuario, UsuarioViewModel>, IController<Usuario, UsuarioViewModel>
    {
        private readonly IUsuarioService _usuarioService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<Application.Utils.ApplicationUser> _userManager;
        private readonly SignInManager<Application.Utils.ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;

        public UsuarioController(
              ILogService logger
            , IUsuarioService usuarioService
            , IEmailSender emailSender
            , RoleManager<IdentityRole> roleManager
            , UserManager<Application.Utils.ApplicationUser> userManager
            , SignInManager<Application.Utils.ApplicationUser> signInManager
            )
            : base(logger, usuarioService, entityName: "UsuarioController")
        {
            _usuarioService = usuarioService;
            _roleManager = roleManager;
            _userManager = userManager;
            _emailSender = emailSender;
            _signInManager = signInManager;
        }

        public override IActionResult Create()
        {
            vm = new UsuarioViewModel(_usuarioService);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public override IActionResult Create(UsuarioViewModel entity, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                return base.Create(entity);
            }
            else
            {
                return View(entity);
            }
        }

        public override IActionResult DeleteConfirmed(Guid id)
        {
            UsuarioViewModel usuarioViewModel = _usuarioService.GetById(id);

            ApplicationUser appUser = new ApplicationUser()
            {
                UserName = usuarioViewModel.NomeDeUsuario
                ,
                Email = usuarioViewModel.Email
                ,
                Id = usuarioViewModel.Id.ToString()
            };

            _userManager.DeleteAsync(appUser);

            return base.DeleteConfirmed(id);
        }

        public override IActionResult Edit(Guid id, UsuarioViewModel entity)
        {
            ApplicationUser appUser = new ApplicationUser()
            {
                UserName = entity.NomeDeUsuario
                ,
                Email = entity.Email
                ,
                Id = entity.Id.ToString()
                ,
                PasswordHash = entity.Senha
            };

            _userManager.UpdateAsync(appUser);

            var applicationRole = _roleManager.FindByNameAsync(entity.TipoUsuarioName).Result;

            if (applicationRole != null)
            {
                IdentityResult roleResult = _userManager.AddToRoleAsync(appUser, applicationRole.Name).Result;
            }

            entity.GetTipoUsuarioEnum();

            entity = Cripto<UsuarioViewModel>.CriptografarDadosSigilosos(entity);

            return base.Edit(id, entity);
        }

        public IActionResult ConfirmEmail()
        {
            return View();
        }
    }
}
