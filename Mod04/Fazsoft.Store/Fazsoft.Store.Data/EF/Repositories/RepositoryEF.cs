using Fazsoft.Store.Domain.Contracts.Repositories;
using Fazsoft.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazsoft.Store.Data.EF.Repositories
{
    public class RepositoryEF<T> : IRepository<T> where T : Entity
    {
        protected readonly StoreDbContext _ctx;
        protected readonly DbSet<T> _dbSet;

        public RepositoryEF(StoreDbContext ctx)
        {
            _ctx = ctx;
            _dbSet = _ctx.Set<T>();
        }

        public IEnumerable<T> Get()
        {
            return _dbSet.ToList();
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<T> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

    }
}
