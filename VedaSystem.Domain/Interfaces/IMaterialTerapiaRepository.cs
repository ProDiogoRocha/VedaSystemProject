using System;
using System.Collections.Generic;
using VedaSystem.Domain.Models;

namespace VedaSystem.Domain.Interfaces
{
    public interface IMaterialTerapiaRepository : IRepository<MaterialTerapia>
    {
        IEnumerable<MaterialTerapia> GetPorIdTerapia(Guid? IdTerapia);
    }
}
