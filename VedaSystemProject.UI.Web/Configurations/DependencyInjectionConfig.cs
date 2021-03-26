using Microsoft.Extensions.DependencyInjection;
using System;
using VedaSystemProject.Application.AutoMapper.Implementacao;
using VedaSystemProject.Application.AutoMapper.Interfaces;
using VedaSystemProject.Application.Interfaces;
using VedaSystemProject.Application.Services;
using VedaSystemProject.Application.ViewModels;
using VedaSystemProject.Domain.Interfaces;
using VedaSystemProject.Domain.Models;
using VedaSystemProject.Infra.Data.Repository;

namespace VedaSystemProject.UI.Web.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IMapperProfile<Usuario, UsuarioViewModel>, UsuarioMapperProfile>();
        }
    }
}
