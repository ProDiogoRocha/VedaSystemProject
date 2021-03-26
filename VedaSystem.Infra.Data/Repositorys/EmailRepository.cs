using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OpenPop.Mime;
using OpenPop.Pop3;
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


        public EmailRepository(EmailContext context, InfoMailContext infoMailContext, ILogRepository logger = null) : base(context, logger)
        {
            Db = context;
            DbSet = Db.Set<Email>();
            _DbInfoMail = infoMailContext;
            _DbSetInfoMail = _DbInfoMail.Set<InfoMail>();
        }
        public Email GetPorIdTerapeuta(Guid? IdTerapeuta)
        {
            Email email = new Email();

            _log.RegistrarLog
                 (
                       Informacao: $@"3º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("GetPorIdTerapeuta").Name}"
                     , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetPorIdTerapeuta").Name}"
                     , ObjetoJson: JsonConvert.SerializeObject(IdTerapeuta)
                 );
            try
            {
                email = DbSet.Where(e => e.Terapeuta.Id == IdTerapeuta).FirstOrDefault();
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                   Informacao: $@"3º Passo | {this.GetType().Name}, Entity {this.GetType().GetMethod("GetPorIdTerapeuta").Name}"
                 , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetPorIdTerapeuta").Name}"
                 , ObjetoJson: JsonConvert.SerializeObject(IdTerapeuta)
                 , Erro: e.Message
                 , Excecao: e.ToString());
            }

            _log.RegistrarLog
               (
                     Informacao: $@"3º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("GetPorIdTerapeuta").Name}"
                   , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetPorIdTerapeuta").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(email)
               );
            return email;
        }

        public IEnumerable<Message> GetEmailPorRemetente(Email emailConfig, string nomeRemetente)
        {
            IList<Message> mensagens = new List<Message>();

            _log.RegistrarLog
                (
                      Informacao: $@"3º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("GetEmailsInBox").Name}"
                    , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetEmailsInBox").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(emailConfig)
                );

            try
            {
                using (Pop3Client client = new Pop3Client())
                {
                    client.Connect(emailConfig.Smtp, emailConfig.Port, emailConfig.EnableSsl);

                    client.Authenticate(emailConfig.EmailAdress, emailConfig.Password, AuthenticationMethod.UsernameAndPassword);

                    int contadorDeMensagens = client.GetMessageCount();

                    mensagens = new List<Message>(contadorDeMensagens);

                    for (int i = contadorDeMensagens; i > 0; i--)
                    {
                        mensagens.Add(client.GetMessage(i));
                    }
                }
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                  Informacao: $@"3º Passo | {this.GetType().Name}, Entity {this.GetType().GetMethod("GetEmailsInBox").Name}"
                , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetEmailsInBox").Name}"
                , Erro: e.Message
                , Excecao: e.ToString());
            }

            _log.RegistrarLog
              (
                    Informacao: $@"3º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("GetPorIdTerapeuta").Name}"
                  , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetPorIdTerapeuta").Name}"
                  , ObjetoJson: JsonConvert.SerializeObject(mensagens)
              );

            return mensagens.Where(a => a.Headers.To.Select(t => t.DisplayName).Contains(nomeRemetente)).Select(a => a).ToList();
        }

        public IEnumerable<Message> GetEmailPorTitulo(Email emailConfig, string tituloDoEmail)
        {
            IList<Message> mensagens = new List<Message>();

            _log.RegistrarLog
                (
                      Informacao: $@"3º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("GetEmailsInBox").Name}"
                    , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetEmailsInBox").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(emailConfig)
                );

            try
            {
                using (Pop3Client client = new Pop3Client())
                {
                    client.Connect(emailConfig.Smtp, emailConfig.Port, emailConfig.EnableSsl);

                    client.Authenticate(emailConfig.EmailAdress, emailConfig.Password, AuthenticationMethod.UsernameAndPassword);

                    int contadorDeMensagens = client.GetMessageCount();

                    mensagens = new List<Message>(contadorDeMensagens);

                    for (int i = contadorDeMensagens; i > 0; i--)
                    {
                        mensagens.Add(client.GetMessage(i));
                    }
                }
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                  Informacao: $@"3º Passo | {this.GetType().Name}, Entity {this.GetType().GetMethod("GetEmailsInBox").Name}"
                , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetEmailsInBox").Name}"
                , Erro: e.Message
                , Excecao: e.ToString());
            }

            _log.RegistrarLog
              (
                    Informacao: $@"3º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("GetPorIdTerapeuta").Name}"
                  , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetPorIdTerapeuta").Name}"
                  , ObjetoJson: JsonConvert.SerializeObject(mensagens)
              );

            return mensagens.Where(a => a.Headers.Subject.Contains(tituloDoEmail)).Select(a => a).ToList();
        }

        public IEnumerable<Message> GetEmailsInBox(Email emailConfig)
        {
            IList<Message> mensagens = new List<Message>();

            _log.RegistrarLog
                (
                      Informacao: $@"3º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("GetEmailsInBox").Name}"
                    , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetEmailsInBox").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(emailConfig)
                );

            try
            {
                using (Pop3Client client = new Pop3Client())
                {
                    client.Connect(emailConfig.Smtp, emailConfig.Port, emailConfig.EnableSsl);

                    client.Authenticate(emailConfig.EmailAdress, emailConfig.Password, AuthenticationMethod.UsernameAndPassword);

                    int contadorDeMensagens = client.GetMessageCount();

                    mensagens = new List<Message>(contadorDeMensagens);

                    for (int i = contadorDeMensagens; i > 0; i--)
                    {
                        mensagens.Add(client.GetMessage(i));
                    }
                }
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                  Informacao: $@"3º Passo | {this.GetType().Name}, Entity {this.GetType().GetMethod("GetEmailsInBox").Name}"
                , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetEmailsInBox").Name}"
                , Erro: e.Message
                , Excecao: e.ToString());
            }

            _log.RegistrarLog
              (
                    Informacao: $@"3º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("GetPorIdTerapeuta").Name}"
                  , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetPorIdTerapeuta").Name}"
                  , ObjetoJson: JsonConvert.SerializeObject(mensagens)
              );

            return mensagens;
        }

        public void DeleteMessage(Email emailConfig, int messageNumber)
        {
            _log.RegistrarLog
                (
                      Informacao: $@"3º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("DeleteMessage").Name}"
                    , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("DeleteMessage").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(emailConfig)
                );
            try
            {
                using (Pop3Client client = new Pop3Client())
                {
                    client.Connect(emailConfig.Smtp, emailConfig.Port, emailConfig.EnableSsl);

                    client.Authenticate(emailConfig.EmailAdress, emailConfig.Password, AuthenticationMethod.UsernameAndPassword);

                    client.DeleteMessage(messageNumber);
                }
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                 Informacao: $@"3º Passo | {this.GetType().Name}, Entity {this.GetType().GetMethod("DeleteMessage").Name}"
               , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("DeleteMessage").Name}"
               , Erro: e.Message
               , Excecao: e.ToString());
            }

            _log.RegistrarLog
              (
                    Informacao: $@"3º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("DeleteMessage").Name}"
                  , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("DeleteMessage").Name}"
              );
        }

        public void SendMessage(Email emailConfig)
        {
            _log.RegistrarLog
               (
                     Informacao: $@"3º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("SendMessage").Name}"
                   , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("SendMessage").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(emailConfig)
               );
            try
            {
                SmtpClient c = new SmtpClient(emailConfig.Smtp, emailConfig.Port);
                MailAddress add = new MailAddress(emailConfig.To);
                MailMessage msg = new MailMessage();

                foreach (IFormFile anexo in emailConfig.GetAnexos())
                {
                    MemoryStream MS = new MemoryStream(new byte[anexo.Length]);
                    Attachment arquivo = new Attachment(MS, anexo.FileName);
                    msg.Attachments.Add(arquivo);
                }

                msg.To.Add(add);
                msg.From = new MailAddress(emailConfig.EmailAdress);
                msg.IsBodyHtml = true;
                msg.Subject = emailConfig.Subject;
                msg.Body = emailConfig.Body;
                c.Credentials = new System.Net.NetworkCredential(emailConfig.EmailAdress, emailConfig.Password);
                c.EnableSsl = emailConfig.EnableSsl;
                c.DeliveryMethod = emailConfig.DeliveryMethod;
                c.Send(msg);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                 Informacao: $@"3º Passo | {this.GetType().Name}, Entity {this.GetType().GetMethod("SendMessage").Name}"
               , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("SendMessage").Name}"
               , Erro: e.Message
               , Excecao: e.ToString());
            }

            _log.RegistrarLog
              (
                    Informacao: $@"3º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("SendMessage").Name}"
                  , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("SendMessage").Name}"
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
        }

        public void UpdateInfoMail(InfoMail infoMail)
        {
            _DbSetInfoMail.Update(infoMail);
        }

        public IEnumerable<InfoMail> GetAllInfoMail(Guid idTerapeuta)
        {
            return _DbSetInfoMail.Where(a => a.TerapeutaId == idTerapeuta).Select(a => a).ToList();
        }
    }
}
