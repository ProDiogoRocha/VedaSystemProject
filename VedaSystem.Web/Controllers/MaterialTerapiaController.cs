using Microsoft.AspNetCore.Mvc;
using System;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;
using VedaSystem.Web.Controllers.Interface;

namespace VedaSystem.Web.Controllers
{
    public class MaterialTerapiaController : BaseController<MaterialTerapia, MaterialTerapiaViewModel>, IController<MaterialTerapia, MaterialTerapiaViewModel>
    {
        private readonly IMaterialTerapiaService _materialTerapiaService;
        public MaterialTerapiaController(ILogService logService, IMaterialTerapiaService service) : base(logService, service)
        {
            _materialTerapiaService = service;
        }

        [HttpGet]
        public int DeleteMaterial(Guid id)
        {
            try
            {
                var t = _service.GetById(id);
                _service.Remove(t);
                return 1;
            }catch(Exception e)
            {
                return 0;
            }
        }

        [HttpGet]
        public void AtualizaQtd(Guid id, int qtd)
        {
            var t = _service.GetById(id, false);
            t.Quantidade = qtd;
            _service.Update(t);
        }
    }
}
