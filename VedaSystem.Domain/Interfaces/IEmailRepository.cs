using System;
using System.Collections.Generic;
using VedaSystem.Domain.Models;
using OpenPop.Mime;

namespace VedaSystem.Domain.Interfaces
{
    public interface IEmailRepository : IRepository<Email>
    {
        Email GetPorIdTerapeuta(Guid? IdTerapeuta);
        IEnumerable<Message> GetEmailsInBox(Email emailConfig);
        void DeleteMessage(Email emailConfig, int messageNumber);
        void SendMessage(Email emailConfig);
        IEnumerable<Message> GetEmailPorRemetente(Email emailConfig, string nomeRemetente);
        IEnumerable<Message> GetEmailPorTitulo(Email emailConfig, string tituloDoEmail);
        InfoMail GetInfoMail(Guid idTerapeuta, string idEmail);
        void InsertInfoMail(InfoMail infoMail);
        void UpdateInfoMail(InfoMail infoMail);
        IEnumerable<InfoMail> GetAllInfoMail(Guid idTerapeuta);
        InfoMail GetInfoMailById(string idEmail);
    }
}
