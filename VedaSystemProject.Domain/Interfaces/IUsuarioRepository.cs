using System.Threading.Tasks;
using VedaSystemProject.Domain.Models;

namespace VedaSystemProject.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> GetUsuarioForLogin(string email, string senha);
    }
}
