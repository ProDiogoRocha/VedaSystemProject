using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VedaSystemProject.Application.AutoMapper.Interfaces
{
    public interface IMapperProfile<K, V> where K : class where V : class
    {
        IMapper MapperConfig { get; set; }
        MapperConfiguration GetMapper();
        Task<IEnumerable<V>> EntityToViewModel(IList<K> Ks);
        Task<IEnumerable<K>> ViewModelToEntity(IList<V> Vs);
    }
}
