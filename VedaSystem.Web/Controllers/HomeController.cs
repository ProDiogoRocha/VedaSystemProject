using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VedaSystem.Web.Models;

namespace VedaSystem.Web.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize(Roles ="Admin, Terapeuta")]
    public class HomeController : Controller
    {
        public HomeController()
        {
           
        }

        //[AllowAnonymous]
        //[Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
