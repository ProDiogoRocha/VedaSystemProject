using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;
using VedaSystem.Web.Interface;

namespace VedaSystem.Web.Utils
{
    public class AspNetUser : IUser
    {

        private readonly IHttpContextAccessor _accessor;
        private readonly IUsuarioService _usuarioService;
        private readonly ITerapeutaService _terapeutaService;
        private readonly IEmailService _emailService;
        private IMapper _mapper;

        public AspNetUser(IHttpContextAccessor accessor, IUsuarioService usuarioService, ITerapeutaService terapeutaService, IEmailService emailService, IMapper mapper)
        {
            _accessor = accessor;
            _usuarioService = usuarioService;
            _terapeutaService = terapeutaService;
            _emailService = emailService;
            _mapper = mapper;
        }

        public string Name => _accessor.HttpContext.User.Identity.Name;

        public string Id => throw new NotImplementedException();

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }

        public Usuario GetUsuario()
        {
            return _mapper.Map<Usuario>(_usuarioService.GetByName(this.Name, "NomeDeUsuario").FirstOrDefault());
        }

        public TerapeutaViewModel GetTerapeuta()
        {
            return _terapeutaService.GetTerapeutaPorNomeDeUsuario(this.Name);
        }

        public Email GetEmail(Guid? idTerapeuta)
        {
            return _emailService.GetDadosDeEmailPorTerapeuta(idTerapeuta);
        }
    }
}
