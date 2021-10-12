using System;
using System.Collections.Generic;
using System.Security.Claims;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;

namespace VedaSystem.Web.Interface
{
    public interface IUser
    {
        string Id { get; }
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
        Usuario GetUsuario();
        TerapeutaViewModel GetTerapeuta();
        Email GetEmail(Guid? idTerapeuta);
    }
}
