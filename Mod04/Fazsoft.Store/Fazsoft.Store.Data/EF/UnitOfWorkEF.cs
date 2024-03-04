using Fazsoft.Store.Domain.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazsoft.Store.Data.EF
{
    public class UnitOfWorkEF : IUnitOfWork
    {
        private readonly StoreDbContext _ctx;

        public UnitOfWorkEF(StoreDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Commit()
        {
            _ctx.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _ctx.SaveChangesAsync();
        }

        public void RollBack()
        {
            return;
        }
    }
}
