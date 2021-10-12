using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;
using VedaSystem.Web.Controllers.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Linq;

namespace VedaSystem.Web.Controllers
{
    public class EmailController : BaseController<Email, EmailViewModel>, IController<Email, EmailViewModel>
    {
        private readonly IEmailService _emailService;
        public EmailController(ILogService logService, IEmailService service) : base(logService, service)
        {
            _emailService = service;
        }

        public IActionResult Inbox(Guid IdTerapeuta)
        {
            Email emailConfig = _emailService.GetDadosDeEmailPorTerapeuta(IdTerapeuta);

            InboxViewModel inbox = new InboxViewModel();

            inbox.EmailMessages = _emailService.GetEmailsInBox(emailConfig).OrderBy(e=>e.Data);
            inbox.QtdRegistros = _emailService.GetQtdEmails(emailConfig);
            inbox.QtdNaoLidos = _emailService.GetQtdEmailsNaoLidos(emailConfig);

            return _PartilView("Inbox", null, inbox);
        }

        public IActionResult InboxMessages(Guid IdTerapeuta, int de, int ate)
        {
            Email emailConfig = _emailService.GetDadosDeEmailPorTerapeuta(IdTerapeuta);

            return _PartilView("_ListMessage", null, _emailService.GetEmailsInBox(emailConfig, de, ate));
        }

        [HttpPost]
        public IActionResult MessageInbox(EmailMessageViewModel mail)
        {
            return _PartilView("_Message", null, mail);
        }

        public override IActionResult Create()
        {
            IList<SelectListItem> select = new List<SelectListItem>();

            select.Add(new SelectListItem()
            { Text = "Network", Value = "0" });
            select.Add(new SelectListItem()
            { Text = "SpecifiedPickupDirectory", Value = "1" });
            select.Add(new SelectListItem()
            { Text = "PickupDirectoryFromIis", Value = "2" });

            ViewBag.SmtpDeliveryMethodList = select;

            return _PartilView("Create", "", null);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public override IActionResult Create(EmailViewModel entity, string returnUrl = null)
        {
            entity.GetType().GetProperty("Id").SetValue(entity, Guid.NewGuid());
            _log.RegistrarLog
                (
                    Informacao: $@"1º Passo | Contexto de {this.GetType().Name.Replace("Controller", "")}, Iniciando Módulo Create",
                    Controller_Action: $@"[HttpPost]-{this.GetType().Name}/Create",
                    ObjetoJson: JsonConvert.SerializeObject(entity)
                );

            if (ModelState.IsValid)
            {
                _service.Add(entity);
                return RedirectToAction(nameof(Index));
            }

            return View(entity);
        }

        public IActionResult InboxGenericosMessages(Guid IdTerapeuta, string tipoMensagem, int de, int ate)
        {
            Email emailConfig = _emailService.GetDadosDeEmailPorTerapeuta(IdTerapeuta);

            return _PartilView("_ListMessage", null, _emailService.GetEmailsInBox(emailConfig, tipoMensagem, de, ate));
        }

        [HttpGet]
        public bool UpdateInfoMailBench(Guid terapeutaId, string IdMessage, bool benchmark)
        {
            bool retorno = false;
            try
            {
                InfoMail infoMail = _emailService.GetInfoMailById(terapeutaId, IdMessage);
                infoMail.Benchmark = benchmark;
                _emailService.UpdateInfoMail(infoMail);
                retorno = true;
            }
            catch
            {
                retorno = false;
            }

            return retorno;
        }

        [HttpGet]
        public IActionResult AbrirMensagem(Guid terapeutaId, string messageId)
        {
            Email emailConfig = _emailService.GetDadosDeEmailPorTerapeuta(terapeutaId);
            EmailMessageViewModel messageViewModel = _emailService.GetMessageById(emailConfig, messageId);

            return _PartilView("_Message", null, messageViewModel);
        }
    }
}
