using MimeKit;
using System;
using System.Collections.Generic;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.Interfaces
{
    public interface IEmailService : IService<Email, EmailViewModel>
    {
        bool EnviarEmail(Email email, Guid IdTerapeuta);
        Email GetDadosDeEmailPorTerapeuta(Guid? IdTerapeuta);
        IEnumerable<MimeMessage> GetEmailPorRemetente(Email emailConfig, string nomeRemetente);
        IEnumerable<MimeMessage> GetEmailPorTitulo(Email emailConfig, string tituloDoEmail);
        IEnumerable<EmailMessageViewModel> GetEmailsInBox(Email emailConfig, int de = 1, int ate = 10);
        IEnumerable<EmailMessageViewModel> GetEmailsInBox(Email emailConfig, string tipoMensagem, int de = 1, int ate = 10);
        void DeleteMessage(Email emailConfig, string messageId);
        void SendMessage(Email emailConfig);
        int GetQtdEmails(Email emailConfig);
        int GetQtdEmailsNaoLidos(Email emailConfig);
        InfoMail GetInfoMailById(Guid terapeutaId, string messageId);
        void InsertInfoMail(InfoMail infoMail);
        void UpdateInfoMail(InfoMail infoMail);
        EmailMessageViewModel GetMessageById(Email emailConfig, string messageId);
    }
}
