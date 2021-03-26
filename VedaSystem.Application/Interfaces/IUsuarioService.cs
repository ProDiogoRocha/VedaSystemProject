using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.Interfaces
{
    public interface IUsuarioService : IService<Usuario, UsuarioViewModel>
    {
        Task<Usuario> GetUsuarioPorLogin(string email, string senha);
        IList<SelectListItem> GetPerfisUsuario();
    }
}
