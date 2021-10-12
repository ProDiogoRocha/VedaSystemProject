using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Interfaces;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.Services
{
    public class TerapiaService : Service<Terapia, TerapiaViewModel>, ITerapiaService
    {
        private readonly ITerapiaRepository _repository;
        private IMapper _mapper;
        public TerapiaService(IMapper mapper, ITerapiaRepository repository, ILogService logger) : base(mapper, repository, logger)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IEnumerable<TerapiaViewModel> BuscarTerapiaPorTerapeuta(Guid idTerapeuta)
        {
            return _mapper.Map<IEnumerable<TerapiaViewModel>>(_repository.GetAll().Select(t => t.Terapeutas.Where(tr => tr.Id == idTerapeuta)).ToList());
        }

        public IEnumerable<TerapiaViewModel> BuscarPorNome(string nome)
        {
            IEnumerable<TerapiaViewModel> terapiaViewModels = new List<TerapiaViewModel>();
            IEnumerable<Terapia> terapias = new List<Terapia>();

            _log.RegistrarLog
               (
                     Informacao: $@"2º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("BuscarPorNome").Name}"
                   , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("BuscarPorNome").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(nome)
               );

            terapias = _repository.BuscarPorNome(nome);

            try
            {
                terapiaViewModels = _mapper.Map<IEnumerable<TerapiaViewModel>>(terapias);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"2º Passo | {this.GetType().Name}, AutoMapper {this.GetType().GetMethod("BuscarPorNome").Name}"
                   , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("BuscarPorNome").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(terapias)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }
            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("BuscarPorNome").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("BuscarPorNome").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(terapiaViewModels)
                );

            return terapiaViewModels;
        }

        public void InserirMaterialTerapia(ref TerapiaViewModel terapia, List<MaterialTerapia> materiais)
        {
            _log.RegistrarLog
               (
                     Informacao: $@"2º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("InserirMaterialTerapia").Name}"
                   , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("InserirMaterialTerapia").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(materiais)
               );

            try
            {
                terapia.Materiais = _mapper.Map<List<MaterialTerapiaViewModel>>(materiais);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"2º Passo | {this.GetType().Name}, AutoMapper {this.GetType().GetMethod("InserirMaterialTerapia").Name}"
                   , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("InserirMaterialTerapia").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(materiais)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }
            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("InserirMaterialTerapia").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("InserirMaterialTerapia").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(terapia.Materiais)
                );
        }
    }
}
