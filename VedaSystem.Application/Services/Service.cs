using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.Utils;
using VedaSystem.Domain.Interfaces;

namespace VedaSystem.Application.Services
{
    public abstract class Service<T, Vm> : IDisposable, IService<T, Vm> where T : class where Vm : class
    {
        private readonly IRepository<T> _repository;
        private IMapper _mapper;
        public LogApp _log;

        private T _model;
        private Vm _viewModel;

        private IEnumerable<T> _modelList;
        private IEnumerable<Vm> _viewModelList;

        public Service(IMapper mapper, IRepository<T> repository, ILogService logger)
        {
            _repository = repository;
            _mapper = mapper;
            _log = new LogApp(logger);
            _model = null;
            _viewModel = null;
            _modelList = null;
            _viewModelList = null;
        }

        public virtual void Add(Vm entity)
        {
            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("Add").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Add").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(entity)
                );

            try
            {
                _model = _mapper.Map<T>(entity);
            }
            catch (Exception e)
            {
                _log.RegistrarLog
                 (
                     Informacao: $@"2º Passo | {this.GetType().Name}, AutoMapper {this.GetType().GetMethod("Add").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Add").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(_model)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }


            _repository.Add(_model);

            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("Add").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Add").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(_model)
                );
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public virtual IEnumerable<Vm> GetAll()
        {
            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("GetAll").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetAll").Name}"
                );

            _modelList = _repository.GetAll();

            try
            {
                _viewModelList = _mapper.Map<IEnumerable<Vm>>(_modelList);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"2º Passo | {this.GetType().Name}, AutoMapper {this.GetType().GetMethod("GetAll").Name}"
                   , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetAll").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(_modelList)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }

            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("GetAll").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetAll").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(_viewModelList)
                );

            return _viewModelList;
        }

        public virtual Vm GetById(Guid id)
        {
            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("GetById").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetById").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(id)
                );

            _model = _repository.GetById(id);

            try
            {
                _viewModel = _mapper.Map<Vm>(_model);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"2º Passo | {this.GetType().Name}, AutoMapper {this.GetType().GetMethod("GetById").Name}"
                   , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetById").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(_model)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }

            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("GetById").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetById").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(_viewModel)
                );

            return _viewModel;
        }

        public virtual void Remove(Vm entity)
        {
            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("Remove").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Remove").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(entity)
                );
            try
            {
                _model = _mapper.Map<T>(entity);

            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"2º Passo | {this.GetType().Name}, AutoMapper {this.GetType().GetMethod("Remove").Name}"
                   , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Remove").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(entity)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }
            _repository.Remove(_model);

            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("Remove").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Remove").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(_model)
                );
        }

        public virtual void Update(Vm entity)
        {
            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("Update").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Update").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(entity)
                );
            try
            {
                _model = _mapper.Map<T>(entity);
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
            _repository.Update(_model);

            _log.RegistrarLog
               (
                     Informacao: $@"2º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("Update").Name}"
                   , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Update").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(_model)
               );
        }

        public IEnumerable<Vm> GetByName(string name, string propertyName)
        {
            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("Update").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Update").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(name)
                );

            _modelList = _repository.GetByName(name, propertyName);

            try
            {
                _viewModelList = _mapper.Map<IEnumerable<Vm>>(_modelList);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                    Informacao: $@"2º Passo | {this.GetType().Name}, AutoMapper {this.GetType().GetMethod("Update").Name}"
                  , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Update").Name}"
                  , ObjetoJson: JsonConvert.SerializeObject(_modelList)
                  , Erro: e.Message
                  , Excecao: e.ToString());
            }

            _log.RegistrarLog
               (
                     Informacao: $@"2º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("Update").Name}"
                   , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Update").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(_viewModelList)
               );

            return _viewModelList;
        }
    }
}
