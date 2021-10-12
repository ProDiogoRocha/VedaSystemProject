using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using VedaSystem.Domain.Enums;
using VedaSystem.Domain.Interfaces;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Context;

namespace VedaSystem.Infra.Data.Repositorys
{
    public class TradutorRepository : Repository<Tradutor>, ITradutorRepository
    {
        private string _urlDriver = "";
        private string _urlSite = "https://translate.google.com.br/?hl=pt-BR";

        private IWebDriver _webDriver = null;
        protected readonly TradutorContext Db;
        protected readonly DbSet<Tradutor> DbSet;

        public TradutorRepository(TradutorContext context, ILogRepository log) : base(context, log)
        {
            Db = context;
            DbSet = Db.Set<Tradutor>();
        }

        private void GetIntanciaWebDriver(Browser browser)
        {
            if (_webDriver == null)
            {
                switch (browser)
                {
                    case Browser.Chrome:
                        _urlDriver = "C:\\Users\\prodi\\Documents\\Projetos\\VedaSystemProject\\SeleniumDrivers\\Chrome";
                        break;
                    case Browser.Firefox:
                        _urlDriver = "C:\\Users\\prodi\\Documents\\Projetos\\VedaSystemProject\\SeleniumDrivers\\Firefox";
                        break;
                    default:
                        _urlDriver = "C:\\Users\\prodi\\Documents\\Projetos\\VedaSystemProject\\SeleniumDrivers\\PhantomJS";
                        break;
                }
                _webDriver = Db.CreateWebDriver(browser, _urlDriver);
            }
        }

        public void CloseBrowser()
        {
            _log.RegistrarLog
                 (
                       Informacao: $@"3º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("CloseBrowser").Name}"
                     , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("CloseBrowser").Name}"
                 );
            try
            {
                GetIntanciaWebDriver(Browser.Chrome);
                _webDriver.Quit();
                _webDriver = null;
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                  Informacao: $@"3º Passo | {this.GetType().Name}, Selenium {this.GetType().GetMethod("CloseBrowser").Name}"
                , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("CloseBrowser").Name}"
                , Erro: e.Message
                , Excecao: e.ToString());
            }

            _log.RegistrarLog
               (
                     Informacao: $@"3º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("CloseBrowser").Name}"
                   , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("CloseBrowser").Name}"
               );
        }

        public IEnumerable<Tradutor> GetPorTexto(string texto)
        {
            IEnumerable<Tradutor> traducoes = new List<Tradutor>();

            _log.RegistrarLog
                 (
                       Informacao: $@"3º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("GetPorTexto").Name}"
                     , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetPorTexto").Name}"
                     , ObjetoJson: JsonConvert.SerializeObject(texto)
                 );

            try
            {
                traducoes = Db.ConteudoPt.Where(a => a.Texto.Contains(texto)).Select(a => a).ToList();
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                  Informacao: $@"3º Passo | {this.GetType().Name}, Selenium {this.GetType().GetMethod("GetPorTexto").Name}"
                , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetPorTexto").Name}"
                , ObjetoJson: JsonConvert.SerializeObject(texto)
                , Erro: e.Message
                , Excecao: e.ToString());
            }

            _log.RegistrarLog
               (
                     Informacao: $@"3º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("GetPorTexto").Name}"
                   , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetPorTexto").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(traducoes)
               );
            return traducoes;

        }

        public string GetText(By by)
        {
            IWebElement webElement = null;

            _log.RegistrarLog
                 (
                       Informacao: $@"3º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("GetText").Name}"
                     , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetText").Name}"
                     , ObjetoJson: JsonConvert.SerializeObject(by)
                 );
            try
            {
                GetIntanciaWebDriver(Browser.Chrome);
                webElement = _webDriver.FindElement(by);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                  Informacao: $@"3º Passo | {this.GetType().Name}, Selenium {this.GetType().GetMethod("GetText").Name}"
                , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetText").Name}"
                , ObjetoJson: JsonConvert.SerializeObject(by)
                , Erro: e.Message
                , Excecao: e.ToString());
            }

            _log.RegistrarLog
               (
                     Informacao: $@"3º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("BuscarPorNome").Name}"
                   , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("BuscarPorNome").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(webElement)
               );

            return webElement.Text;
        }

        public IReadOnlyCollection<IWebElement> GetTexts(By byFather, By byChildrens)
        {
            IReadOnlyCollection<IWebElement> webElements = null;
            _log.RegistrarLog
                 (
                       Informacao: $@"3º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("GetTexts").Name}"
                     , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetTexts").Name}"
                     , ObjetoJson: JsonConvert.SerializeObject(byFather) + JsonConvert.SerializeObject(byChildrens)
                 );
            try
            {
                GetIntanciaWebDriver(Browser.Chrome);
                webElements = _webDriver.FindElement(byFather).FindElements(byChildrens);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                  Informacao: $@"3º Passo | {this.GetType().Name}, Selenium {this.GetType().GetMethod("GetTexts").Name}"
                , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetTexts").Name}"
                , ObjetoJson: JsonConvert.SerializeObject(byFather) + JsonConvert.SerializeObject(byChildrens)
                , Erro: e.Message
                , Excecao: e.ToString());
            }
            _log.RegistrarLog
               (
                     Informacao: $@"3º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("GetTexts").Name}"
                   , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetTexts").Name}"
               );
            return webElements;
        }

        public void LoadPage(TimeSpan timeToWait)
        {
            _log.RegistrarLog
                 (
                       Informacao: $@"3º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("LoadPage").Name}"
                     , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("LoadPage").Name}"
                     , ObjetoJson: JsonConvert.SerializeObject(timeToWait)
                 );
            try
            {
                GetIntanciaWebDriver(Browser.Chrome);
                _webDriver.Manage().Timeouts().PageLoad = timeToWait;
                _webDriver.Navigate().GoToUrl(_urlSite);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                  Informacao: $@"3º Passo | {this.GetType().Name}, Selenium {this.GetType().GetMethod("LoadPage").Name}"
                , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("LoadPage").Name}"
                , ObjetoJson: JsonConvert.SerializeObject(_urlSite)
                , Erro: e.Message
                , Excecao: e.ToString());
            }

            _log.RegistrarLog
               (
                     Informacao: $@"3º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("LoadPage").Name}"
                   , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("LoadPage").Name}"
               );
        }

        public void SetText(By by, string text)
        {
            _log.RegistrarLog
                 (
                       Informacao: $@"3º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("SetText").Name}"
                     , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("SetText").Name}"
                     , ObjetoJson: JsonConvert.SerializeObject(by) + JsonConvert.SerializeObject(text)
                 );
            try
            {
                GetIntanciaWebDriver(Browser.Chrome);
                IWebElement webElement = _webDriver.FindElement(by);
                webElement.SendKeys(text);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                  Informacao: $@"3º Passo | {this.GetType().Name}, Selenium {this.GetType().GetMethod("SetText").Name}"
                , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("SetText").Name}"
                , ObjetoJson: JsonConvert.SerializeObject(by) + JsonConvert.SerializeObject(text)
                , Erro: e.Message
                , Excecao: e.ToString());
            }
            _log.RegistrarLog
               (
                     Informacao: $@"3º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("SetText").Name}"
                   , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("SetText").Name}"
               );
        }

        public void SetText(By byFather, By byChildren, string text)
        {
            try
            {
                GetIntanciaWebDriver(Browser.Chrome);
                var webElement = _webDriver.FindElement(byFather).FindElement(byChildren);
                webElement.SendKeys(text);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                  Informacao: $@"3º Passo | {this.GetType().Name}, Selenium {this.GetType().GetMethod("SetText").Name}"
                , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("SetText").Name}"
                , ObjetoJson: JsonConvert.SerializeObject(byFather) + JsonConvert.SerializeObject(byChildren) + JsonConvert.SerializeObject(text)
                , Erro: e.Message
                , Excecao: e.ToString());
            }
           
        }

        public void Submit(By by)
        {
            _log.RegistrarLog
                 (
                       Informacao: $@"3º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("Submit").Name}"
                     , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Submit").Name}"
                     , ObjetoJson: JsonConvert.SerializeObject(by)
                 );
            try
            {
                GetIntanciaWebDriver(Browser.Chrome);
                IWebElement webElement = _webDriver.FindElement(by);
                webElement.Submit();
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                  Informacao: $@"3º Passo | {this.GetType().Name}, Selenium {this.GetType().GetMethod("Submit").Name}"
                , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Submit").Name}"
                , ObjetoJson: JsonConvert.SerializeObject(by) + JsonConvert.SerializeObject(by)
                , Erro: e.Message
                , Excecao: e.ToString());
            }

            _log.RegistrarLog
               (
                     Informacao: $@"3º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("Submit").Name}"
                   , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Submit").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(by)
               );
        }

        public override void Remove(Tradutor t)
        {
            try
            {
                base.DetachLocal(_ => _.Id == t.Id);
                base.Remove(t);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"3º Passo | Tradutor, Entity Remove"
                   , Repositorio_Metodo: $@"Tradutor/Remove"
                   , ObjetoJson: JsonConvert.SerializeObject(t)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }
        }
    }
}
