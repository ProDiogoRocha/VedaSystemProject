using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using VedaSystem.Domain.Interfaces;

namespace VedaSystem.Infra.Data.Repositorys
{
    public abstract class Repository<T> : IDisposable, IRepository<T> where T : class
    {
        private readonly DbContext Db;
        private readonly DbSet<T> DbSet;

        public T _model;
        public IEnumerable<T> _listModel;
        public ILogRepository _log;
        public string _nomeEntidade = "";

        public Repository(DbContext context, ILogRepository logger = null)
        {
            Db = context;
            DbSet = Db.Set<T>();
            _log = logger;
            _model = null;
            _listModel = null;
            _nomeEntidade = this.GetType().Name;
        }

        public virtual void Add(T t)
        {
            _log.RegistrarLog
                (
                      Informacao: $@"3º Passo | {_nomeEntidade}, Iniciando Add"
                    , Repositorio_Metodo: $@"{_nomeEntidade}/Add"
                    , ObjetoJson: JsonConvert.SerializeObject(t)
                );

            try
            {
                DbSet.Add(t);
                Db.SaveChanges();
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"3º Passo | {_nomeEntidade}, Entity Add"
                   , Repositorio_Metodo: $@"{_nomeEntidade}/Add"
                   , ObjetoJson: JsonConvert.SerializeObject(t)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }
            _log.RegistrarLog
                (
                      Informacao: $@"3º Passo | {_nomeEntidade}, Finalizando Add"
                    , Repositorio_Metodo: $@"{_nomeEntidade}/{this.GetType().GetMethod("Add").Name}"
                );
        }

        public virtual void Update(T t)
        {
            _log.RegistrarLog
                 (
                       Informacao: $@"3º Passo | {_nomeEntidade}, Iniciando Update"
                     , Repositorio_Metodo: $@"{_nomeEntidade}/Update"
                     , ObjetoJson: JsonConvert.SerializeObject(t)
                 );

            try
            {
                DbSet.Update(t);
                Db.SaveChanges();
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"3º Passo | {_nomeEntidade}, Entity Update"
                   , Repositorio_Metodo: $@"{_nomeEntidade}/Update"
                   , ObjetoJson: JsonConvert.SerializeObject(t)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }
            _log.RegistrarLog
               (
                     Informacao: $@"3º Passo | {_nomeEntidade}, Finalizando Update"
                   , Repositorio_Metodo: $@"{_nomeEntidade}/Update"
               );
        }

        public virtual void Remove(T t)
        {
            _log.RegistrarLog
                 (
                       Informacao: $@"3º Passo | {_nomeEntidade}, Iniciando Remove"
                     , Repositorio_Metodo: $@"{_nomeEntidade}/Remove"
                     , ObjetoJson: JsonConvert.SerializeObject(t)
                 );

            try
            {
                DbSet.Remove(t);
                Db.SaveChanges();
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"3º Passo | {_nomeEntidade}, Entity Remove"
                   , Repositorio_Metodo: $@"{_nomeEntidade}/Remove"
                   , ObjetoJson: JsonConvert.SerializeObject(t)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }
            _log.RegistrarLog
               (
                     Informacao: $@"3º Passo | {_nomeEntidade}, Finalizando Remove"
                   , Repositorio_Metodo: $@"{_nomeEntidade}/Remove"
               );
        }

        public virtual void Dispose()
        {
            Db.Dispose();
        }

        public virtual IEnumerable<T> GetAll()
        {
            _log.RegistrarLog
                 (
                       Informacao: $@"3º Passo | {_nomeEntidade}, Iniciando GetAll"
                     , Repositorio_Metodo: $@"{_nomeEntidade}/GetAll"
                 );
            try
            {
                _listModel = DbSet.ToList();
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"3º Passo | {_nomeEntidade}, Entity GetAll"
                   , Repositorio_Metodo: $@"{_nomeEntidade}/GetAll"
                   , ObjetoJson: JsonConvert.SerializeObject(_listModel)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }

            _log.RegistrarLog
               (
                     Informacao: $@"3º Passo | {_nomeEntidade}, Finalizando GetAll"
                   , Repositorio_Metodo: $@"{_nomeEntidade}/GetAll"
                   , ObjetoJson: JsonConvert.SerializeObject(_listModel)
               );

            return _listModel;
        }

        public virtual T GetById(Guid id, bool ativo)
        {
            _log.RegistrarLog
                 (
                       Informacao: $@"3º Passo | {_nomeEntidade}, Iniciando GetById"
                     , Repositorio_Metodo: $@"{_nomeEntidade}/GetById"
                     , ObjetoJson: JsonConvert.SerializeObject(id)
                 );

            try
            {
                _model = DbSet.Find(id);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"3º Passo | {_nomeEntidade}, Entity GetById"
                   , Repositorio_Metodo: $@"{_nomeEntidade}/GetById"
                   , ObjetoJson: JsonConvert.SerializeObject(_model)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }

            _log.RegistrarLog
               (
                     Informacao: $@"3º Passo | {_nomeEntidade}, Finalizando GetById"
                   , Repositorio_Metodo: $@"{_nomeEntidade}/GetById"
                   , ObjetoJson: JsonConvert.SerializeObject(_model)
               );

            return _model;
        }

        public virtual T GetById(Guid id)
        {
            _log.RegistrarLog
                 (
                       Informacao: $@"3º Passo | {_nomeEntidade}, Iniciando GetById"
                     , Repositorio_Metodo: $@"{_nomeEntidade}/GetById"
                     , ObjetoJson: JsonConvert.SerializeObject(id)
                 );

            try
            {
                _model = DbSet.Find(id);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"3º Passo | {_nomeEntidade}, Entity GetById"
                   , Repositorio_Metodo: $@"{_nomeEntidade}/GetById"
                   , ObjetoJson: JsonConvert.SerializeObject(_model)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }

            _log.RegistrarLog
               (
                     Informacao: $@"3º Passo | {_nomeEntidade}, Finalizando GetById"
                   , Repositorio_Metodo: $@"{_nomeEntidade}/GetById"
                   , ObjetoJson: JsonConvert.SerializeObject(_model)
               );

            return _model;
        }

        public void SaveChanges()
        {
            Db.SaveChanges();
        }

        public IEnumerable<T> GetByName(string name, string propertyName)
        {
            _log.RegistrarLog
                 (
                       Informacao: $@"3º Passo | {_nomeEntidade}, Iniciando GetByName"
                     , Repositorio_Metodo: $@"{_nomeEntidade}/GetByName"
                 );
            try
            {
                IEnumerable<T> list = DbSet.ToList<T>();
                IList<T> returnList = new List<T>();
                if (!string.IsNullOrEmpty(name) || name != null)
                {
                    foreach (var obj in list)
                    {
                        if (obj.GetType().GetProperty(propertyName).GetValue(obj).ToString().Contains(name))
                        {
                            returnList.Add(obj);
                        }
                    }
                    _listModel = returnList;
                }
                else
                {
                    _listModel = list;
                }
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"3º Passo | {_nomeEntidade}, Entity GetByName"
                   , Repositorio_Metodo: $@"{_nomeEntidade}/GetByName"
                   , ObjetoJson: JsonConvert.SerializeObject(name)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }

            _log.RegistrarLog
               (
                     Informacao: $@"3º Passo | {_nomeEntidade}, Finalizando GetByName"
                   , Repositorio_Metodo: $@"{_nomeEntidade}/GetByName"
                   , ObjetoJson: JsonConvert.SerializeObject(_listModel)
               );

            return _listModel;
        }
        public virtual void DetachLocal(Func<T, bool> predicate)
        {
            var local = Db.Set<T>().Local.Where(predicate).FirstOrDefault();
            if (local != null)
            {
                Db.Entry(local).State = EntityState.Detached;
            }
        }
    }
}
