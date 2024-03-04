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
    public class CategoriaRepositoryEF : RepositoryEF<Categoria>, ICategoriaRepository
    {
        public CategoriaRepositoryEF(StoreDbContext ctx) : base(ctx)
        {
        }

        public async Task<int> CountProdAsync(int categoriaId)
        {
            //return await _dbSet.Include(x => x.Produtos).CountAsync(x => x.Id == categoriaId);
            return (await _dbSet.Include(x => x.Produtos)
                        .FirstOrDefaultAsync(cat => cat.Id == categoriaId))
                        .Produtos.Count();

        }

        public async Task<IEnumerable<Categoria>> GetAllWithProdutos()
        {
            return await _dbSet.Include(x => x.Produtos).ToListAsync();
        }
    }
}
