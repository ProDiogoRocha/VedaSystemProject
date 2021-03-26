using System;
using System.Collections.Generic;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.Interfaces
{
    public interface IPacienteService : IService<Paciente, PacienteViewModel>
    {
        IEnumerable<PacienteViewModel> BuscarPorNome(Guid? idTerapeuta, string nome);
        IEnumerable<PacienteViewModel> BuscarPorIdTerapeuta(Guid? idTerapeuta);
    }
}
