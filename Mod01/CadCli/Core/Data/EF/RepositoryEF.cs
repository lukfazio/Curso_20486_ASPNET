using CadCli.Core.Contracts;
using CadCli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadCli.Core.Data.EF
{
    public class RepositoryEF : IRepository
    {
        private readonly CadCliDbContext _ctx;

        public RepositoryEF(CadCliDbContext ctx)
        {
            _ctx = ctx;
        }

        public List<Cliente> Get()
        {
            return _ctx.Clientes.ToList();
        }

        public Cliente Get(int id)
        {
            return _ctx.Clientes.Find(id);
        }              

        public void Add(Cliente cliente)
        {
            _ctx.Clientes.Add(cliente);
            _ctx.SaveChanges();
        }

        public void Delete(Cliente cliente)
        {
            _ctx.Clientes.Remove(cliente);
            _ctx.SaveChanges();
        }
        
        public void Update(Cliente cliente)
        {
            _ctx.Clientes.Update(cliente);
            _ctx.SaveChanges();
        }
    }
}
