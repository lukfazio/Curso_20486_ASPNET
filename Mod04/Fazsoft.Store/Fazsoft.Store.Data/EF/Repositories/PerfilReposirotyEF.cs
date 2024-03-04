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
    public class PerfilReposirotyEF : RepositoryEF<Perfil>, IPerfilRepository
    {
        public PerfilReposirotyEF(StoreDbContext ctx) : base(ctx)
        {
        }

        public IEnumerable<Perfil> GetAllWithUsuario()
        {
            return _dbSet.Include(x => x.Usuarios).ToList();
        }

        public async Task<IEnumerable<Perfil>> GetAllWithUsuarioAsync()
        {
            return await _dbSet.Include(x => x.Usuarios).ToListAsync();
        }

        public IEnumerable<Perfil> GetByIds(IEnumerable<int> ids)
        {
            return _dbSet.Where(x => ids.Contains(x.Id)).ToList();
        }

        public async Task<IEnumerable<Perfil>> GetByIdsAsync(IEnumerable<int> ids)
        {
            return await _dbSet.Where(x => ids.Contains(x.Id)).ToListAsync();
        }
    }
}
