using System;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.Interfaces
{
    public interface IDepoimentoService : IService<Depoimento, DepoimentoViewModel>
    {
        DepoimentoViewModel GetDepoimentoByIdUsuario(Guid usuarioId);
    }
}
