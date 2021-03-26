using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VedaSystemProject.Application.AutoMapper.Implementacao.BaseMapper
{
    public abstract class MapperProfile<K, V> 
    {
        public MapperProfile()
        {
            MapperConfig = GetMapper().CreateMapper();
        }

        public IMapper MapperConfig { get; set; }

        public virtual MapperConfiguration GetMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<K, V>();
                cfg.CreateMap<V, K>();
            });
        }

        public virtual Task<IEnumerable<V>> EntityToViewModel(IList<K> Ks)
        {
            IEnumerable<V> Vs = new List<V>();
            foreach (K k in Ks)
            {
                Vs.ToList().Add(MapperConfig.Map<K, V>(k));
            }
            return Task.FromResult(Vs);
        }

        public virtual Task<IEnumerable<K>> ViewModelToEntity(IList<V> Vs)
        {
            IEnumerable<K> Ks = new List<K>();
            foreach (V v in Vs)
            {
                Ks.ToList().Add(MapperConfig.Map<V, K>(v));
            }
            return Task.FromResult(Ks);
        }
    }
}
