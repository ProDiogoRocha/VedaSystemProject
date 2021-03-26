using System;
using System.Collections.Generic;
using VedaSystem.Domain.Models;

namespace VedaSystem.Domain.Interfaces
{
    public interface IPacienteRepository : IRepository<Paciente>
    {
        IEnumerable<Paciente> BuscarPorNome(Guid? idTerapeuta, string nome);
        IEnumerable<Paciente> BuscarPorIdTerapeuta(Guid? idTerapeuta);
    }
}
