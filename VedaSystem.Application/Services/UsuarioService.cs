using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.Utils;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Interfaces;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.Services
{
    public class UsuarioService : Service<Usuario, UsuarioViewModel>, IUsuarioService
    {
        private IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UsuarioService(
              RoleManager<IdentityRole> roleManager
            , UserManager<ApplicationUser> userManager
            , SignInManager<ApplicationUser> signInManager
            , IMapper mapper
            , IUsuarioRepository usuarioRepository
            , ILogService logger) : base(mapper, usuarioRepository, logger)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Usuario> GetUsuarioPorLogin(string email, string senha)
        {
            Usuario viewModel = new Usuario();

            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("GetUsuarioPorLogin").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetUsuarioPorLogin").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(email)
                );
            var usuario = await _usuarioRepository.GetUsuarioPorLogin(email, senha);
            try
            {
                viewModel = _mapper.Map<Usuario>(usuario);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"2º Passo | {this.GetType().Name}, AutoMapper {this.GetType().GetMethod("GetUsuarioPorLogin").Name}"
                   , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetUsuarioPorLogin").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(usuario)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }

            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("GetUsuarioPorLogin").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetUsuarioPorLogin").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(viewModel)
                );
            return viewModel;
        }

        public override UsuarioViewModel GetById(Guid id)
        {
            var usuario = base.GetById(id);

            usuario.GetTipoUsuarioText();

            var listaDeTipoDeUsuarios = _usuarioRepository.GetPerfisUsuario();
            var selected = listaDeTipoDeUsuarios.Where(a => a.Text == usuario.TipoUsuarioName).Select(a => a).FirstOrDefault();

            usuario.Endereco = Cripto<UsuarioViewModel>.Descriptografar(usuario.Endereco);
            usuario.Senha = "";
            usuario.ConfirmeSenha = "";
            usuario.GetTipoUsuarioEnum();
            usuario.TiposUsuario = new SelectList(listaDeTipoDeUsuarios, "Value", "Text", selected).ToList();

            return usuario;
        }

        public IList<SelectListItem> GetPerfisUsuario()
        {
            return _usuarioRepository.GetPerfisUsuario();
        }

        public override void Add(UsuarioViewModel entity)
        {
            var user = new ApplicationUser { UserName = entity.NomeDeUsuario, Email = entity.Email };
            var result = _userManager.CreateAsync(user, entity.Senha).Result;
            if (result.Succeeded)
            {
                var applicationRole = _roleManager.FindByNameAsync(entity.RetornaPerfil());

                if (applicationRole != null)
                {
                    IdentityResult roleResult = _userManager.AddToRoleAsync(user, applicationRole.Result.Name).Result;
                }

                entity.Id = Guid.Parse(user.Id);
                Cripto<UsuarioViewModel>.CriptografarDadosSigilosos(entity);
            }

            Usuario usuario = null;

            _log.RegistrarLog
            (
                  Informacao: $@"2º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("Add").Name}"
                , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Add").Name}"
                , ObjetoJson: JsonConvert.SerializeObject(entity)
            );

            try
            {
                usuario = new Usuario()
                {
                    Id = entity.Id,
                    Email = entity.Email,
                    Endereco = entity.Endereco,
                    Senha = entity.Senha,
                    ConfirmeSenha = entity.ConfirmeSenha,
                    DataCadastro = entity.DataCadastro,
                    DataNascimento = entity.DataNascimento,
                    Foto = entity.Foto,
                    NomeDeUsuario = entity.NomeDeUsuario,
                    TipoUsuario = entity.TipoUsuario
                };
            }
            catch (Exception e)
            {
                _log.RegistrarLog
                 (
                     Informacao: $@"2º Passo | {this.GetType().Name}, AutoMapper {this.GetType().GetMethod("Add").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Add").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(entity)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }

            _usuarioRepository.Add(usuario);

            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("Add").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Add").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(entity)
                );
        }


        public override void Update(UsuarioViewModel entity)
        {
            Usuario usuario = new Usuario();

            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("Update").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Update").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(entity)
                );
            try
            {
                usuario.Id = entity.Id;
                usuario.NomeDeUsuario = entity.NomeDeUsuario;
                usuario.Senha = entity.Senha;
                usuario.ConfirmeSenha = entity.ConfirmeSenha;
                usuario.DataCadastro = entity.DataCadastro;
                usuario.DataNascimento = entity.DataNascimento;
                usuario.Email = entity.Email;
                usuario.Foto = entity.Foto;
                usuario.TipoUsuario = entity.TipoUsuario;
                usuario.Endereco = entity.Endereco;
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                    Informacao: $@"2º Passo | {this.GetType().Name}, AutoMapper {this.GetType().GetMethod("Update").Name}"
                  , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Update").Name}"
                  , ObjetoJson: JsonConvert.SerializeObject(entity)
                  , Erro: e.Message
                  , Excecao: e.ToString());
            }
            _usuarioRepository.Update(usuario);

            _log.RegistrarLog
               (
                     Informacao: $@"2º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("Update").Name}"
                   , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Update").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(usuario)
               );
        }
    }
}

