using System.Threading.Tasks;
using VedaSystemProject.Application.ViewModels;
using VedaSystemProject.Domain.Models;

namespace VedaSystemProject.Application.Interfaces
{
    public interface IUsuarioService : IService<Usuario, UsuarioViewModel>
    {
        Task<Usuario> GetUsuarioForLogin(string email, string senha);
    }
}
