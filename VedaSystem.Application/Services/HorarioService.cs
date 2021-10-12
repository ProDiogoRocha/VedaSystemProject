using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using VedaSystem.Application.Interfaces;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Interfaces;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.Services
{
    public class HorarioService : Service<Horario, HorarioTerapeutaViewModel>, IHorarioService
    {
        public HorarioService(IMapper mapper, IHorarioRepository repository, ILogService logger) : base(mapper, repository, logger)
        {
        }

        public IEnumerable<HorarioTerapeutaViewModel> GetHorariosByIdTerapeuta(Guid idTerapeuta)
        {
            IEnumerable<HorarioTerapeutaViewModel> horariosVm = null;

            try
            {
                IEnumerable<Horario> horarios = _repository.GetAll().Where(t => t.TerapeutaId == idTerapeuta).Select(t => t).ToList();
                horariosVm = _mapper.Map<IEnumerable<Horario>, IEnumerable<HorarioTerapeutaViewModel>>(horarios);
            }catch(Exception e)
            {
                _log.RegistrarLog(Erro: e.Message);
            }

            return horariosVm;
        }
    }
}
