using Fazsoft.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazsoft.Store.Domain.Contracts.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        //CRUD
        IEnumerable<T> Get();
        Task<IEnumerable<T>> GetAsync();
        T Get(int id);
        Task<T> GetAsync(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
