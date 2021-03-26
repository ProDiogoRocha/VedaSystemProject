using System;
using System.Collections.Generic;
using VedaSystem.Application.Interfaces;
using VedaSystem.Domain.Interfaces;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;
        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public IEnumerable<Log> GetAll()
        {
            return _logRepository.GetAll();
        }

        public Log GetById(Guid id)
        {
            return _logRepository.GetById(id);
        }

        public void Register(Log log)
        {
            _logRepository.Register(log);
        }

        public void Remove(Log log)
        {
            _logRepository.Remove(log);
        }
    }
}
