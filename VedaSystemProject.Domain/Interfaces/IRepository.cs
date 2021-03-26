using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VedaSystemProject.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void Dispose();
    }
}
