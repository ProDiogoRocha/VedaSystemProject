using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.Utils;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Interfaces;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Repositorys;

namespace VedaSystem.Application.Services
{
    public class TerapeutaService : Service<Terapeuta, TerapeutaViewModel>, ITerapeutaService
    {

        private Terapeuta _model;
        private readonly IMapper _mapper;
        private readonly ITerapeutaRepository _repository;
        private readonly IUsuarioRepository _usuarioRepository;

        public TerapeutaService(IMapper mapper, ITerapeutaRepository repository, IUsuarioRepository usuarioRepository, ILogService logger) : base(mapper, repository, logger)
        {
            _mapper = mapper;
            _repository = repository;
            _usuarioRepository = usuarioRepository;
        }

        public TerapeutaViewModel GetTerapeutaPorNomeDeUsuario(string NomeUsuario)
        {
            _log.RegistrarLog
               (
                     Informacao: $@"2º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("GetTerapeutaPorNomeDeUsuario").Name}"
                   , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetTerapeutaPorNomeDeUsuario").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(NomeUsuario)
               );

            Terapeuta terapeuta = _repository.GetTerapeutaPorNomeDeUsuario(NomeUsuario);
            TerapeutaViewModel terapeutaViewModel = new TerapeutaViewModel();

            try
            {
                terapeutaViewModel = _mapper.Map<TerapeutaViewModel>(terapeuta);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                    Informacao: $@"2º Passo | {this.GetType().Name}, AutoMapper {this.GetType().GetMethod("GetTerapeutaPorNomeDeUsuario").Name}"
                  , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetTerapeutaPorNomeDeUsuario").Name}"
                  , ObjetoJson: JsonConvert.SerializeObject(terapeuta)
                  , Erro: e.Message
                  , Excecao: e.ToString());
            }

            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("GetTerapeutaPorNomeDeUsuario").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetTerapeutaPorNomeDeUsuario").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(terapeutaViewModel)
                );
            return terapeutaViewModel;
        }

        public IEnumerable<TerapeutaViewModel> GetTerapeutasPorTerapia(Guid idTerapia)
        {
            _log.RegistrarLog
               (
                     Informacao: $@"2º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("GetTerapeutasPorTerapia").Name}"
                   , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetTerapeutasPorTerapia").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(idTerapia)
               );

            IEnumerable<Terapeuta> terapeutas = _repository.GetTerapeutasPorTerapia(idTerapia);
            IEnumerable<TerapeutaViewModel> terapeutasViewModel = new List<TerapeutaViewModel>();

            try
            {
                terapeutasViewModel = _mapper.Map<IEnumerable<TerapeutaViewModel>>(terapeutas);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                    Informacao: $@"2º Passo | {this.GetType().Name}, AutoMapper {this.GetType().GetMethod("GetTerapeutasPorTerapia").Name}"
                  , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetTerapeutasPorTerapia").Name}"
                  , ObjetoJson: JsonConvert.SerializeObject(terapeutas)
                  , Erro: e.Message
                  , Excecao: e.ToString());
            }

            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("GetTerapeutasPorTerapia").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetTerapeutasPorTerapia").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(terapeutasViewModel)
                );
            return terapeutasViewModel;
        }

        public IEnumerable<TerapeutaViewModel> GetTerapeutasPorTerapiaOuTerapeuta(string nomeTerapia)
        {
            _log.RegistrarLog
               (
                     Informacao: $@"2º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("GetTerapeutasPorTerapia").Name}"
                   , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetTerapeutasPorTerapia").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(nomeTerapia)
               );

            IEnumerable<Terapeuta> terapeutas = _repository.GetTerapeutasPorTerapiaOuTerapeuta(nomeTerapia);
            IEnumerable<TerapeutaViewModel> terapeutasViewModel = new List<TerapeutaViewModel>();

            try
            {
                terapeutasViewModel = _mapper.Map<IEnumerable<TerapeutaViewModel>>(terapeutas);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                    Informacao: $@"2º Passo | {this.GetType().Name}, AutoMapper {this.GetType().GetMethod("GetTerapeutasPorTerapia").Name}"
                  , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetTerapeutasPorTerapia").Name}"
                  , ObjetoJson: JsonConvert.SerializeObject(terapeutas)
                  , Erro: e.Message
                  , Excecao: e.ToString());
            }

            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("GetTerapeutasPorTerapia").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetTerapeutasPorTerapia").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(terapeutasViewModel)
                );
            return terapeutasViewModel;
        }

        public override void Add(TerapeutaViewModel entity)
        {
            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("Add").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Add").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(entity)
                );

            try
            {
                _model = _mapper.Map<Terapeuta>(entity);
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

            _repository.Add(Cripto<Terapeuta>.CriptografarDadosSigilosos(_model));

            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("Add").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("Add").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(_model)
                );
        }
    }
}
