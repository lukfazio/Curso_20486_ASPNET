using Fazsoft.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazsoft.Store.Domain.Contracts.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario GetByIDWithPerfis(int id);
        Task<Usuario> GetByIDWithPerfisAsync(int id);

        IEnumerable<Usuario> GetAllWithPerfis();
        Task<IEnumerable<Usuario>> GetAllWithPerfisAsync();

        Task<Usuario> SignInAsync(string email, string senha);
    }
}
