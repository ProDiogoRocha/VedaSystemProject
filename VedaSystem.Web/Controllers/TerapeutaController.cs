using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;
using VedaSystem.Web.Controllers.Interface;

namespace VedaSystem.Web.Controllers
{
    [Authorize(Roles = "Admin, Terapeuta, Paciente")]
    public class TerapeutaController : BaseController<Terapeuta, TerapeutaViewModel>, IController<Terapeuta, TerapeutaViewModel>
    {
        ITerapeutaService _terapeutaService;
        IUsuarioService _usuarioService;
        public TerapeutaController(ILogService logService, ITerapeutaService service, IUsuarioService usuarioService) : base(logService, service)
        {
            _terapeutaService = service;
            _usuarioService = usuarioService;
        }

        public override IActionResult Index()
        {
            ViewBag.Perfil = _usuarioService.GetByName(User.Identity.Name, "NomeDeUsuario").FirstOrDefault().TipoUsuario;

            _log.RegistrarLog
                 (
                     Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Iniciando Módulo Index",
                     Controller_Action: $@"[HttpGet]-{this.GetType().Name}/Index"
                 );

            var t = _service.GetAll();

            //_log.RegistrarLog
            //      (
            //          Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Finalizando Módulo Index",
            //          Controller_Action: $@"[HttpGet]-{this.GetType().Name}/Index",
            //          ObjetoJson: JsonConvert.SerializeObject(t)
            //      );
            return _PartilView("Index", "", t);
        }


        public override IActionResult Create()
        {
            return _PartilView("Create", "", null);
        }

        public JsonResult BuscarTerapeutasPorTerapia(string nomeTerapia)
        {
            IEnumerable<TerapeutaViewModel> terapeutaViewModel = _terapeutaService.GetTerapeutasPorTerapiaOuTerapeuta(nomeTerapia);

            return _PartilView(NomePartial: "_TerapeutasList", DivRender: "", Model: terapeutaViewModel);
        }

        [HttpPost]
        public override IActionResult Create(TerapeutaViewModel entity, string returnUrl = null)
        {
            entity.GetType().GetProperty("Id").SetValue(entity, Guid.NewGuid());
            _log.RegistrarLog
                (
                    Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Iniciando Módulo Create",
                    Controller_Action: $@"[HttpPost]-{this.GetType().Name}/Create",
                    ObjetoJson: JsonConvert.SerializeObject(entity)
                );

            if (entity.ImagemUpload != null)
            {
                MemoryStream ms = new MemoryStream();
                entity.ImagemUpload.OpenReadStream().CopyTo(ms);

                entity.Logo = ms.GetBuffer();
            }

            if (ModelState.IsValid)
            {
                _service.Add(entity);
                _usuarioService.Add(new UsuarioViewModel()
                {
                    Id = Guid.NewGuid()
                    ,
                    TipoUsuario = Domain.Enums.TipoUsuario.Terapeuta
                    ,
                    Senha = entity.Senha
                    ,
                    ConfirmeSenha = entity.ConfirmeSenha
                    ,
                    DataCadastro = DateTime.Now
                    ,
                    DataNascimento = entity.DataNascimento
                    ,
                    Email = entity.Email
                    ,
                    Endereco = entity.Endereco
                    ,
                    Foto = entity.Logo
                    ,
                    NomeDeUsuario = entity.NomeDeUsuario
                });

                return RedirectToAction(nameof(Index));
            }

            return View(entity);
        }


        public override IActionResult CreateWithJson(string entity)
        {
            TerapeutaViewModel terapeutaViewModel = new TerapeutaViewModel();
            try
            {
                var format = "yyyy-MM-dd HH:mm:ss";
                var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };
                terapeutaViewModel = JsonConvert.DeserializeObject<TerapeutaViewModel>(entity);
            }
            catch (Exception e)
            {

            }
            _log.RegistrarLog
                (
                    Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Iniciando Módulo Create",
                    Controller_Action: $@"[HttpPost]-{this.GetType().Name}/Create",
                    ObjetoJson: JsonConvert.SerializeObject(terapeutaViewModel)
                );

            if (terapeutaViewModel.ImagemUpload != null)
            {
                MemoryStream ms = new MemoryStream();
                terapeutaViewModel.ImagemUpload.OpenReadStream().CopyTo(ms);

                terapeutaViewModel.Logo = ms.GetBuffer();
            }

            if (ModelState.IsValid)
            {
                _service.Add(terapeutaViewModel);
                _usuarioService.Add(new UsuarioViewModel()
                {
                     Id = Guid.NewGuid()
                    ,TipoUsuario = Domain.Enums.TipoUsuario.Terapeuta
                    ,Senha = terapeutaViewModel.Senha
                    ,ConfirmeSenha = terapeutaViewModel.ConfirmeSenha
                    ,DataCadastro = DateTime.Now
                    ,DataNascimento = terapeutaViewModel.DataNascimento
                    ,Email = terapeutaViewModel.Email
                    ,Endereco = terapeutaViewModel.Endereco
                    ,Foto = terapeutaViewModel.Logo
                    ,NomeDeUsuario = terapeutaViewModel.NomeDeUsuario
                });

                return RedirectToAction(nameof(Index));
            }

            return _PartilView("Create", null, terapeutaViewModel);
        }

        public override IActionResult Edit(Guid id)
        {
            _log.RegistrarLog
                  (
                      Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Iniciando Módulo Edit",
                      Controller_Action: $@"[HttpGet]-{this.GetType().Name}/Edit",
                      ObjetoJson: JsonConvert.SerializeObject(id)
                  );

            var t = _service.GetById(id);

            _log.RegistrarLog
                   (
                       Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Finalizando Módulo Edit",
                       Controller_Action: $@"[HttpGet]-{this.GetType().Name}/DeleteConfirmed",
                       ObjetoJson: JsonConvert.SerializeObject(t)
                   );

            if (t == null)
            {
                return NotFound();
            }
            return _PartilView("Edit", "", t);
        }
    }
}
