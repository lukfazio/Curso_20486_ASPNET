using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazsoft.Store.Domain.Contracts.Data
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
        void RollBack();
    }
}
