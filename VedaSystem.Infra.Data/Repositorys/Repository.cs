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

        public Repository(DbContext context, ILogRepository logger = null)
        {
            Db = context;
            DbSet = Db.Set<T>();
            _log = logger;
            _model = null;
            _listModel = null;
        }

        public virtual void Add(T t)
        {
            _log.RegistrarLog
                (
                      Informacao: $@"3º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("Add").Name}"
                    , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Add").Name}"
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
                     Informacao: $@"3º Passo | {this.GetType().Name}, Entity {this.GetType().GetMethod("Add").Name}"
                   , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Add").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(t)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }
            _log.RegistrarLog
                (
                      Informacao: $@"3º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("Add").Name}"
                    , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Add").Name}"
                );
        }

        public virtual void Update(T t)
        {
            _log.RegistrarLog
                 (
                       Informacao: $@"3º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("Update").Name}"
                     , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Update").Name}"
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
                     Informacao: $@"3º Passo | {this.GetType().Name}, Entity {this.GetType().GetMethod("Update").Name}"
                   , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Update").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(t)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }
            _log.RegistrarLog
               (
                     Informacao: $@"3º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("Update").Name}"
                   , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Update").Name}"
               );
        }

        public virtual void Remove(T t)
        {
            _log.RegistrarLog
                 (
                       Informacao: $@"3º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("Remove").Name}"
                     , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Remove").Name}"
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
                     Informacao: $@"3º Passo | {this.GetType().Name}, Entity {this.GetType().GetMethod("Remove").Name}"
                   , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Remove").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(t)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }
            _log.RegistrarLog
               (
                     Informacao: $@"3º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("Remove").Name}"
                   , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Remove").Name}"
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
                       Informacao: $@"3º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("GetAll").Name}"
                     , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetAll").Name}"
                 );
            try
            {
                _listModel = DbSet.ToList();
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

        public virtual T GetById(Guid id)
        {
            _log.RegistrarLog
                 (
                       Informacao: $@"3º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("GetById").Name}"
                     , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetById").Name}"
                     , ObjetoJson: JsonConvert.SerializeObject(id)
                 );

            try
            {
                _model = DbSet.Find(id);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"3º Passo | {this.GetType().Name}, Entity {this.GetType().GetMethod("GetById").Name}"
                   , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetById").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(_model)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }

            _log.RegistrarLog
               (
                     Informacao: $@"3º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("GetById").Name}"
                   , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetById").Name}"
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
                       Informacao: $@"3º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("GetAll").Name}"
                     , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetAll").Name}"
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
                     Informacao: $@"3º Passo | {this.GetType().Name}, Entity {this.GetType().GetMethod("GetAll").Name}"
                   , Repositorio_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetAll").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(name)
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
