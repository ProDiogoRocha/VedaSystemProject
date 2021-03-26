using Dapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using VedaSystem.Domain.Interfaces;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Context;

namespace VedaSystem.Infra.Data.Repositorys
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        private readonly UsuarioContext Db;
        private readonly DbSet<Usuario> DbSet;

        public UsuarioRepository(UsuarioContext context, ILogRepository log) : base(context, log)
        {
            Db = context;
            DbSet = Db.Set<Usuario>();
        }

        public async Task<Usuario> GetUsuarioPorLogin(string email, string senha)
        {
            _log.RegistrarLog
                 (
                       Informacao: $@"3º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("GetUsuarioPorLogin").Name}"
                     , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetUsuarioPorLogin").Name}"
                     , ObjetoJson: JsonConvert.SerializeObject(email)
                 );

            try
            {
                _model = await DbSet.FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);
                
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"3º Passo | {this.GetType().Name}, Entity {this.GetType().GetMethod("GetUsuarioPorLogin").Name}"
                   , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetUsuarioPorLogin").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(email)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }

            _log.RegistrarLog
               (
                     Informacao: $@"3º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("GetUsuarioPorLogin").Name}"
                   , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetUsuarioPorLogin").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(_model)
               );

            return _model;
        }

        public IList<SelectListItem> GetPerfisUsuario()
        {
            var conn = Db.Database.GetDbConnection();

            conn.Open();
            IList<SelectListItem>  returns = conn.Query<SelectListItem>("SELECT Id as Value, Name as Text FROM AspNetRoles").ToList();
            conn.Close();

            return returns;
        }
    }
}
