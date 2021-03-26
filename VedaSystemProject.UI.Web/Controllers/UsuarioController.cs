using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using VedaSystemProject.Application.Interfaces;
using VedaSystemProject.Application.ViewModels;

namespace VedaSystemProject.UI.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<IActionResult> Index()
        {
            return View( await _usuarioService.GetAll());
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();

            var customerViewModel = await _usuarioService.GetById(id.Value);

            if (customerViewModel == null) return NotFound();

            return View(customerViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NomeDeUsuario,Senha,ConfirmeSenha,DataNascimento,Endereco,Email,DataCadastro,TipoUsuario")] UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                usuarioViewModel.Id = Guid.NewGuid();
                usuarioViewModel = Cripto<UsuarioViewModel>.CriptografarDadosSigilosos(usuarioViewModel);
                _usuarioService.Adicionar(_usuarioMapperProfile.MapperConfig.Map<UsuarioViewModel, Usuario>(usuarioViewModel));
                return RedirectToAction("Index");
            }
            return View(usuarioViewModel);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioViewModel usuarioViewModel = _usuarioMapperProfile.MapperConfig.Map<Usuario, UsuarioViewModel>(_usuarioService.GetPorId(id));
            if (usuarioViewModel == null)
            {
                return HttpNotFound();
            }
            return View(usuarioViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Senha,ConfirmeSenha,DataNascimento,Endereco,Email,DataCadastro,TipoUsuario")] UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                _usuarioService.Atualizar(_usuarioMapperProfile.MapperConfig.Map<UsuarioViewModel, Usuario>(usuarioViewModel));
                return RedirectToAction("Index");
            }
            return View(usuarioViewModel);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioViewModel usuarioViewModel = _usuarioMapperProfile.MapperConfig.Map<Usuario, UsuarioViewModel>(_usuarioService.GetPorId(id));
            if (usuarioViewModel == null)
            {
                return HttpNotFound();
            }
            return View(usuarioViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _usuarioService.Deletar(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _usuarioService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
