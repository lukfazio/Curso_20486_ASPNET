using CadCli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadCli.Core.Contracts
{
    public interface IRepository
    {
        void Add(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(Cliente cliente);
        List<Cliente> Get();
        Cliente Get(int id);
    }
}
