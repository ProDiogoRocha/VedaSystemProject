using AutoMapper;
using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Interfaces;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.Services
{
    public class TradutorService : Service<Tradutor, TradutorViewModel>, ITradutorService
    {
        private readonly IMapper _mapper;
        private readonly ITradutorRepository _repository;

        public TradutorService(IMapper mapper, ITradutorRepository repository, ILogService logger) : base(mapper, repository, logger)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public override IEnumerable<TradutorViewModel> GetAll()
        {
            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("GetAll").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetAll").Name}"
                );

            IEnumerable<Tradutor> tradutores = _repository.GetAll();
            IEnumerable<TradutorViewModel> tradutoresViewModel = new List<TradutorViewModel>();

            foreach (var t in tradutores)
            {
                t.Texto = t.Texto.Length > 20 ? t.Texto.Substring(0, 20) + "..." : t.Texto;
            }

            try
            {
                tradutoresViewModel = _mapper.Map<IEnumerable<TradutorViewModel>>(tradutores);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"2º Passo | {this.GetType().Name}, AutoMapper {this.GetType().GetMethod("GetAll").Name}"
                   , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetAll").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(tradutores)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }

            _log.RegistrarLog
               (
                     Informacao: $@"2º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("GetAll").Name}"
                   , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetAll").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(tradutoresViewModel)
               );

            return tradutoresViewModel;
        }

        public void CarregarPagina()
        {
            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("CarregarPagina").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("CarregarPagina").Name}"
                );

            _repository.LoadPage(TimeSpan.FromSeconds(8));

            _log.RegistrarLog
               (
                     Informacao: $@"2º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("CarregarPagina").Name}"
                   , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("CarregarPagina").Name}"
               );
        }

        public void Fechar()
        {
            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("Fechar").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Fechar").Name}"
                );

            _repository.CloseBrowser();

            _log.RegistrarLog
              (
                    Informacao: $@"2º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("Fechar").Name}"
                  , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Fechar").Name}"
              );
        }

        public IEnumerable<TradutorViewModel> GetPorTexto(string texto)
        {
            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("GetPorTexto").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetPorTexto").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(texto)
                );

            IEnumerable<Tradutor> tradutors = new List<Tradutor>();
            IEnumerable<TradutorViewModel> tradutorViewModels = new List<TradutorViewModel>();

            tradutors = _repository.GetPorTexto(texto);
            try
            {
                tradutorViewModels = _mapper.Map<IEnumerable<TradutorViewModel>>(tradutors);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"2º Passo | {this.GetType().Name}, AutoMapper {this.GetType().GetMethod("GetPorTexto").Name}"
                   , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetPorTexto").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(tradutors)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }

            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("GetPorTexto").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetPorTexto").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(tradutorViewModels)
                );

            return tradutorViewModels;
        }

        public string GetTextoEmPortugues(string textoIngles)
        {
            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("GetTextoEmPortugues").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetTextoEmPortugues").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(textoIngles)
                );
            var texto = "";
            try
            {
               
                var timeSleepMilliSeconds = 0;
                if (textoIngles.Length <= 3900)
                {
                    timeSleepMilliSeconds = textoIngles.Length > 50 ? ((textoIngles.Length * 250) / 100) : 2000;
                    Thread.Sleep(timeSleepMilliSeconds);
                    foreach (var t in _repository.GetTexts(By.ClassName("JLqJ4b"), By.TagName("span")))
                    {
                        texto = texto + t.Text + " ";
                    }
                }
            }catch(Exception e)
            {
                throw e;
            }

            _log.RegistrarLog
               (
                     Informacao: $@"2º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("GetTextoEmPortugues").Name}"
                   , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetTextoEmPortugues").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(texto)
               );

            return texto;
        }

        public void PreencherTextoEmIngles(string texto)
        {
            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("PreencherTextoEmIngles").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("PreencherTextoEmIngles").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(texto)
                );
            try
            {
                _repository.SetText(By.ClassName("QFw9Te"), By.ClassName("er8xn"), texto);
                //_repository.SetText(By.ClassName("QFw9Te"), By.ClassName("D5aOJc"), texto);
            }
            catch(Exception e)
            {
                throw e;
            }
            _log.RegistrarLog
              (
                    Informacao: $@"2º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("PreencherTextoEmIngles").Name}"
                  , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("PreencherTextoEmIngles").Name}"
              );
        }
    }
}
