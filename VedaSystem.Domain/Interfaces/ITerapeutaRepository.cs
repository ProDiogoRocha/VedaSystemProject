using System;
using System.Collections.Generic;
using VedaSystem.Domain.Models;

namespace VedaSystem.Domain.Interfaces
{
    public interface ITerapeutaRepository : IRepository<Terapeuta>
    {
        Terapeuta GetTerapeutaPorNomeDeUsuario(string nomeUsuario);
        IEnumerable<Terapeuta> GetTerapeutasPorTerapia(Guid idTerapia);
        IEnumerable<Terapeuta> GetTerapeutasPorTerapiaOuTerapeuta(string nomeTerapiaTerapeuta);

    }
}
