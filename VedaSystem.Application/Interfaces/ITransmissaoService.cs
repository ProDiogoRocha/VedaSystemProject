using System;
using System.Collections.Generic;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.Interfaces
{
    public interface ITransmissaoService : IService<Transmissao, TransmissaoViewModel>
    {
        IEnumerable<TransmissaoViewModel> GetTransmissaoPorTitulo(string Titulo);
        IEnumerable<TransmissaoViewModel> GetTransmissaoPorTerapeuta(Guid? idTerapeuta);
    }
}
