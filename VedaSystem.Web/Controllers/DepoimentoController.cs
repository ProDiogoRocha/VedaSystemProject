using Microsoft.AspNetCore.Mvc;
using System;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;
using VedaSystem.Web.Controllers.Interface;
using VedaSystem.Web.Utils;

namespace VedaSystem.Web.Controllers
{
    public class DepoimentoController : BaseController<Depoimento, DepoimentoViewModel>, IController<Depoimento, DepoimentoViewModel>
    {
        private readonly IDepoimentoService _depoimentoService;

        public DepoimentoController(ILogService logService, IDepoimentoService service) : base(logService, service)
        {
            _depoimentoService = service;
        }

        public override IActionResult Create()
        {
            DadosExpress dadosExpress = new DadosExpress();
            DepoimentoViewModel dvm = _depoimentoService.GetDepoimentoByIdUsuario((Guid)dadosExpress.GetUsuario().Id);
            return _PartilView("Create", "", dvm);
        }
    }
}
