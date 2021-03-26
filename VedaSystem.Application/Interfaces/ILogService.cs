using System;
using System.Collections.Generic;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.Interfaces
{
    public interface ILogService
    {
        Log GetById(Guid id);
        IEnumerable<Log> GetAll();
        void Register(Log log);
        void Remove(Log log);
    }
}
