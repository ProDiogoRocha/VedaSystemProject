using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;
using VedaSystem.Web.Controllers.Interface;

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

            IEnumerable<EmailMessageViewModel> emailMessages = _emailService.GetEmailsInBox(emailConfig);

            return _PartilView("Inbox", null, emailMessages);
        }

        [HttpPost]
        public IActionResult MessageInbox(EmailMessageViewModel mail)
        {
            return _PartilView("_Message", null, mail);
        }
    }
}
