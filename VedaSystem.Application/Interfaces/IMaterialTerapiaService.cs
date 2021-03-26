using System;
using System.Collections.Generic;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.Interfaces
{
    public interface IMaterialTerapiaService : IService<MaterialTerapia, MaterialTerapiaViewModel>
    {
        IEnumerable<MaterialTerapiaViewModel> BuscarPorIdTerapia(Guid? IdTerapia);
    }
}
