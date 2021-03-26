using System.Collections.Generic;
using VedaSystem.Domain.Models;

namespace VedaSystem.Domain.Interfaces
{
    public interface ITerapiaPrincipalRepository : IRepository<TerapiaPrincipal>
    {
        IEnumerable<TerapiaPrincipal> BuscarPorNome(string nome);
    }
}
