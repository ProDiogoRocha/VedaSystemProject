using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VedaSystemProject.Domain.Interfaces;

namespace VedaSystemProject.Infra.Data.Repository.BaseRepository
{
    public class BaseRepository<T> : IDisposable, IRepository<T> where T : class
    {
        private DbContext Db;
        public readonly DbSet<T> DbSet;

        public BaseRepository(DbContext context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }

        public async Task<T> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
