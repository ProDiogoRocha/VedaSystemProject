using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VedaSystem.Domain.Models;

namespace VedaSystem.UI.Web.Controllers.Interface
{
    public interface IController<T, Vm> where T : class where Vm : class
    {
        IActionResult Index();
        IActionResult Details(Guid id);
        IActionResult Create();
        IActionResult Create(Vm entity);
        IActionResult Edit(Guid id);
        IActionResult Edit(Guid id, Vm entity);
        IActionResult Delete(Guid id);
        IActionResult DeleteConfirmed(Guid id);
        ActionResult ValidaSeLogadoRetornandoView(Vm t, string viewRetornoSeLogado, string controllerSeDeslogado, string actionSeDeslogado);
        JsonResult _PartilView(string NomePartial, string DivRender, object Model = null);
        public void GravarAutenticacao(Usuario user);
        public void LogOut();
        bool UsuarioExists(Guid id);
    }
}
