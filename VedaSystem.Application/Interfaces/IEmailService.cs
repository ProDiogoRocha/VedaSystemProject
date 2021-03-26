using OpenPop.Mime;
using System;
using System.Collections.Generic;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.Interfaces
{
    public interface IEmailService : IService<Email, EmailViewModel>
    {
        bool EnviarEmail(Email email, Guid IdTerapeuta);
        Email GetDadosDeEmailPorTerapeuta(Guid IdTerapeuta);
        IEnumerable<Message> GetEmailPorRemetente(Email emailConfig, string nomeRemetente);
        IEnumerable<Message> GetEmailPorTitulo(Email emailConfig, string tituloDoEmail);
        IEnumerable<EmailMessageViewModel> GetEmailsInBox(Email emailConfig);
        void DeleteMessage(Email emailConfig, int messageNumber);
        void SendMessage(Email emailConfig);
    }
}
