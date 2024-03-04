using CadCli.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CadCli.Core.Data.EF
{
    public class CadCliDbContext : DbContext
    {
        private string _connString;

        public CadCliDbContext(IConfiguration config)
        {
            _connString = config.GetConnectionString("CadCliConn");
            base.Database.EnsureCreated();
        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase("cadcli");
            optionsBuilder.UseSqlServer(_connString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { Id = 1, Nome = "Fabio", Idade = 42 },
                new Cliente { Id = 2, Nome = "Raphael", Idade = 22 },
                new Cliente { Id = 3, Nome = "Priscilla", Idade = 43 },
                new Cliente { Id = 4, Nome = "Lucio", Idade = 27 },
                new Cliente { Id = 5, Nome = "Maria", Idade = 26 }
                );
        }
    }
}
