using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;
using VedaSystem.Web.Controllers.Interface;
using VedaSystem.Web.Utils;

namespace VedaSystem.Web.Controllers
{
    public class HorarioController : BaseController<Horario, HorarioTerapeutaViewModel>, IController<Horario, HorarioTerapeutaViewModel>
    {
        private readonly ITerapiaService _terapiaService;
        public HorarioController(ILogService logService, IHorarioService service, ITerapiaService terapiaService) : base(logService, service)
        {
            _terapiaService = terapiaService;
        }
        public override IActionResult Create()
        {
            DadosExpress dadosExpress = new DadosExpress();
            var usuario = dadosExpress.GetUsuario();
            var terapeuta = dadosExpress.GetTerapeuta();
            HorarioTerapeutaViewModel htvm = new HorarioTerapeutaViewModel();

            htvm.TerapeutaId = (Guid)terapeuta.Id;

            //htvm.Terapias = _terapiaService.BuscarTerapiaPorTerapeuta((Guid)terapeuta.Id);
            htvm.Terapias = _terapiaService.GetAll();

            return _PartilView("Create", null, htvm);
        }

        public override IActionResult CreateWithJson(string entity)
        {
            try
            {
                HorarioTerapeutaViewModel vm = JsonConvert.DeserializeObject<HorarioTerapeutaViewModel>(entity);

                vm.GetType().GetProperty("Id").SetValue(vm, Guid.NewGuid());

                _log.RegistrarLog
                    (
                        Informacao: $@"1º Passo | Contexto de Horario, Iniciando Módulo Create",
                        Controller_Action: $@"[HttpPost]-Horario/Create",
                        ObjetoJson: JsonConvert.SerializeObject(entity)
                    );

                if (ModelState.IsValid)
                {
                    IList<HorarioTerapeutaViewModel> horarios = new List<HorarioTerapeutaViewModel>();

                    while (vm.DiaInicial <= vm.DiaFinal) {
                        
                        var horarioFinal = vm.HorarioFinal;
                        var horarioInicial = vm.HorarioInicial;

                        var cont = 0;

                        while (horarioFinal <= vm.HorarioFinal)
                        {
                            var h = new HorarioTerapeutaViewModel();

                            if (cont > 0)
                            {
                                if (vm.Intervalo != null && vm.Intervalo != 0)
                                {
                                    horarioInicial = horarioFinal.AddMinutes(vm.Intervalo);
                                }
                            }

                            h.TerapeutaId = (Guid)new DadosExpress().GetTerapeuta().Id;
                            h.TerapiaId = vm.TerapiaId;
                            h.HorarioInicial = horarioInicial;
                            h.HorarioFinal = h.HorarioInicial.AddMinutes(vm.DuracaoConsultaEmMinutos);
                            h.Id = Guid.NewGuid();
                            h.DuracaoConsultaEmMinutos = vm.DuracaoConsultaEmMinutos;
                            h.Dia = vm.DiaInicial.Day;
                            h.Mes = vm.DiaInicial.Month;
                            h.Ano = vm.DiaInicial.Year;
                            h.ClassColor = vm.ClassColor;
                            h.Intervalo = vm.Intervalo;
                            h.Reservado = vm.Reservado;
                            h.Hora = horarioInicial;

                            horarioFinal = h.HorarioFinal;
                            _service.Add(h);
                            cont++;
                        }

                        vm.DiaInicial = vm.DiaInicial.AddDays(1);
                        vm.Dia = vm.DiaInicial.Day;
                    }
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                return _PartilView("Create", null, vm);
            }

            return _PartilView("Create", null, vm);
        }
    }
}