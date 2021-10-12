using MimeKit;
using System;
using System.Collections.Generic;
using VedaSystem.Domain.Models;

namespace VedaSystem.Domain.Interfaces
{
    public interface IEmailRepository : IRepository<Email>
    {
        Email GetPorIdTerapeuta(Guid? IdTerapeuta);
        IEnumerable<EmailMessageTran> GetEmailsInBox(Email emailConfig, int de, int ate);
        IEnumerable<EmailMessageTran> GetEmailsInBox(Email emailConfig);
        void DeleteMessage(Email emailConfig, string messageId);
        void SendMessage(Email emailConfig);
        IEnumerable<MimeMessage> GetEmailPorRemetente(Email emailConfig, string nomeRemetente);
        IEnumerable<MimeMessage> GetEmailPorTitulo(Email emailConfig, string tituloDoEmail);
        InfoMail GetInfoMail(Guid idTerapeuta, string idEmail);
        void InsertInfoMail(InfoMail infoMail);
        void UpdateInfoMail(InfoMail infoMail);
        IEnumerable<InfoMail> GetAllInfoMail(Guid idTerapeuta);
        InfoMail GetInfoMailById(string idEmail);
        int GetQtdEmails(Email emailConfig);
        int GetQtdEmailsNaoLidos(Email emailConfig);
        MimeMessage GetMessageById(Email emailConfig, string messageId);
    }
}
