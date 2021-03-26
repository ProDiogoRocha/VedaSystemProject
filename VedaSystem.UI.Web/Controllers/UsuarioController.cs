using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;

namespace VedaSystem.UI.Web.Controllers
{
    public class UsuarioController : BaseController<Usuario, UsuarioViewModel>
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(ILogService logger, IUsuarioService usuarioService) : base(logger, usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [Authorize("admin", Roles = "admin")]
        public override IActionResult Index()
        {
            return base.Index();
        }
    }
}
