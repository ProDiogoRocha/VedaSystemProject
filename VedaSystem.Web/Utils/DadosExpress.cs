using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Context;
using VedaSystem.Infra.Data.Repositorys;

namespace VedaSystem.Web.Utils
{
    public class DadosExpress
    {
        private readonly UsuarioContext _usuarioContext;
        private readonly TerapeutaContext _terapeutaContext;
        private readonly EmailContext _emailContext;
        private readonly InfoMailContext _infoMailContext;
        private readonly LogContext _logContext;
        private readonly HttpContextAccessor _httpContextAccessor;

        private string stringConnection = "Server=mssql2017.hostingzone.com.br;Database=vedadb;Trusted_Connection=False;MultipleActiveResultSets=true;user id=vedaadmin;password=vedaadmin";
        public DadosExpress()
        {
            _usuarioContext = new UsuarioContext(new DbContextOptionsBuilder<UsuarioContext>().UseSqlServer(stringConnection).Options);
            _terapeutaContext = new TerapeutaContext(new DbContextOptionsBuilder<TerapeutaContext>().UseSqlServer(stringConnection).Options);
            _emailContext = new EmailContext(new DbContextOptionsBuilder<EmailContext>().UseSqlServer(stringConnection).Options);
            _infoMailContext = new InfoMailContext(new DbContextOptionsBuilder<InfoMailContext>().UseSqlServer(stringConnection).Options);
            _logContext = new LogContext(new DbContextOptionsBuilder<LogContext>().UseSqlServer(stringConnection).Options);
            _httpContextAccessor = new HttpContextAccessor();
        }

        public Usuario GetUsuario()
        {
            if (!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated) return null;

            var nome = _httpContextAccessor.HttpContext.User.Identity.Name;

            if (string.IsNullOrEmpty(nome))
            {
                return null;
            }

            var user = _usuarioContext.Usuarios.Where(u => u.NomeDeUsuario == nome).Select(u=>u).FirstOrDefault();
            return user;
        }

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _httpContextAccessor.HttpContext.User.Claims;
        }

        public Terapeuta GetTerapeuta()
        {
            return _terapeutaContext.Terapeutas.Where(t=>t.NomeDeUsuario == GetUsuario().NomeDeUsuario).FirstOrDefault();
        }

        public Email GetEmail(Guid? idTerapeuta)
        {
            EmailRepository emailRepository = new EmailRepository(_emailContext, _infoMailContext, new LogRepository(_logContext));
            return emailRepository.GetPorIdTerapeuta(idTerapeuta);
        }
    }
}
