using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using VedaSystem.Domain.Models;

namespace VedaSystem.Domain.Interfaces
{
    public interface ITradutorRepository : IRepository<Tradutor>
    {
        void LoadPage(TimeSpan timeToWait);
        string GetText(By by);
        IReadOnlyCollection<IWebElement> GetTexts(By byFather, By byChildrens);
        void SetText(By by, string text);
        void Submit(By by);
        void CloseBrowser();
        IEnumerable<Tradutor> GetPorTexto(string texto);
        void SetText(By byFather, By byChildren, string text);
    }
}
