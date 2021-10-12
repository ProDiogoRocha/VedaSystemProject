using System;
using VedaSystem.Domain.Models;

namespace VedaSystem.Domain.Interfaces
{
    public interface IDepoimentoRepository : IRepository<Depoimento>
    {
        Depoimento GetDepoimentoByIdUsuario(Guid usuarioId);
    }
}
