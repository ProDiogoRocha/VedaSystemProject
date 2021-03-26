using Microsoft.AspNetCore.Mvc;
using System;

namespace VedaSystemProject.UI.Web.Controllers.Base
{
    public abstract class BaseController : Controller
    {
        public Log _log;

        public BaseController(ILogService logService)
        {
            _log = new Log(logService);
        }
        public JsonResult _PartilView(string NomePartial, string DivRender, object Model = null)
        {
            dynamic ret = new
            {
                View = _RenderRazorViewToString(ControllerContext, NomePartial, Model),
                RenderView = "true",
                DivRender = DivRender,
                DivExibir = "true"
            };

            JsonResult jsonResult = Json(ret, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        public static string _RenderRazorViewToString(ControllerContext controllerContext, string viewName, object model)
        {
            controllerContext.Controller.ViewData.Model = model;
            using (var sw = new System.IO.StringWriter())
            {
                var ViewResult = ViewEngines.Engines.FindPartialView(controllerContext, viewName);
                var ViewContext = new ViewContext(controllerContext, ViewResult.View, controllerContext.Controller.ViewData, controllerContext.Controller.TempData, sw);
                try
                {
                    ViewResult.View.Render(ViewContext, sw);
                    ViewResult.ViewEngine.ReleaseView(controllerContext, ViewResult.View);
                }
                catch (Exception e)
                {
                    throw e;
                }
                return sw.GetStringBuilder().ToString();
            }
        }

        public void GravarCookie(object obj)
        {
            HttpCookie cookie = null;
            cookie = Request.Cookies[obj.GetType().Name];

            if (cookie == null || cookie.Expires < DateTime.Now)
            {
                cookie = new HttpCookie(obj.GetType().Name);
                foreach (var o in obj.GetType().GetProperties())
                {
                    cookie.Values.Add(o.Name, o.GetValue(obj, null).ToString());
                }

                cookie.Expires = DateTime.Now.AddMinutes(120);
                cookie.HttpOnly = true;
                Response.AppendCookie(cookie);
            }
        }

        public Usuario GetUsuarioLogado()
        {
            Usuario usuario;
            try
            {
                HttpCookie cookie = Request.Cookies["Usuario"];

                if (cookie != null)
                {
                    usuario = new Usuario
                        (
                            id: Guid.Parse(cookie["Id"]),
                            nomeDeUsuario: cookie["NomeDeUsuario"],
                            senha: cookie["Senha"],
                            dataNascimento: Convert.ToDateTime(cookie["DataNascimento"]),
                            endereco: cookie["Endereco"],
                            email: cookie["Email"],
                            dataCadastro: Convert.ToDateTime(cookie["DataCadastro"]),
                            tipoUsuario: (TipoUsuario)Convert.ToInt16(cookie["TipoUsuario"])
                        );
                }
                else
                {
                    usuario = new Usuario();
                }
            }
            catch (Exception e)
            {
                usuario = null;
            }
            return usuario;
        }

        public void RemoverCookie(object obj)
        {
            HttpCookie vCookie = new HttpCookie(obj.GetType().Name);
            vCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(vCookie);
        }

        public ActionResult ValidaSeLogadoRetornandoView(Usuario usuario, string viewRetornoSeLogado, string controllerSeDeslogado, string actionSeDeslogado)
        {
            if (usuario != null)
            {
                return View(viewRetornoSeLogado);
            }
            else
            {
                return RedirectToAction(actionSeDeslogado, controllerSeDeslogado);
            }
        }
    }
}
