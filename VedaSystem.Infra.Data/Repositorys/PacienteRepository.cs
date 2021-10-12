using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using VedaSystem.Domain.Interfaces;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Context;

namespace VedaSystem.Infra.Data.Repositorys
{
    public class PacienteRepository : Repository<Paciente>, IPacienteRepository
    {
        private readonly PacienteContext Db;
        private readonly DbSet<Paciente> DbSet;
        public PacienteRepository(PacienteContext context, ILogRepository log) : base(context, log)
        {
            Db = context;
            DbSet = Db.Set<Paciente>();
        }

        public IEnumerable<Paciente> BuscarPorIdTerapeuta(Guid? idTerapeuta)
        {
            IEnumerable<Paciente> pacientes = new List<Paciente>();

            _log.RegistrarLog
                 (
                       Informacao: $@"3º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("BuscarPorIdTerapeuta").Name}"
                     , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("BuscarPorIdTerapeuta").Name}"
                     , ObjetoJson: JsonConvert.SerializeObject(idTerapeuta)
                 );
            try
            {
                pacientes = (from p in Db.Pacientes
                             from t in p.Terapeutas
                             where t.Id == idTerapeuta
                             select p)
                                .Include(p => p.Prescricoes)
                                .Include(p => p.Terapeutas)
                                .ToList();
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                    Informacao: $@"3º Passo | {this.GetType().Name}, Entity {this.GetType().GetMethod("BuscarPorIdTerapeuta").Name}"
                  , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("BuscarPorIdTerapeuta").Name}"
                  , ObjetoJson: JsonConvert.SerializeObject(idTerapeuta)
                  , Erro: e.Message
                  , Excecao: e.ToString());
            }
           
            return pacientes;
        }

        public IEnumerable<Paciente> BuscarPorNome(Guid? idTerapeuta, string nome)
        {
            IEnumerable<Paciente> pacientes = new List<Paciente>();

            _log.RegistrarLog
                 (
                       Informacao: $@"3º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("BuscarPorNome").Name}"
                     , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("BuscarPorNome").Name}"
                     , ObjetoJson: JsonConvert.SerializeObject(nome)
                 );

            try
            {
                pacientes = (from p in Db.Pacientes
                             from t in p.Terapeutas
                             where t.Id == idTerapeuta
                             && p.Nome.Contains(nome)
                             select p)
                                .Include(p => p.Prescricoes)
                                .Include(p => p.Terapeutas)
                                .ToList();
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"3º Passo | {this.GetType().Name}, Entity {this.GetType().GetMethod("BuscarPorNome").Name}"
                   , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("BuscarPorNome").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(nome)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }
            _log.RegistrarLog
               (
                     Informacao: $@"3º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("BuscarPorNome").Name}"
                   , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("BuscarPorNome").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(pacientes)
               );
            return pacientes;
        }

        public override void Remove(Paciente p)
        {
            try
            {
                base.DetachLocal(_ => _.Id == p.Id);
                base.Remove(p);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"3º Passo | {_nomeEntidade}, Entity Remove"
                   , Repositorio_Metodo: $@"{_nomeEntidade}/Remove"
                   , ObjetoJson: JsonConvert.SerializeObject(p)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }
        }
    }
}
