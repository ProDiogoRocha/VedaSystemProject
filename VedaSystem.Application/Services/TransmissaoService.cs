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
    public class TransmissaoService : Service<Transmissao, TransmissaoViewModel>, ITransmissaoService
    {
        private readonly IMapper _mapper;
        private readonly ITransmissaoRepository _repository;
        public TransmissaoService(IMapper mapper, ITransmissaoRepository repository, ILogService logger) : base(mapper, repository, logger)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IEnumerable<TransmissaoViewModel> GetTransmissaoPorTerapeuta(Guid? idTerapeuta)
        {
            IEnumerable<TransmissaoViewModel> transmissoesViewModel = new List<TransmissaoViewModel>();

            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("GetTransmissaoPorTerapeuta").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetTransmissaoPorTerapeuta").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(idTerapeuta)
                );

            IEnumerable<Transmissao> transmissoes = _repository.GetTransmissaoPorTerapeuta(idTerapeuta);
            try
            {
                transmissoesViewModel = _mapper.Map<IEnumerable<TransmissaoViewModel>>(transmissoes);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"2º Passo | {this.GetType().Name}, AutoMapper {this.GetType().GetMethod("GetTransmissaoPorTerapeuta").Name}"
                   , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetTransmissaoPorTerapeuta").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(transmissoes)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }

            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("GetTransmissaoPorTerapeuta").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetTransmissaoPorTerapeuta").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(transmissoesViewModel)
                );

            return transmissoesViewModel;
        }

        public IEnumerable<TransmissaoViewModel> GetTransmissaoPorTitulo(string Titulo)
        {
            IEnumerable<TransmissaoViewModel> transmissoesViewModel = new List<TransmissaoViewModel>();

            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("GetTransmissaoPorTitulo").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetTransmissaoPorTitulo").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(Titulo)
                );

            IEnumerable<Transmissao> transmissoes = _repository.GetTransmissaoPorTitulo(Titulo);
            try
            {
                transmissoesViewModel = _mapper.Map<IEnumerable<TransmissaoViewModel>>(transmissoes);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"2º Passo | {this.GetType().Name}, AutoMapper {this.GetType().GetMethod("GetTransmissaoPorTitulo").Name}"
                   , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetTransmissaoPorTitulo").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(transmissoes)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }

            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("GetTransmissaoPorTitulo").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("GetTransmissaoPorTitulo").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(transmissoesViewModel)
                );

            return transmissoesViewModel;
        }
    }
}
