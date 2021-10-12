using AutoMapper;
using Microsoft.AspNetCore.Http;
using MimeKit;
using Newtonsoft.Json;
using OpenPop.Mime;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.Utils;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Enums;
using VedaSystem.Domain.Interfaces;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.Services
{
    public class EmailService : Service<Email, EmailViewModel>, IEmailService
    {
        private readonly IEmailRepository _emailRepository;
        private readonly IPrescricaoRepository _prescricaoRepository;
        private readonly ITratamentoRepository _tratamentoRepository;
        private readonly ITerapeutaRepository _terapeutaRepository;


        public EmailService
            (
                  IMapper mapper
                , IEmailRepository emailRepository
                , IPrescricaoRepository prescricaoRepository
                , ITratamentoRepository tratamentoRepository
                , ITerapeutaRepository terapeutaRepository
                , ILogService logService
            )
            : base(mapper, emailRepository, logService)
        {
            _emailRepository = emailRepository;
            _prescricaoRepository = prescricaoRepository;
            _tratamentoRepository = tratamentoRepository;
            _terapeutaRepository = terapeutaRepository;
        }

        public bool EnviarEmail(Email email, Guid IdPrescricao)
        {
            Prescricao prescricao = _prescricaoRepository.GetById(IdPrescricao);

            IEnumerable<Tratamento> tratamentos = _tratamentoRepository.GetPorIdPrescricao(prescricao.Id);

            var imagem = System.Drawing.Image.FromStream(new MemoryStream(Convert.FromBase64String(Convert.ToBase64String(prescricao.Terapeuta.Logo))));

            email = TratarObjeto<Email>.MesclarObjeto(email, _emailRepository.GetPorIdTerapeuta(prescricao.Terapeuta.Id));

            imagem.Save($@"C:\Projetos\VedaSystem\VedaSystem\VedaSystem.Application\Email\logo-{prescricao.Terapeuta.Id}.jpeg", ImageFormat.Jpeg);

            try
            {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(email.EmailAdress);
                mail.To.Add(prescricao.Paciente.Email);
                mail.Subject = "Prescrição: " + prescricao.Paciente.Nome;

                StringBuilder corpoDoEmail = new StringBuilder();

                corpoDoEmail.AppendLine($@"<!DOCTYPE html>
                                            <html lang='pt - br'>
                                              <body> ");
                corpoDoEmail.AppendLine($@"<img src = 'logo-{prescricao.Terapeuta.Id}.jpeg' style ='max-width:200px; max-height:200px;' />");
                corpoDoEmail.AppendLine($@"</br>");
                corpoDoEmail.AppendLine($@"<h3>{prescricao.Terapeuta.NomeCompleto}</h3></br>");
                corpoDoEmail.AppendLine($@"<h5>{prescricao.Terapeuta.Site}</h5></br>");
                corpoDoEmail.AppendLine($@"<h5>{prescricao.Terapeuta.Telefone}</h5></br>");

                corpoDoEmail.AppendLine($@"<table class='table'>
                                                <tr>
                                                    <th>
                                                        Ordem
                                                    </th>
                                                    <th>
                                                        Descrição do Tratamento
                                                    </th>
                                                    <th>
                                                        Medicamento
                                                    </th>
                                                </tr>");

                foreach (var tratamento in tratamentos)
                {
                    corpoDoEmail.AppendLine($@"<tr>
                                                <td>
                                                    {tratamento.Ordem}
                                                </td>
                                                <td>
                                                    {tratamento.DescricaoTratamento}
                                                </td>
                                                <td>
                                                    {tratamento.Medicamento}
                                                </td>
                                            </tr> ");
                }

                corpoDoEmail.AppendLine($@"</table>
                                            </body>
                                           </html>");

                string arquivo = $@"C:\Projetos\VedaSystem\VedaSystem\VedaSystem.Application\Email\logo-{prescricao.Terapeuta.Id}.jpeg";

                Attachment attachment = new Attachment(arquivo);

                mail.Attachments.Add(attachment);
                mail.Body = corpoDoEmail.ToString();
                mail.IsBodyHtml = email.IsBodyHtml;
                var ms = MemoryFile.ArquivoTemporario(corpoDoEmail.ToString());
                mail.Attachments.Add(new Attachment(ms, "prescricao.pdf", "application/pdf"));

                using (var smtp = new SmtpClient(email.Smtp))
                {
                    smtp.EnableSsl = email.EnableSsl;
                    smtp.Port = email.Port;
                    smtp.DeliveryMethod = email.DeliveryMethod;
                    smtp.UseDefaultCredentials = email.UseDefaultCredentials;
                    smtp.Credentials = new NetworkCredential(email.EmailAdress, email.Password);

                    smtp.Send(mail);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public Email GetDadosDeEmailPorTerapeuta(Guid? IdTerapeuta)
        {
            return _emailRepository.GetPorIdTerapeuta(IdTerapeuta);
        }
        public IEnumerable<MimeMessage> GetEmailPorRemetente(Email emailConfig, string nomeRemetente)
        {
            return _emailRepository.GetEmailPorRemetente(emailConfig, nomeRemetente);
        }
        public IEnumerable<MimeMessage> GetEmailPorTitulo(Email emailConfig, string tituloDoEmail)
        {
            return _emailRepository.GetEmailPorTitulo(emailConfig, tituloDoEmail);
        }
        public IEnumerable<EmailMessageViewModel> GetEmailsInBox(Email emailConfig, int de = 1, int ate = 10)
        {
            IList<EmailMessageViewModel> emailMessages = new List<EmailMessageViewModel>();
            IEnumerable<EmailMessageTran> messages;

            if (_emailRepository.GetAllInfoMail(emailConfig.TerapeutaId).ToList().Count > 0)
            {
                messages = _emailRepository.GetEmailsInBox(emailConfig, de, ate);
            }
            else
            {
                messages = _emailRepository.GetEmailsInBox(emailConfig);
            }

            foreach (EmailMessageTran m in messages.ToList())
            {
                try
                {
                    InfoMail infoMail = _emailRepository.GetInfoMail(emailConfig.TerapeutaId, m.Id);

                    emailMessages.Add(new EmailMessageViewModel()
                    {
                        Id = m.Id,
                        Order = m.Order,
                        Subject = m.Subject,
                        Data = m.Data,
                        De = m.De,
                        Horario = m.Horario,
                        PrimeiraLetraDoNome = m.PrimeiraLetraDoNome,
                        CorRadius = (CorRadius)new Random().Next(1, 8),
                        ExistemAnexos = m.ExistemAnexos,
                        Lido = infoMail != null ? infoMail.Lido : false,
                        TerapeutaId = m.TerapeutaId,
                        Selected = false,
                        Titulo = m.Titulo,
                        BodyText = m.BodyText,
                        BodyHtml = m.BodyHtml,
                        Grupo = infoMail != null ? infoMail.Grupo : (Grupo)4,
                        Tag = infoMail != null ? infoMail.Tag : (Tag)3,
                        Para = m.Para,
                        Anexos = m.Anexos,
                        Benchmark = infoMail != null ? infoMail.Benchmark : false,
                        Enviado = infoMail != null ? infoMail.Enviado : false,
                        Excluido = infoMail != null ? infoMail.Excluido : false,
                        Rascunho = infoMail != null ? infoMail.Rascunho : false,
                        To = infoMail != null ? infoMail.To : ""
                    });
                }
                catch (Exception e)
                {
                    continue;
                }
            }
            EqualizarBaseInfosEmails(emailMessages);

            if (emailMessages.Count > 10)
            {
                return emailMessages.Take(10);
            }
            else
            {
                return emailMessages;
            }
        }
        public IEnumerable<EmailMessageViewModel> GetEmailsInBox(Email emailConfig, string tipoMensagem, int de = 1, int ate = 10)
        {
            List<EmailMessageViewModel> emailMessages = new List<EmailMessageViewModel>();
            IEnumerable<EmailMessageTran> messages;

            messages = _emailRepository.GetEmailsInBox(emailConfig);
            try
            {
                foreach (EmailMessageTran m in messages.ToList())
                {
                    try
                    {
                        InfoMail infoMail = _emailRepository.GetInfoMail(emailConfig.TerapeutaId, m.Id);

                        emailMessages.Add(new EmailMessageViewModel()
                        {
                            Id = m.Id,
                            Order = m.Order,
                            Subject = m.Subject,
                            Data = m.Data,
                            De = m.De,
                            Horario = m.Horario,
                            PrimeiraLetraDoNome = m.PrimeiraLetraDoNome,
                            CorRadius = (CorRadius)new Random().Next(1, 8),
                            ExistemAnexos = m.ExistemAnexos,
                            Lido = infoMail != null ? infoMail.Lido : false,
                            TerapeutaId = m.TerapeutaId,
                            Selected = false,
                            Titulo = m.Titulo,
                            BodyText = m.BodyText,
                            BodyHtml = m.BodyHtml,
                            Grupo = infoMail != null ? infoMail.Grupo : (Grupo)4,
                            Tag = infoMail != null ? infoMail.Tag : (Tag)3,
                            Para = m.Para,
                            Anexos = m.Anexos,
                            Benchmark = infoMail != null ? infoMail.Benchmark : false,
                            Enviado = infoMail != null ? infoMail.Enviado : false,
                            Excluido = infoMail != null ? infoMail.Excluido : false,
                            Rascunho = infoMail != null ? infoMail.Rascunho : false,
                            To = infoMail != null ? infoMail.To : ""
                        });
                    }
                    catch (Exception e)
                    {
                        continue;
                    }
                }

                EqualizarBaseInfosEmails(emailMessages);

                switch (tipoMensagem)
                {
                    case "favoritos":
                        emailMessages = emailMessages.Where(a => a.Benchmark == true).Select(a => a).ToList();
                        emailMessages = emailMessages.Count() > (ate - 1) ? emailMessages.GetRange(de - 1, ate - 1) : emailMessages;

                        break;
                    case "enviados":
                        emailMessages = emailMessages.Where(a => a.Enviado == true).Select(a => a).ToList();
                        emailMessages = emailMessages.Count() > (ate - 1) ? emailMessages.GetRange(de - 1, ate - 1) : emailMessages;
                        break;
                    case "rascunhos":
                        emailMessages = emailMessages.Where(a => a.Rascunho == true).Select(a => a).ToList();
                        emailMessages = emailMessages.Count() > (ate - 1) ? emailMessages.GetRange(de - 1, ate - 1) : emailMessages;
                        break;
                    case "lixeira":
                        emailMessages = emailMessages.Where(a => a.Excluido == true).Select(a => a).ToList();
                        emailMessages = emailMessages.Count() > (ate - 1) ? emailMessages.GetRange(de - 1, ate - 1) : emailMessages;
                        break;
                }
            }
            catch(Exception e)
            {
                throw e;
            }

            return emailMessages;
        }
        public void DeleteMessage(Email emailConfig, string messageId)
        {
            _emailRepository.DeleteMessage(emailConfig, messageId);
        }
        public void SendMessage(Email emailConfig)
        {
            _emailRepository.SendMessage(emailConfig);
        }
        public void EqualizarBaseInfosEmails(IList<EmailMessageViewModel> emailMessages)
        {
            foreach (var email in emailMessages)
            {
                InfoMail infoMail = _emailRepository.GetInfoMail(email.TerapeutaId, email.Id);

                if (infoMail == null)
                {
                    infoMail = new InfoMail()
                    {
                        Id = email.Id,
                        Order = email.Order,
                        TerapeutaId = email.TerapeutaId,
                        Subject = email.Subject,
                        Body = email.BodyHtml,
                        To = email.Para,
                        Grupo = email.Grupo,
                        Lido = email.Lido,
                        Benchmark = email.Benchmark,
                        Tag = email.Tag,
                        Enviado = email.Enviado,
                        Excluido = email.Excluido,
                        Rascunho = email.Rascunho,
                        DataDeEnvio = email.Data
                    };
                    InsertInfoMail(infoMail);
                }
                else
                {
                    UpdateInfoMail(infoMail);
                }
            }
        }
        public InfoMail GetInfoMailById(Guid terapeutaId, string messageId)
        {
            return _emailRepository.GetInfoMail(terapeutaId, messageId);
        }
        public void InsertInfoMail(InfoMail infoMail)
        {
            _emailRepository.InsertInfoMail(infoMail);
        }
        public void UpdateInfoMail(InfoMail infoMail)
        {
            _emailRepository.UpdateInfoMail(infoMail);
        }
        public int GetQtdEmails(Email emailConfig)
        {
            return _emailRepository.GetQtdEmails(emailConfig);
        }
        public int GetQtdEmailsNaoLidos(Email emailConfig)
        {
            return _emailRepository.GetQtdEmails(emailConfig);
        }
        public override void Add(EmailViewModel entity)
        {
            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("Add").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Add").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(entity)
                );

            try
            {
                _model = _mapper.Map<Email>(entity);
            }
            catch (Exception e)
            {
                _log.RegistrarLog
                 (
                     Informacao: $@"2º Passo | {this.GetType().Name}, AutoMapper {this.GetType().GetMethod("Add").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Add").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(_model)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }

            _model.TerapeutaId = (Guid)_terapeutaRepository.GetTerapeutaPorNomeDeUsuario(new HttpContextAccessor().HttpContext.User.Identity.Name).Id;

            _repository.Add(_model);

            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("Add").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Add").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(_model)
                );
        }

        public EmailMessageViewModel GetMessageById(Email emailConfig, string messageId)
        {
            MimeMessage m = _emailRepository.GetMessageById(emailConfig, messageId);
            InfoMail infoMail = _emailRepository.GetInfoMail(emailConfig.TerapeutaId, m.MessageId);
            EmailMessageViewModel message = null;
            try
            {
                message = new EmailMessageViewModel()
                {
                    Id = m.MessageId,
                    Subject = m.Subject,
                    Data = Convert.ToDateTime(m.Date.DateTime),
                    De = !string.IsNullOrEmpty(m.From.Select(a => a.Name).FirstOrDefault()) ? m.From.Select(a => a.Name).FirstOrDefault() : "sem nome",
                    Horario = Convert.ToDateTime(m.Date.DateTime).TimeOfDay.ToString(),
                    PrimeiraLetraDoNome = (!string.IsNullOrEmpty(m.From.Select(a => a.Name).FirstOrDefault())) ? Convert.ToChar(m.From.Select(a => a.Name).FirstOrDefault().Substring(0, 1)) : '.',
                    CorRadius = (CorRadius)new Random().Next(1, 8),
                    ExistemAnexos = m.Attachments.Count() > 0 ? true : false,
                    Lido = infoMail != null ? infoMail.Lido : false,
                    TerapeutaId = emailConfig.TerapeutaId,
                    Selected = false,
                    Titulo = m.Subject,
                    BodyText = !string.IsNullOrEmpty(m.TextBody) ? m.TextBody : "",
                    BodyHtml = !string.IsNullOrEmpty(m.HtmlBody) ? m.HtmlBody : "",
                    Grupo = infoMail != null ? infoMail.Grupo : (Grupo)4,
                    Tag = infoMail != null ? infoMail.Tag : (Tag)3,
                    Para = m.To != null ? m.To.Select(a => a.Name).FirstOrDefault() : "",
                    Anexos = m.Attachments.ToList(),
                    Benchmark = infoMail != null ? infoMail.Benchmark : false,
                    Enviado = infoMail != null ? infoMail.Enviado : false,
                    Excluido = infoMail != null ? infoMail.Excluido : false,
                    Rascunho = infoMail != null ? infoMail.Rascunho : false,
                    To = infoMail != null ? infoMail.To : ""
                };
            }catch(Exception e)
            {

            }

            return message;
        }
    }
}
