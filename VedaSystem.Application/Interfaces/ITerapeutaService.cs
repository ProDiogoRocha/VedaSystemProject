using System;
using System.Collections.Generic;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.Interfaces
{
    public interface ITerapeutaService : IService<Terapeuta, TerapeutaViewModel>
    {
        TerapeutaViewModel GetTerapeutaPorNomeDeUsuario(string NomeUsuario);
        IEnumerable<TerapeutaViewModel> GetTerapeutasPorTerapia(Guid idTerapia);
        IEnumerable<TerapeutaViewModel> GetTerapeutasPorTerapiaOuTerapeuta(string nomeTerapia);
    }
}
