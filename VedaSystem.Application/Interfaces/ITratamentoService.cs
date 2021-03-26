using System;
using System.Collections.Generic;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.Interfaces
{
    public interface ITratamentoService : IService<Tratamento, TratamentoViewModel>
    {
        IEnumerable<TratamentoViewModel> GetPorIdPrescricao(Guid? IdPrescricao);
    }
}
