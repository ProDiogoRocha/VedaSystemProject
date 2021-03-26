using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VedaSystemProject.Application.Interfaces
{
    public interface IService<M, Vm> where M : class where Vm : class
    {
        Task<Vm> GetById(Guid id);
        Task<IEnumerable<Vm>> GetAll();
        void Add(Vm entity);
        void Update(Vm entity);
        void Remove(Vm entity);
        void Dispose();
    }
}
