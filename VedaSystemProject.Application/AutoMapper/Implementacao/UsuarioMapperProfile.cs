using VedaSystemProject.Application.AutoMapper.Implementacao.BaseMapper;
using VedaSystemProject.Application.AutoMapper.Interfaces;
using VedaSystemProject.Application.ViewModels;
using VedaSystemProject.Domain.Models;

namespace VedaSystemProject.Application.AutoMapper.Implementacao
{
    public class UsuarioMapperProfile : MapperProfile<Usuario, UsuarioViewModel>, IMapperProfile<Usuario, UsuarioViewModel>
    {
        public UsuarioMapperProfile() : base() { }
    }
}
