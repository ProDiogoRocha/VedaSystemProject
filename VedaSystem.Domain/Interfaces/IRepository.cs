using System;
using System.Collections.Generic;

namespace VedaSystem.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(Guid id);
        T GetById(Guid id, bool ativo);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void Dispose();
        void SaveChanges();
        IEnumerable<T> GetByName(string name, string propertyName);
    }
}
