using Fazsoft.Store.Domain.Contracts.Repositories;
using Fazsoft.Store.Domain.Entities;
using Fazsoft.Store.Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazsoft.Store.Data.EF.Repositories
{
    public class UsuarioRepositoryEF : RepositoryEF<Usuario>, IUsuarioRepository
    {
        public UsuarioRepositoryEF(StoreDbContext ctx) : base(ctx)
        {
        }

        public IEnumerable<Usuario> GetAllWithPerfis()
        {
            return _dbSet.Include(x => x.Perfis).ToList();
        }

        public async Task<IEnumerable<Usuario>> GetAllWithPerfisAsync()
        {
            return await _dbSet.Include(x => x.Perfis).ToListAsync();
        }

        public Usuario GetByIDWithPerfis(int id)
        {
            return _dbSet.Include(x => x.Perfis).FirstOrDefault(x => x.Id == id);
        }

        public async Task<Usuario> GetByIDWithPerfisAsync(int id)
        {
            return await _dbSet.Include(x => x.Perfis).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Usuario> SignInAsync(string email, string senha)
        {
            return await _dbSet.Include(x => x.Perfis).FirstOrDefaultAsync(x => x.Email == email && x.Senha == senha.Encrypt());
        }
    }
}
