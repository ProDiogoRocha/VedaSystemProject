using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Interfaces;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.Services
{
    public class TratamentoService : Service<Tratamento, TratamentoViewModel>, ITratamentoService
    {
        private readonly IMapper _mapper;
        private readonly ITratamentoRepository _repository;
        public TratamentoService(IMapper mapper, ITratamentoRepository repository, ILogService logger) : base(mapper, repository, logger)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IEnumerable<TratamentoViewModel> GetPorIdPrescricao(Guid? IdPrescricao)
        {
            IEnumerable<TratamentoViewModel> tratamentosViewModel = new List<TratamentoViewModel>();

            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("GetPorIdPrescricao").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetPorIdPrescricao").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(IdPrescricao)
                );
            
            IEnumerable<Tratamento> tratamentos = _repository.GetPorIdPrescricao(IdPrescricao);

            try
            {
                tratamentosViewModel = _mapper.Map<IEnumerable<TratamentoViewModel>>(tratamentos);
            }
            catch(Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"2º Passo | {this.GetType().Name}, AutoMapper {this.GetType().GetMethod("GetPorIdPrescricao").Name}"
                   , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetPorIdPrescricao").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(tratamentos)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }

            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("GetPorIdPrescricao").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetPorIdPrescricao").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(tratamentosViewModel)
                );

            return tratamentosViewModel;
        }
    }
}
