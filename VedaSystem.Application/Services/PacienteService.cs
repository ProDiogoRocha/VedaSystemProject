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
    public class PacienteService : Service<Paciente, PacienteViewModel>, IPacienteService
    {
        private IMapper _mapper;
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteService(IMapper mapper, IPacienteRepository pacienteRepository, ILogService logger) : base(mapper, pacienteRepository, logger)
        {
            _mapper = mapper;
            _pacienteRepository = pacienteRepository;
        }

        public IEnumerable<PacienteViewModel> BuscarPorNome(Guid? idTerapeuta, string nome)
        {
            IEnumerable<Paciente> pacientes = new List<Paciente>();
            IEnumerable<PacienteViewModel> pacientesViewModels = new List<PacienteViewModel>();

            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("BuscarPorNome").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("BuscarPorNome").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(nome)
                );

            pacientes = _pacienteRepository.BuscarPorNome(idTerapeuta, nome);
            try
            {
                pacientesViewModels = _mapper.Map<IEnumerable<PacienteViewModel>>(pacientes);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"2º Passo | {this.GetType().Name}, AutoMapper {this.GetType().GetMethod("BuscarPorNome").Name}"
                   , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("BuscarPorNome").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(pacientes)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }

            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("BuscarPorNome").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("BuscarPorNome").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(pacientesViewModels)
                );
            return pacientesViewModels;
        }

        public IEnumerable<PacienteViewModel> BuscarPorIdTerapeuta(Guid? idTerapeuta)
        {
            IEnumerable<Paciente> pacientes = new List<Paciente>();
            IEnumerable<PacienteViewModel> pacientesViewModels = new List<PacienteViewModel>();

            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Iniciando {this.GetType().GetMethod("BuscarPorNome").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("BuscarPorNome").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(idTerapeuta)
                );

            pacientes = _pacienteRepository.BuscarPorIdTerapeuta(idTerapeuta);
            try
            {
                pacientesViewModels = _mapper.Map<IEnumerable<PacienteViewModel>>(pacientes);
            }
            catch (Exception e)
            {
                _log.RegistrarLog(
                     Informacao: $@"2º Passo | {this.GetType().Name}, AutoMapper {this.GetType().GetMethod("BuscarPorNome").Name}"
                   , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("BuscarPorNome").Name}"
                   , ObjetoJson: JsonConvert.SerializeObject(pacientes)
                   , Erro: e.Message
                   , Excecao: e.ToString());
            }

            _log.RegistrarLog
                (
                      Informacao: $@"2º Passo | {this.GetType().Name}, Finalizando {this.GetType().GetMethod("BuscarPorNome").Name}"
                    , Servico_Metodo: $@"{this.GetType().Name}/{this.GetType().GetMethod("BuscarPorNome").Name}"
                    , ObjetoJson: JsonConvert.SerializeObject(pacientesViewModels)
                );
            return pacientesViewModels;
        }
    }
}
