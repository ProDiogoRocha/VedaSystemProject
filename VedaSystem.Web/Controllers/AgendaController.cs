using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Enums;
using VedaSystem.Domain.Models;
using VedaSystem.Web.Controllers.Interface;
using VedaSystem.Web.Enums;
using VedaSystem.Web.Extensions;
using VedaSystem.Web.Utils;

namespace VedaSystem.Web.Controllers
{
    public class AgendaController : BaseController<Agenda, AgendaViewModel>, IController<Agenda, AgendaViewModel>
    {
        private readonly ITerapiaService _terapiaService;
        private readonly IHorarioService _horarioService;
        private readonly ITerapeutaService _terapeutaService;
        public AgendaController(ILogService logService, IAgendaService service, ITerapiaService terapiaService, ITerapeutaService terapeutaService, IHorarioService horarioService) : base(logService, service)
        {
            _terapiaService = terapiaService;
            _horarioService = horarioService;
            _terapeutaService = terapeutaService;
        }

        public IActionResult Calendario()
        {
            DadosExpress dadosExpress = new DadosExpress();
            var dadosUsuario = dadosExpress.GetUsuario();

            CalendarioViewModel cvm = new CalendarioViewModel();

            if (dadosUsuario.TipoUsuario == TipoUsuario.Paciente)
            {
                cvm.Terapias = _terapiaService.GetAll();
            }
            if (dadosUsuario.TipoUsuario == TipoUsuario.Terapeuta)
            {
                var dadosTerapeuta = dadosExpress.GetTerapeuta();
                cvm.Horarios = _horarioService.GetHorariosByIdTerapeuta((Guid)dadosTerapeuta.Id);

                cvm.Horarios.OrderBy(a => a.Hora);

                foreach(var h in cvm.Horarios)
                {
                    h.HIn = h.Hora.ToString("HH:mm:ss");
                    h.FIn = h.Hora.AddMinutes(h.DuracaoConsultaEmMinutos).ToString("HH:mm:ss");
                    h.ClassColor = ((ClassColor)new Random().Next(1, 5)).ObterDescricao();
                    h.DiaIn = h.Hora.Day;
                    h.DiaFim = h.Hora.Day;
                }

                cvm.HorariosJson = JsonConvert.SerializeObject(cvm.Horarios);
                cvm.NomeTerapeuta = dadosTerapeuta.NomeCompleto;
            }
            return _PartilView("Calendario", "", cvm);
        }

        public IActionResult GetTerapeutasByTerapia(Guid idTerapia)
        {
            CalendarioViewModel cvm = new CalendarioViewModel();

            cvm.Terapeutas = _terapeutaService.GetTerapeutasPorTerapia(idTerapia);
            return _PartilView("_DropDownTerapeutas", null, cvm);
        }

        public IActionResult GetCalendarioByTerapeuta(Guid idTerapeuta)
        {
            CalendarioViewModel cvm = new CalendarioViewModel();
            cvm.Horarios = _horarioService.GetHorariosByIdTerapeuta(idTerapeuta);
            return _PartilView("_Calendario", null, cvm);
        }
    }
}
