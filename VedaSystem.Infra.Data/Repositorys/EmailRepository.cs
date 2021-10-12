using ActiveUp.Net.Mail;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using VedaSystem.Domain.Interfaces;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Context;

namespace VedaSystem.Infra.Data.Repositorys
{
    public class EmailRepository : Repository<Email>, IEmailRepository
    {
        private readonly EmailContext Db;
        private readonly DbSet<Email> DbSet;

        private readonly InfoMailContext _DbInfoMail;
        private readonly DbSet<InfoMail> _DbSetInfoMail;

        private readonly ILogRepository _logger;

        public EmailRepository(EmailContext context, InfoMailContext infoMailContext = null, ILogRepository logger = null) : base(context, logger)
        {
            Db = context;
            DbSet = Db.Set<Email>();
            _DbInfoMail = infoMailContext;
            _DbSetInfoMail = _DbInfoMail.Set<InfoMail>();

            _logger = logger;
        }
        public Email GetPorIdTerapeuta(Guid? IdTerapeuta)
        {
            Email email = new Email();

            _logger.RegistrarLog
                 (
                       Informacao: $@"3º Passo | EmailRepository, Iniciando GetPorIdTerapeuta"
                     , Repositorio_Metodo: $@"EmailRepository/GetPorIdTerapeuta"
                     , ObjetoJson: JsonConvert.SerializeObject(IdTerapeuta)
                 );
            try
            {
                email = DbSet.Where(e => e.Terapeuta.Id == IdTerapeuta).FirstOrDefault();
            }
            catch (Exception e)
            {
                _logger.RegistrarLog(
                   Informacao: $@"3º Passo | EmailRepository, Entity GetPorIdTerapeuta"
                 , Repositorio_Metodo: $@"EmailRepository/GetPorIdTerapeuta"
                 , ObjetoJson: JsonConvert.SerializeObject(IdTerapeuta)
                 , Erro: e.Message
                 , Excecao: e.ToString());
            }

            _logger.RegistrarLog
               (
                     Informacao: $@"3º Passo | EmailRepository, Finalizando GetPorIdTerapeuta"
                   , Repositorio_Metodo: $@"EmailRepository/GetPorIdTerapeuta"
                   , ObjetoJson: JsonConvert.SerializeObject(email)
               );
            return email;
        }

        public IEnumerable<MimeMessage> GetEmailPorRemetente(Email emailConfig, string nomeRemetente)
        {
            IList<MimeMessage> mensagens = new List<MimeMessage>();

            _logger.RegistrarLog
                (
                      Informacao: $@"3º Passo | EmailRepository, Iniciando GetEmailPorRemetente"
                    , Repositorio_Metodo: $@"EmailRepository/GetEmailPorRemetente"
                    , ObjetoJson: JsonConvert.SerializeObject(emailConfig)
                );

            try
            {
                using (var client = new ImapClient())
                {
                    client.Connect(emailConfig.Smtp, emailConfig.Port, emailConfig.EnableSsl);

                    client.Authenticate(emailConfig.EmailAdress, emailConfig.Password);

                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);
                    var results = inbox.Search(SearchOptions.All, SearchQuery.Not(SearchQuery.Seen));
                    foreach (var uniqueId in results.UniqueIds)
                    {
                        var message = inbox.GetMessage(uniqueId);
                        if (message.From.Select(a => a.Name.Contains(nomeRemetente)).Count() > 0)
                        {
                            mensagens.Add(message);
                        }

                        //Mark message as read
                        //inbox.AddFlags(uniqueId, MessageFlags.Seen, true);
                    }

                    client.Disconnect(true);
                }
            }
            catch (Exception e)
            {
                _logger.RegistrarLog(
                  Informacao: $@"3º Passo | EmailRepository, Entity GetEmailPorRemetente"
                , Repositorio_Metodo: $@"EmailRepository/GetEmailPorRemetente"
                , Erro: e.Message
                , Excecao: e.ToString());
            }

            _logger.RegistrarLog
              (
                    Informacao: $@"3º Passo | EmailRepository, Finalizando GetEmailPorRemetente"
                  , Repositorio_Metodo: $@"EmailRepository/GetEmailPorRemetente"
                  , ObjetoJson: JsonConvert.SerializeObject(mensagens)
              );

            return mensagens;
        }

        public MimeMessage GetMessageById(Email emailConfig, string messageId)
        {
            MimeMessage message = null;

            InfoMail infoMail = GetInfoMailById(messageId);

            _logger.RegistrarLog
                (
                      Informacao: $@"3º Passo | EmailRepository, Iniciando GetMessageById"
                    , Repositorio_Metodo: $@"EmailRepository/GetMessageById"
                    , ObjetoJson: JsonConvert.SerializeObject(emailConfig)
                );

            try
            {
                using (var client = new ImapClient())
                {
                    client.Connect(emailConfig.Smtp, emailConfig.Port, emailConfig.EnableSsl);

                    client.Authenticate(emailConfig.EmailAdress, emailConfig.Password);

                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);
                    //var results = inbox.Search(SearchOptions.All , SearchQuery.GMailMessageId(Convert.ToUInt64(messageId)));

                    message = inbox.GetMessage(infoMail.Order);

                    client.Disconnect(true);
                }
            }
            catch (Exception e)
            {
                _logger.RegistrarLog(
                  Informacao: $@"3º Passo | EmailRepository, Entity GetMessageById"
                , Repositorio_Metodo: $@"EmailRepository/GetMessageById"
                , Erro: e.Message
                , Excecao: e.ToString());

            }
            return message;
        }

        public IEnumerable<MimeMessage> GetEmailPorTitulo(Email emailConfig, string tituloDoEmail)
        {
            IList<MimeMessage> mensagens = new List<MimeMessage>();

            _logger.RegistrarLog
                (
                      Informacao: $@"3º Passo | EmailRepository, Iniciando GetEmailsInBox"
                    , Repositorio_Metodo: $@"EmailRepository/GetEmailsInBox"
                    , ObjetoJson: JsonConvert.SerializeObject(emailConfig)
                );

            try
            {
                using (var client = new ImapClient())
                {
                    client.Connect(emailConfig.Smtp, emailConfig.Port, emailConfig.EnableSsl);

                    client.Authenticate(emailConfig.EmailAdress, emailConfig.Password);

                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);
                    var results = inbox.Search(SearchOptions.All, SearchQuery.Not(SearchQuery.Seen));
                    foreach (var uniqueId in results.UniqueIds)
                    {
                        var message = inbox.GetMessage(uniqueId);
                        if (message.Subject.Contains(tituloDoEmail))
                        {
                            mensagens.Add(message);
                        }

                        //Mark message as read
                        //inbox.AddFlags(uniqueId, MessageFlags.Seen, true);
                    }

                    client.Disconnect(true);
                }
            }
            catch (Exception e)
            {
                _logger.RegistrarLog(
                  Informacao: $@"3º Passo | EmailRepository, Entity GetEmailsInBox"
                , Repositorio_Metodo: $@"EmailRepository/GetEmailsInBox"
                , Erro: e.Message
                , Excecao: e.ToString());
            }

            _logger.RegistrarLog
              (
                    Informacao: $@"3º Passo | EmailRepository, Finalizando GetEmailsInBox"
                  , Repositorio_Metodo: $@"EmailRepository/GetEmailsInBox"
                  , ObjetoJson: JsonConvert.SerializeObject(mensagens)
              );

            return mensagens.Where(a => a.Subject.Contains(tituloDoEmail)).Select(a => a).ToList();
        }

        public IEnumerable<EmailMessageTran> GetEmailsInBox(Email emailConfig, int de, int ate)
        {
            IList<EmailMessageTran> messages = new List<EmailMessageTran>();
            try
            {
                _logger.RegistrarLog
              (
                    Informacao: $@"3º Passo | EmailRepository, Iniciando GetEmailsInBox"
                  , Repositorio_Metodo: $@"EmailRepository/GetEmailsInBox"
                  , ObjetoJson: JsonConvert.SerializeObject(emailConfig)
              );

                using (var client = new ImapClient())
                {
                    client.Connect(emailConfig.Smtp, emailConfig.Port, emailConfig.EnableSsl);

                    client.Authenticate(emailConfig.EmailAdress, emailConfig.Password);

                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);
                    var results = inbox.Search(SearchOptions.All, SearchQuery.Not(SearchQuery.Seen));

                    de = de == 1 ? results.UniqueIds.Count : ((results.UniqueIds.Count + 1) - de);

                    ate = ((results.UniqueIds.Count + 1) - ate);


                    for (int i = de; i >= ate; i--)
                    {
                        try
                        {
                            MimeMessage m = inbox.GetMessage(i);

                            messages.Add(new EmailMessageTran()
                            {
                                Order = i,
                                Id = m.MessageId,
                                Data = Convert.ToDateTime(m.Date.DateTime),
                                De = !string.IsNullOrEmpty(m.From.Select(a => a.Name).FirstOrDefault()) ? m.From.Select(a => a.Name).FirstOrDefault() : "sem nome",
                                Horario = Convert.ToDateTime(m.Date.DateTime).TimeOfDay.ToString(),
                                Subject = m.Subject,
                                ExistemAnexos = m.Attachments.Any() ? true : false,
                                TerapeutaId = emailConfig.TerapeutaId,
                                Titulo = m.Subject,
                                BodyText = !string.IsNullOrEmpty(m.TextBody) ? m.TextBody : "",
                                BodyHtml = !string.IsNullOrEmpty(m.HtmlBody) ? m.HtmlBody : "",
                                Para = m.To != null ? m.To.Select(a => a.Name).FirstOrDefault() : "",
                                Anexos = m.Attachments.ToList(),
                                PrimeiraLetraDoNome = (!string.IsNullOrEmpty(m.From.Select(a => a.Name).FirstOrDefault())) ? Convert.ToChar(m.From.Select(a => a.Name).FirstOrDefault().Substring(0, 1)) : '.'
                            });
                        }
                        catch (Exception e)
                        {
                            continue;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                _logger.RegistrarLog(
                      Informacao: $@"3º Passo | EmailRepository, Entity GetEmailsInBox"
                    , Repositorio_Metodo: $@"EmailRepository/GetEmailsInBox"
                    , Erro: e.Message
                    , Excecao: e.ToString());
            }

            return messages.OrderByDescending(a => a.Data);
        }

        public IEnumerable<EmailMessageTran> GetEmailsInBox(Email emailConfig)
        {
            IList<EmailMessageTran> messages = new List<EmailMessageTran>();
            try
            {
                _logger.RegistrarLog
              (
                    Informacao: $@"3º Passo | EmailRepository, Iniciando GetEmailsInBox"
                  , Repositorio_Metodo: $@"EmailRepository/GetEmailsInBox"
                  , ObjetoJson: JsonConvert.SerializeObject(emailConfig)
              );

                using (var client = new ImapClient())
                {
                    client.Connect(emailConfig.Smtp, emailConfig.Port, emailConfig.EnableSsl);

                    client.Authenticate(emailConfig.EmailAdress, emailConfig.Password);

                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);
                    var results = inbox.Search(SearchOptions.All, SearchQuery.Not(SearchQuery.Seen));

                    for (int i = results.UniqueIds.Count; i > 0; i--)
                    {
                        try
                        {
                            MimeMessage m = inbox.GetMessage(i);

                            messages.Add(new EmailMessageTran()
                            {
                                Order = i,
                                Id = m.MessageId,
                                Data = Convert.ToDateTime(m.Date.DateTime),
                                De = !string.IsNullOrEmpty(m.From.Select(a => a.Name).FirstOrDefault()) ? m.From.Select(a => a.Name).FirstOrDefault() : "sem nome",
                                Horario = Convert.ToDateTime(m.Date.DateTime).TimeOfDay.ToString(),
                                Subject = m.Subject,
                                ExistemAnexos = m.Attachments.Any() ? true : false,
                                TerapeutaId = emailConfig.TerapeutaId,
                                Titulo = m.Subject,
                                BodyText = !string.IsNullOrEmpty(m.TextBody) ? m.TextBody : "",
                                BodyHtml = !string.IsNullOrEmpty(m.HtmlBody) ? m.HtmlBody : "",
                                Para = m.To != null ? m.To.Select(a => a.Name).FirstOrDefault() : "",
                                Anexos = m.Attachments.ToList(),
                                PrimeiraLetraDoNome = (!string.IsNullOrEmpty(m.From.Select(a => a.Name).FirstOrDefault())) ? Convert.ToChar(m.From.Select(a => a.Name).FirstOrDefault().Substring(0, 1)) : '.'
                            });
                        }
                        catch (Exception e)
                        {
                            continue;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                _logger.RegistrarLog(
                      Informacao: $@"3º Passo | EmailRepository, Entity GetEmailsInBox"
                    , Repositorio_Metodo: $@"EmailRepository/GetEmailsInBox"
                    , Erro: e.Message
                    , Excecao: e.ToString());
            }

            return messages.OrderByDescending(a => a.Data);
        }

        public int GetQtdEmails(Email emailConfig)
        {
            _logger.RegistrarLog
                (
                      Informacao: $@"3º Passo | EmailRepository, Iniciando GetEmailsInBox"
                    , Repositorio_Metodo: $@"EmailRepository/GetEmailsInBox"
                    , ObjetoJson: JsonConvert.SerializeObject(emailConfig)
                );

            int contadorDeMensagens = 0;

            try
            {
                using (var client = new ImapClient())
                {
                    client.Connect(emailConfig.Smtp, emailConfig.Port, emailConfig.EnableSsl);

                    client.Authenticate(emailConfig.EmailAdress, emailConfig.Password);

                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);
                    var results = inbox.Search(SearchOptions.All, SearchQuery.Not(SearchQuery.Seen));

                    contadorDeMensagens = results.UniqueIds.Count;

                    client.Disconnect(true);

                }
            }
            catch (Exception e)
            {
                _logger.RegistrarLog(
                  Informacao: $@"3º Passo | EmailRepository, Iniciando GetEmailsInBox"
                , Repositorio_Metodo: $@"EmailRepository/GetEmailsInBox"
                , Erro: e.Message
                , Excecao: e.ToString());
            }
            return contadorDeMensagens;
        }

        public int GetQtdEmailsNaoLidos(Email emailConfig)
        {
            return _DbSetInfoMail.Where(a => a.TerapeutaId == emailConfig.TerapeutaId && a.Lido == false).Select(a => a).ToList().Count();
        }

        public void DeleteMessage(Email emailConfig, string messageId)
        {
            _logger.RegistrarLog
                (
                      Informacao: $@"3º Passo | EmailRepository, Iniciando DeleteMessage"
                    , Repositorio_Metodo: $@"EmailRepository/DeleteMessage"
                    , ObjetoJson: JsonConvert.SerializeObject(emailConfig)
                );
            try
            {
                using (var client = new ImapClient())
                {
                    client.Connect(emailConfig.Smtp, emailConfig.Port, emailConfig.EnableSsl);

                    client.Authenticate(emailConfig.EmailAdress, emailConfig.Password);

                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);

                    inbox.AddFlags(UniqueId.Parse(messageId), MessageFlags.Deleted, true);

                    client.Disconnect(true);
                }
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                 Informacao: $@"3º Passo | EmailRepository, Iniciando DeleteMessage"
               , Repositorio_Metodo: $@"EmailRepository/DeleteMessage"
               , Erro: e.Message
               , Excecao: e.ToString());
            }

            _logger.RegistrarLog
              (
                      Informacao: $@"3º Passo | EmailRepository, Iniciando DeleteMessage"
                    , Repositorio_Metodo: $@"EmailRepository/DeleteMessage"
              );
        }

        public void SendMessage(Email emailConfig)
        {
            _logger.RegistrarLog
               (
                     Informacao: $@"3º Passo | EmailRepository, Iniciando SendMessage"
                   , Repositorio_Metodo: $@"EmailRepository/SendMessage"
                   , ObjetoJson: JsonConvert.SerializeObject(emailConfig)
               );
            try
            {
                MimeMessage msg = new MimeMessage();

                msg.To.Add(new MailboxAddress("", emailConfig.To));
                msg.From.Add(new MailboxAddress("", emailConfig.EmailAdress));
                msg.Subject = emailConfig.Subject;

                if (emailConfig.IsBodyHtml)
                {
                    msg.Body = new TextPart("html")
                    {
                        Text = emailConfig.Body
                    };
                }
                else
                {
                    msg.Body = new TextPart("plain")
                    {
                        Text = emailConfig.Body
                    };
                }

                using (var smtp = new MailKit.Net.Smtp.SmtpClient())
                {
                    smtp.Connect(emailConfig.Smtp, emailConfig.Port, SecureSocketOptions.StartTls);
                    smtp.Authenticate(emailConfig.EmailAdress, emailConfig.Password);
                    smtp.Send(msg);
                    smtp.Disconnect(true);
                }

                //foreach (IFormFile anexo in emailConfig.GetAnexos())
                //{
                //    MemoryStream MS = new MemoryStream(new byte[anexo.Length]);
                //    Attachment arquivo = new Attachment(MS, anexo.FileName);
                //    msg.Attachments. Add(arquivo);
                //}
            }
            catch (Exception e)
            {
                _logger.RegistrarLog(
                 Informacao: $@"3º Passo | EmailRepository, Iniciando SendMessage"
               , Repositorio_Metodo: $@"EmailRepository/SendMessage"
               , Erro: e.Message
               , Excecao: e.ToString());
            }

            _logger.RegistrarLog
              (
                    Informacao: $@"3º Passo | EmailRepository, Iniciando SendMessage"
                  , Repositorio_Metodo: $@"EmailRepository/SendMessage"
              );
        }

        public InfoMail GetInfoMail(Guid idTerapeuta, string idEmail)
        {
            return _DbSetInfoMail.Where(a => a.TerapeutaId == idTerapeuta && a.Id.Equals(idEmail)).Select(a => a).FirstOrDefault();
        }

        public InfoMail GetInfoMailById(string idEmail)
        {
            return _DbSetInfoMail.Where(a => a.Id.Equals(idEmail)).Select(a => a).FirstOrDefault();
        }

        public void InsertInfoMail(InfoMail infoMail)
        {
            _DbSetInfoMail.Add(infoMail);
            _DbInfoMail.SaveChanges();
        }

        public void UpdateInfoMail(InfoMail infoMail)
        {
            _DbSetInfoMail.Update(infoMail);
            _DbInfoMail.SaveChanges();

        }

        public IEnumerable<InfoMail> GetAllInfoMail(Guid idTerapeuta)
        {
            return _DbSetInfoMail.Where(a => a.TerapeutaId == idTerapeuta).Select(a => a).ToList();
        }
    }
}
