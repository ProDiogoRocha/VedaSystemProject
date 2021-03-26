using System;
using System.Collections.Generic;
using VedaSystem.Domain.Models;

namespace VedaSystem.Domain.Interfaces
{
    public interface ITransmissaoRepository : IRepository<Transmissao>
    {
        IEnumerable<Transmissao> GetTransmissaoPorTitulo(string titulo);
        IEnumerable<Transmissao> GetTransmissaoPorTerapeuta(Guid? idTerapeuta);
    }
}
