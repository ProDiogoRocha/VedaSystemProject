using System.Threading.Tasks;
using VedaSystemProject.Application.AutoMapper.Interfaces;
using VedaSystemProject.Application.Interfaces;
using VedaSystemProject.Application.ViewModels;
using VedaSystemProject.Domain.Interfaces;
using VedaSystemProject.Domain.Models;

namespace VedaSystemProject.Application.Services
{
    public class UsuarioService : Service<Usuario, UsuarioViewModel> , IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapperProfile<Usuario, UsuarioViewModel> _usuarioMapperProfile;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapperProfile<Usuario, UsuarioViewModel> usuarioMapperProfile) : base(usuarioRepository, usuarioMapperProfile)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioMapperProfile = usuarioMapperProfile;
        }

        public Task<Usuario> GetUsuarioForLogin(string email, string senha)
        {
            return _usuarioRepository.GetUsuarioForLogin(email, senha);
        }
    }
}
