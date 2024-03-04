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
    public class ProdutoRepositoryEF : RepositoryEF<Produto>, IProdutoRepository
    {
        public ProdutoRepositoryEF(StoreDbContext ctx) : base(ctx) { }

        public IEnumerable<Produto> GetAllWithCategoria()
        {
            return _dbSet.Include(x => x.Categoria).ToList();
        }

        public async Task<IEnumerable<Produto>> GetAllWithCategoriaAsync()
        {
            return await _dbSet.Include(x => x.Categoria).ToListAsync();
        }

        public Produto GetByNome(string nome)
        {
            return base._dbSet.FirstOrDefault(x => x.Nome == nome);
        }
    }
}
