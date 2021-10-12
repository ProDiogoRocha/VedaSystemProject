using System;
using System.Collections.Generic;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.Interfaces
{
    public interface IHorarioService : IService<Horario, HorarioTerapeutaViewModel>
    {
        IEnumerable<HorarioTerapeutaViewModel> GetHorariosByIdTerapeuta(Guid idTerapeuta);
    }
}
