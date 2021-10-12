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
        public readonly IRepository<T> _repository;
        public IMapper _mapper;
        public LogApp _log;

        public T _model;
        public Vm _viewModel;

        public IEnumerable<T> _modelList;
        public IEnumerable<Vm> _viewModelList;

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
                      Informacao: $@"2º Passo | {this.GetType().Name}, Iniciando Add"
                    , Servico_Metodo: $@"{this.GetType().Name}/Add"
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
                     Informacao: $@"2º Passo | {this.GetType().Name}, AutoMapper Add"
                    , Servico_Metodo: $@"{this.GetType().Name}/Add"
                   , ObjetoJson: JsonConvert.SerializeObject(_model)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }


            _repository.Add(_model);

            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Finalizando Add"
                    , Servico_Metodo: $@"{this.GetType().Name}/Add"
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
                      Informacao: $@"2º Passo | {this.GetType().Name}, Iniciando GetAll"
                    , Servico_Metodo: $@"{this.GetType().Name}/GetAll"
                );

            _modelList = _repository.GetAll();

            try
            {
                _viewModelList = _mapper.Map<IEnumerable<Vm>>(_modelList);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"2º Passo | {this.GetType().Name}, AutoMapper GetAll"
                   , Servico_Metodo: $@"{this.GetType().Name}/GetAll"
                   , ObjetoJson: JsonConvert.SerializeObject(_modelList)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }

            //_log.RegistrarLog
            //    (
            //          Informacao: $@"2º Passo | {this.GetType().Name}, Finalizando GetAll"
            //        , Servico_Metodo: $@"{this.GetType().Name}/GetAll"
            //        , ObjetoJson: JsonConvert.SerializeObject(_viewModelList)
            //    );

            return _viewModelList;
        }

        public virtual Vm GetById(Guid id)
        {
            try
            {
                _log.RegistrarLog
                    (
                          Informacao: $@"2º Passo | {this.GetType().Name }, Iniciando GetById"
                        , Servico_Metodo: $@"{this.GetType().Name}/GetById"
                        , ObjetoJson: JsonConvert.SerializeObject(id)
                    );
            }catch(Exception e)
            {

            }
            _model = _repository.GetById(id);

            try
            {
                _viewModel = _mapper.Map<Vm>(_model);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"2º Passo | {this.GetType().Name}, AutoMapper GetById"
                   , Servico_Metodo: $@"{this.GetType().Name}/GetById"
                   , ObjetoJson: JsonConvert.SerializeObject(_model)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }

            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Finalizando GetById"
                    , Servico_Metodo: $@"{this.GetType().Name}/GetById"
                    , ObjetoJson: JsonConvert.SerializeObject(_viewModel)
                );

            return _viewModel;
        }

        public virtual void Remove(Vm entity)
        {
            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Iniciando Remove"
                    , Servico_Metodo: $@"{this.GetType().Name}/Remove"
                    , ObjetoJson: JsonConvert.SerializeObject(entity)
                );
            try
            {
                _model = _mapper.Map<T>(entity);

            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"2º Passo | {this.GetType().Name}, AutoMapper Remove"
                   , Servico_Metodo: $@"{this.GetType().Name}/Remove"
                   , ObjetoJson: JsonConvert.SerializeObject(entity)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }
            _repository.Remove(_model);

            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Finalizando Remove"
                    , Servico_Metodo: $@"{this.GetType().Name}/Remove"
                    , ObjetoJson: JsonConvert.SerializeObject(_model)
                );
        }

        public virtual void Update(Vm entity)
        {
            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Iniciando Update"
                    , Servico_Metodo: $@"{this.GetType().Name}/Update"
                    , ObjetoJson: JsonConvert.SerializeObject(entity)
                );
            try
            {
                _model = _mapper.Map<T>(entity);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                    Informacao: $@"2º Passo | {this.GetType().Name}, AutoMapper Update"
                  , Servico_Metodo: $@"{this.GetType().Name}/Update"
                  , ObjetoJson: JsonConvert.SerializeObject(entity)
                  , Erro: e.Message
                  , Excecao: e.ToString());
            }
            _repository.Update(_model);

            _log.RegistrarLog
               (
                     Informacao: $@"2º Passo | {this.GetType().Name}, Finalizando Update"
                   , Servico_Metodo: $@"{this.GetType().Name}/Update"
                   , ObjetoJson: JsonConvert.SerializeObject(_model)
               );
        }

        public IEnumerable<Vm> GetByName(string name, string propertyName)
        {
            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Iniciando GetByName"
                    , Servico_Metodo: $@"{this.GetType().Name}/GetByName"
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
                    Informacao: $@"2º Passo | {this.GetType().Name}, AutoMapper GetByName"
                  , Servico_Metodo: $@"{this.GetType().Name}/GetByName"
                  , ObjetoJson: JsonConvert.SerializeObject(_modelList)
                  , Erro: e.Message
                  , Excecao: e.ToString());
            }

            _log.RegistrarLog
               (
                     Informacao: $@"2º Passo | {this.GetType().Name}, Finalizando GetByName"
                   , Servico_Metodo: $@"{this.GetType().Name}/GetByName"
                   , ObjetoJson: JsonConvert.SerializeObject(_viewModelList)
               );

            return _viewModelList;
        }

        public Vm GetById(Guid id, bool ativo)
        {
            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Iniciando GetById"
                    , Servico_Metodo: $@"{this.GetType().Name}/GetById"
                    , ObjetoJson: JsonConvert.SerializeObject(id)
                );

            _model = _repository.GetById(id, ativo);

            try
            {
                _viewModel = _mapper.Map<Vm>(_model);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"2º Passo | {this.GetType().Name}, AutoMapper GetById"
                   , Servico_Metodo: $@"{this.GetType().Name}/GetById"
                   , ObjetoJson: JsonConvert.SerializeObject(_model)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }

            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Finalizando GetById"
                    , Servico_Metodo: $@"{this.GetType().Name}/GetById"
                    , ObjetoJson: JsonConvert.SerializeObject(_viewModel)
                );

            return _viewModel;
        }
    }
}
