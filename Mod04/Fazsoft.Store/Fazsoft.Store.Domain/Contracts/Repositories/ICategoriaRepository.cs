using Fazsoft.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazsoft.Store.Domain.Contracts.Repositories
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Task<int> CountProdAsync(int categoriaId);

        Task<IEnumerable<Categoria>> GetAllWithProdutos();
    }
}
