using Fazsoft.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazsoft.Store.Domain.Contracts.Repositories
{
    public interface IProdutoRepository  : IRepository<Produto> 
    {
        Produto GetByNome(string nome);

        IEnumerable<Produto> GetAllWithCategoria();
        Task<IEnumerable<Produto>> GetAllWithCategoriaAsync();
    }
}
