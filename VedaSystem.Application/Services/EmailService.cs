using AutoMapper;
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

        public EmailService
            (
                  IMapper mapper
                , IEmailRepository emailRepository
                , IPrescricaoRepository prescricaoRepository
                , ITratamentoRepository tratamentoRepository
                , ILogService logService
            )
            : base(mapper, emailRepository, logService)
        {
            _emailRepository = emailRepository;
            _prescricaoRepository = prescricaoRepository;
            _tratamentoRepository = tratamentoRepository;
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

        public Email GetDadosDeEmailPorTerapeuta(Guid IdTerapeuta)
        {
            return _emailRepository.GetPorIdTerapeuta(IdTerapeuta);
        }

        public IEnumerable<Message> GetEmailPorRemetente(Email emailConfig, string nomeRemetente)
        {
            return _emailRepository.GetEmailPorRemetente(emailConfig, nomeRemetente);
        }

        public IEnumerable<Message> GetEmailPorTitulo(Email emailConfig, string tituloDoEmail)
        {
            return _emailRepository.GetEmailPorTitulo(emailConfig, tituloDoEmail);
        }

        public IEnumerable<EmailMessageViewModel> GetEmailsInBox(Email emailConfig)
        {
            IEnumerable<Message> messages = _emailRepository.GetEmailsInBox(emailConfig);
            IList<EmailMessageViewModel> emailMessages = new List<EmailMessageViewModel>();

            for (var i = 0; i < messages.ToList().Count; i++)
            {
                Message m = messages.ToList()[i];

                InfoMail infoMail = _emailRepository.GetInfoMail(emailConfig.TerapeutaId, m.Headers.MessageId);

                emailMessages.Add(new EmailMessageViewModel()
                {
                    Id = m.Headers.MessageId,
                    Subject = m.Headers.Subject,
                    Data = Convert.ToDateTime(m.Headers.DateSent),
                    De = m.Headers.From.DisplayName,
                    Horario = Convert.ToDateTime(m.Headers.DateSent).TimeOfDay.ToString(),
                    PrimeiraLetraDoNome = Convert.ToChar(m.Headers.From.DisplayName.Substring(0, 1)),
                    CorRadius = (CorRadius)new Random().Next(1, 8),
                    ExistemAnexos = m.FindAllAttachments().Count > 0 ? true : false,
                    Lido = infoMail != null ? infoMail.Lido : false,
                    TerapeutaId = emailConfig.TerapeutaId,
                    Selected = false,
                    Titulo = m.Headers.Subject,
                    BodyText = m.FindFirstPlainTextVersion().GetBodyAsText(),
                    BodyHtml = m.FindFirstHtmlVersion().GetBodyAsText(),
                    Grupo = infoMail.Grupo,
                    Tag = infoMail.Tag,
                    Para = m.Headers.To.Select(a => a.DisplayName).FirstOrDefault(),
                    Anexos = m.FindAllAttachments(),
                    Benchmark = infoMail.Benchmark
                });
            }
            EqualizarBaseInfosEmails(emailMessages);

            return emailMessages;
        }

        public void DeleteMessage(Email emailConfig, int messageNumber)
        {
            _emailRepository.DeleteMessage(emailConfig, messageNumber);
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
                    InsertInfoMail(infoMail);
                }
                else
                {
                    UpdateInfoMail(infoMail);
                }
            }
        }

        public void InsertInfoMail(InfoMail infoMail)
        {
            _emailRepository.InsertInfoMail(infoMail);
        }

        public void UpdateInfoMail(InfoMail infoMail)
        {
            _emailRepository.UpdateInfoMail(infoMail);
        }
    }
}
