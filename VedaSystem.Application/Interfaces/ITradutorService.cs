using System.Collections.Generic;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.Interfaces
{
    public interface ITradutorService : IService<Tradutor, TradutorViewModel>
    {
        void CarregarPagina();
        void PreencherTextoEmIngles(string texto);
        string GetTextoEmPortugues(string textto);
        void Fechar();
        IEnumerable<TradutorViewModel> GetPorTexto(string texto);
    }
}
