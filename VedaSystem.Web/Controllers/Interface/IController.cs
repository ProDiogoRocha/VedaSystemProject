using Microsoft.AspNetCore.Mvc;
using System;

namespace VedaSystem.Web.Controllers.Interface
{
    public interface IController<T, Vm> where T : class where Vm : class
    {
        IActionResult Index();
        IActionResult Details(Guid id);
        IActionResult Create();
        IActionResult Create(Vm entity, string returnUrl = null);
        IActionResult Edit(Guid id);
        IActionResult Edit(Guid id, Vm entity);
        IActionResult Delete(Guid id);
        IActionResult DeleteConfirmed(Guid id);
        ActionResult ValidaSeLogadoRetornandoView(Vm t, string viewRetornoSeLogado, string controllerSeDeslogado, string actionSeDeslogado);
        JsonResult _PartilView(string NomePartial, string DivRender, object Model = null);
        bool UsuarioExists(Guid id);
    }
}
