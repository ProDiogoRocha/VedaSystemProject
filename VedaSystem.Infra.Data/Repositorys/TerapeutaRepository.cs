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
    public class TerapeutaRepository : Repository<Terapeuta>, ITerapeutaRepository
    {

        private readonly TerapeutaContext _ctxTerapeuta;
        private readonly DbSet<Terapeuta> DbSet;
        public TerapeutaRepository(TerapeutaContext context, ILogRepository logger = null) : base(context, logger)
        {
            _ctxTerapeuta = context;
            DbSet = _ctxTerapeuta.Set<Terapeuta>();
        }

        public Terapeuta GetTerapeutaPorNomeDeUsuario(string nomeUsuario)
        {
            Terapeuta terapeuta = new Terapeuta();

            _log.RegistrarLog
                 (
                       Informacao: $@"3º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("GetTerapeutaPorNomeDeUsuario").Name}"
                     , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetTerapeutaPorNomeDeUsuario").Name}"
                     , ObjetoJson: JsonConvert.SerializeObject(nomeUsuario)
                 );
            try
            {
                terapeuta = DbSet.Where(t => t.NomeDeUsuario == nomeUsuario).Select(t => t).FirstOrDefault();
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                   Informacao: $@"3º Passo | {this.GetType().Name}, Entity {this.GetType().GetMethod("GetTerapeutaPorNomeDeUsuario").Name}"
                 , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetTerapeutaPorNomeDeUsuario").Name}"
                 , ObjetoJson: JsonConvert.SerializeObject(nomeUsuario)
                 , Erro: e.Message
                 , Excecao: e.ToString());
            }

            _log.RegistrarLog
               (
                     Informacao: $@"3º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("GetTerapeutaPorNomeDeUsuario").Name}"
                   , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetTerapeutaPorNomeDeUsuario").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(terapeuta)
               );
            return terapeuta;
        }

        public IEnumerable<Terapeuta> GetTerapeutasPorTerapia(Guid idTerapia)
        {
            IEnumerable<Terapeuta> terapeutas = new List<Terapeuta>();

            _log.RegistrarLog
                 (
                       Informacao: $@"3º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("GetTerapeutasPorTerapia").Name}"
                     , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetTerapeutasPorTerapia").Name}"
                     , ObjetoJson: JsonConvert.SerializeObject(idTerapia)
                 );

            try
            {
                terapeutas = _ctxTerapeuta.Terapeutas.FromSqlRaw($@"SELECT A.* FROM  Terapeuta A
                        INNER JOIN TerapeutaTerapia B ON A.Id = B.TerapeutasId
                        INNER JOIN Terapia C ON B.TerapiasId = c.Id
                        WHERE C.Id = '{idTerapia}'").ToList();
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                   Informacao: $@"3º Passo | {this.GetType().Name}, Entity {this.GetType().GetMethod("GetTerapeutasPorTerapia").Name}"
                 , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetTerapeutasPorTerapia").Name}"
                 , ObjetoJson: JsonConvert.SerializeObject(idTerapia)
                 , Erro: e.Message
                 , Excecao: e.ToString());
            }

            _log.RegistrarLog
               (
                     Informacao: $@"3º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("GetTerapeutasPorTerapia").Name}"
                   , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetTerapeutasPorTerapia").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(terapeutas)
               );
            return terapeutas;
        }

        public IEnumerable<Terapeuta> GetTerapeutasPorTerapiaOuTerapeuta(string nomeTerapiaTerapeuta)
        {
            IEnumerable<Terapeuta> terapeutas = new List<Terapeuta>();

            _log.RegistrarLog
                 (
                       Informacao: $@"3º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("GetTerapeutasPorTerapia").Name}"
                     , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetTerapeutasPorTerapia").Name}"
                     , ObjetoJson: JsonConvert.SerializeObject(nomeTerapiaTerapeuta)
                 );

            try
            {
                terapeutas = _ctxTerapeuta.Terapeutas.FromSqlRaw(
                    $@"SELECT A.* FROM  Terapeutas A
                    INNER JOIN TerapeutaTerapia B ON A.Id = B.TerapeutasId
                    INNER JOIN Terapias C ON B.TerapiasId = c.Id
                    WHERE C.NomeTerapia LIKE '%{nomeTerapiaTerapeuta}%' OR A.NomeCompleto LIKE '%{nomeTerapiaTerapeuta}%'").ToList();
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                   Informacao: $@"3º Passo | {this.GetType().Name}, Entity {this.GetType().GetMethod("GetTerapeutasPorTerapia").Name}"
                 , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetTerapeutasPorTerapia").Name}"
                 , ObjetoJson: JsonConvert.SerializeObject(nomeTerapiaTerapeuta)
                 , Erro: e.Message
                 , Excecao: e.ToString());
            }

            _log.RegistrarLog
               (
                     Informacao: $@"3º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("GetTerapeutasPorTerapia").Name}"
                   , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetTerapeutasPorTerapia").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(terapeutas)
               );
            return terapeutas;
        }

        public override IEnumerable<Terapeuta> GetAll()
        {
            _log.RegistrarLog
                 (
                       Informacao: $@"3º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("GetAll").Name}"
                     , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetAll").Name}"
                 );
            try
            {
                _listModel = _ctxTerapeuta.Terapeutas
                    .Include(x => x.Terapias)
                    .Include(x => x.Pacientes)
                    .Include(x=>x.TerapiasPrincipais)
                    .Include(x=>x.Agendas)
                    .Include(x=>x.Horarios)
                    .Include(x=>x.Precricoes)
                    .Include(x=>x.Transmissoes)
                    .ToList();
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"3º Passo | {this.GetType().Name}, Entity {this.GetType().GetMethod("GetAll").Name}"
                   , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetAll").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(_listModel)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }

            _log.RegistrarLog
               (
                     Informacao: $@"3º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("Remove").Name}"
                   , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Remove").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(_listModel)
               );

            return _listModel;
        }
    }
}
