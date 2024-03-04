using CadCli.Core.Contracts;
using CadCli.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadCli.Core.Data.ADO
{
    public class RepositoryADO : IRepository
    {
        private readonly string _stringConn;

        public RepositoryADO(IConfiguration config)
        {
            _stringConn = config.GetConnectionString("CadCliConn");
        }


        public List<Cliente> Get()
        {
            var clientes = new List<Cliente>();

            using (var conn = new SqlConnection(_stringConn))
            {
                conn.Open();

                var query = "SELECT Id, Nome, Idade FROM cliente;";

                var command = new SqlCommand(query, conn);
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        clientes.Add(new Cliente
                        {
                            Id = (int) dataReader["Id"],
                            Nome = dataReader["Nome"].ToString(),
                            Idade = (int) dataReader["Idade"]
                        });
                    }
                }                

                conn.Close();
            }

            return clientes;
        }

        public Cliente Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void Delete(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void Update(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
