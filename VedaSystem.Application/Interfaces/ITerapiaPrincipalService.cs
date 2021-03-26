using System.Collections.Generic;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.Interfaces
{
    public interface ITerapiaPrincipalService : IService<TerapiaPrincipal, TerapiaViewModel>
    {
        IEnumerable<TerapiaViewModel> BuscarPorNome(string nome);
        void InserirMaterialTerapia(ref TerapiaViewModel terapia, List<MaterialTerapia> materiais);
    }
}
