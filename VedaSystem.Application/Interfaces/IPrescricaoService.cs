using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.Interfaces
{
    public interface IPrescricaoService : IService<Prescricao, PrescricaoViewModel>
    {
    }
}
