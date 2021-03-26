using System;
using System.Collections.Generic;
using VedaSystem.Domain.Models;

namespace VedaSystem.Domain.Interfaces
{
    public interface ITratamentoRepository : IRepository<Tratamento>
    {
        IEnumerable<Tratamento> GetPorIdPrescricao(Guid? IdPrescricao);
    }
}
