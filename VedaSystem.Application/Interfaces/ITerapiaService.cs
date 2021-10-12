using System;
using System.Collections.Generic;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.Interfaces
{
    public interface ITerapiaService : IService<Terapia, TerapiaViewModel>
    {
        IEnumerable<TerapiaViewModel> BuscarPorNome(string nome);
        void InserirMaterialTerapia(ref TerapiaViewModel terapia, List<MaterialTerapia> materiais);
        IEnumerable<TerapiaViewModel> BuscarTerapiaPorTerapeuta(Guid idTerapeuta);
    }
}
