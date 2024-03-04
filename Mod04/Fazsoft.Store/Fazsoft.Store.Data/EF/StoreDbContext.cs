using Fazsoft.Store.Data.EF.Maps;
using Fazsoft.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Fazsoft.Store.Data.EF
{
    public class StoreDbContext : DbContext
    {
        private readonly string _connString;

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public StoreDbContext(IConfiguration config)
        {
            _connString = config.GetConnectionString("StoreDbConn");
            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connString);
            optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new PerfilMap());
            modelBuilder.Seed();
        }
    }
}