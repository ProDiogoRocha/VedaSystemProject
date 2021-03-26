using System.Collections.Generic;
using VedaSystem.Domain.Models;

namespace VedaSystem.Domain.Interfaces
{
    public interface ITerapiaRepository : IRepository<Terapia>
    {
        IEnumerable<Terapia> BuscarPorNome(string nome);
    }
}
