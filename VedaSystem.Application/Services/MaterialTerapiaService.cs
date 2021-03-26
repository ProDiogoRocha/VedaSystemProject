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
    public class MaterialTerapiaService : Service<MaterialTerapia, MaterialTerapiaViewModel>, IMaterialTerapiaService
    {
        private readonly IMapper _mapper;
        private readonly IMaterialTerapiaRepository _repository;
        public MaterialTerapiaService(IMapper mapper, IMaterialTerapiaRepository repository, ILogService logger) : base(mapper, repository, logger)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IEnumerable<MaterialTerapiaViewModel> BuscarPorIdTerapia(Guid? IdTerapia)
        {
            IEnumerable<MaterialTerapia> materiaisTerapias = new List<MaterialTerapia>();
            IEnumerable<MaterialTerapiaViewModel> materiaisTerapiasViewModel = new List<MaterialTerapiaViewModel>();

            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("BuscarPorIdTerapia").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("BuscarPorIdTerapia").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(IdTerapia)
                );

            materiaisTerapias = _repository.GetPorIdTerapia(IdTerapia);

            try
            {
                materiaisTerapiasViewModel = _mapper.Map<IEnumerable<MaterialTerapiaViewModel>>(materiaisTerapias);
            }
            catch(Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"2º Passo | {this.GetType().Name}, AutoMapper {this.GetType().GetMethod("BuscarPorIdTerapia").Name}"
                   , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("BuscarPorIdTerapia").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(materiaisTerapias)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }

            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("BuscarPorIdTerapia").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("BuscarPorIdTerapia").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(materiaisTerapiasViewModel)
                );

            return materiaisTerapiasViewModel;
        }
    }
}
