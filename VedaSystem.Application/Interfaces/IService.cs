using System;
using System.Collections.Generic;

namespace VedaSystem.Application.Interfaces
{
    public interface IService<T, Vm> where T : class where Vm :class
    {
        Vm GetById(Guid id);
        Vm GetById(Guid id, bool ativo);
        IEnumerable<Vm> GetAll();
        void Add(Vm entity);
        void Update(Vm entity);
        void Remove(Vm entity);
        IEnumerable<Vm> GetByName(string name, string propertyName);
    }
}
