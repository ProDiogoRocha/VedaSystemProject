using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using VedaSystemProject.Domain.Interfaces;
using VedaSystemProject.Domain.Models;
using VedaSystemProject.Infra.Data.Context;
using VedaSystemProject.Infra.Data.Repository.BaseRepository;

namespace VedaSystemProject.Infra.Data.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public DbContext _Db;
        public DbSet<Usuario> _DbSet;
        public UsuarioRepository(UsuarioContext context) : base(context)
        {
            _Db = context;
            _DbSet = _Db.Set<Usuario>();
        }

        public Task<Usuario> GetUsuarioForLogin(string email, string senha)
        {
            return Task.FromResult(_DbSet.Where(a => a.Email == email && a.Senha == senha).Select(a => a).FirstOrDefault());
        }
    }
}
