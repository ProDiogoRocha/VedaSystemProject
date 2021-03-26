using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedaSystemProject.Application.AutoMapper.Interfaces;
using VedaSystemProject.Application.Interfaces;
using VedaSystemProject.Domain.Interfaces;

namespace VedaSystemProject.Application.Services
{
    public class Service<M, Vm> : IDisposable, IService<M, Vm> where M : class where Vm : class
    {
        private readonly IRepository<M> _genericRepository;
        private readonly IMapperProfile<M, Vm> _genericMapperProfile;
        public Service(IRepository<M> repository, IMapperProfile<M, Vm> genericMapperProfile)
        {
            _genericRepository = repository;
            _genericMapperProfile = genericMapperProfile;
        }

        public void Add(Vm entity)
        {
            _genericRepository.Add(_genericMapperProfile.MapperConfig.Map<Vm, M>(entity));
        }

        public void Dispose()
        {
            _genericRepository.Dispose();
        }

        public Task<IEnumerable<Vm>> GetAll()
        {
            return _genericMapperProfile.EntityToViewModel(_genericRepository.GetAll().Result.ToList());
        }

        public Task<Vm> GetById(Guid id)
        {
            return Task.FromResult(_genericMapperProfile.MapperConfig.Map<M,Vm>(_genericRepository.GetById(id).Result));
        }

        public void Remove(Vm entity)
        {
            _genericRepository.Remove(_genericMapperProfile.MapperConfig.Map<Vm, M>(entity));
        }

        public void Update(Vm entity)
        {
            _genericRepository.Update(_genericMapperProfile.MapperConfig.Map<Vm, M>(entity));
        }
    }
}
