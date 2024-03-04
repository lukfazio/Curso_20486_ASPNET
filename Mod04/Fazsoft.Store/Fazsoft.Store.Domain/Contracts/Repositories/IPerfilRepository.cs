using Fazsoft.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazsoft.Store.Domain.Contracts.Repositories
{
    public interface IPerfilRepository : IRepository<Perfil>
    {
        IEnumerable<Perfil> GetAllWithUsuario();
        Task<IEnumerable<Perfil>> GetAllWithUsuarioAsync();
        IEnumerable<Perfil> GetByIds(IEnumerable<int> ids);
        Task<IEnumerable<Perfil>> GetByIdsAsync(IEnumerable<int> ids);
    }
}
