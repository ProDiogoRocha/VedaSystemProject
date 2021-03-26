using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Application.ViewModels.CadastroMateriaisTerapia;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Interfaces.Services;
using VedaSystem.UI.Web.Controllers.Interface;

namespace VedaSystem.UI.Web.Controllers
{
    public class TerapeutaController : BaseController<Terapeuta, TerapeutaViewModel>, IController<Terapeuta, TerapeutaViewModel>
    {
        ITerapeutaService _terapeutaService;
        public TerapeutaController(ILogService logService, ITerapeutaService service) : base(logService, service)
        {
            _terapeutaService = service;
        }


        //[HttpPost]
        //public JsonResult CreateTerapia(string tVM)
        //{
        //    TerapiaViewModel terapiaViewModel = JsonConvert.DeserializeObject<TerapiaViewModel>(tVM);

        //    Usuario usuario = GetUsuarioLogado();

        //    //CadastroMateriaisTerapiaViewModel model;
        //    //if (ModelState.IsValid)
        //    //{
        //    //    terapiaViewModel.Id = Guid.NewGuid();
        //    //    Terapia terapia = _terapiaMapperProfile.MapperConfig.Map<TerapiaViewModel, Terapia>(terapiaViewModel);
        //    //    terapia.Terapeutas = new List<Terapeuta>();
        //    //    Terapeuta terapeuta = _terapeutaService.GetTerapeutaPorNomeDeUsuario(usuario.NomeDeUsuario);
        //    //    terapia.Terapeutas.Add(terapeuta);

        //    //    if (usuario.TipoUsuario == 1)
        //    //    {
        //    //        _terapiaService.Adicionar(terapia);
        //    //    }
        //    //    else
        //    //    {
        //    //        TerapiaPrincipal terapiaP = new TerapiaPrincipal();

        //    //        terapiaP.Id = Guid.NewGuid();
        //    //        terapiaP.IdTerapia = terapia.Id;
        //    //        terapiaP.Duracao = terapia.Duracao;
        //    //        terapiaP.Materiais = terapia.Materiais;
        //    //        terapiaP.NomeTerapia = terapia.NomeTerapia;
        //    //        terapiaP.Observacao = terapia.Observacao;
        //    //        terapiaP.Terapeutas = terapia.Terapeutas;
        //    //        terapiaP.Agendas = terapia.Agendas;

        //    //        _terapiaPrincipalService.Adicionar(terapiaP);
        //        }


        //    //    terapiaViewModel = _terapiaMapperProfile.MapperConfig.Map<Terapia, TerapiaViewModel>(_terapiaService.GetPorId(terapiaViewModel.Id));

        //    //    model = new CadastroMateriaisTerapiaViewModel
        //    //       (
        //    //           idMaterial: Guid.NewGuid(),
        //    //           quantidade: 0,
        //    //           idTerapia: terapiaViewModel.Id,
        //    //           idEstoqueMaterial: null,
        //    //           listaEstoqueDeMateriais: _estoqueMaterialMapperProfile.EntityToViewModel(_estoqueMaterialService.GetTodos())
        //    //       );
        //    //}
        //    //else
        //    //{
        //    //    model = new CadastroMateriaisTerapiaViewModel();
        //    //}
        //    //return _PartilView("_CadastroMaterialTerapia", "form-cadastro-materiais", model);
        //}
    }
}
