using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using VedaSystem.Domain.Models;

namespace VedaSystem.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> GetUsuarioPorLogin(string email, string senha);
        IList<SelectListItem> GetPerfisUsuario();
    }
}
