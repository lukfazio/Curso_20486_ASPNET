using Fazsoft.Store.Domain.Entities;
using Fazsoft.Store.Domain.Enums;
using Fazsoft.Store.Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazsoft.Store.Data.EF
{
    public static class StoreDbSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nome = "Alimento" },
                new Categoria { Id = 2, Nome = "Higiene" },
                new Categoria { Id = 3, Nome = "Vestuário" }
                );
            modelBuilder.Entity<Produto>().HasData(
                 new Produto { Id = 1, Nome = "Picanha Fresca", Preco = 120.99M, CategoriaId = 1 },
                 new Produto { Id = 2, Nome = "Pasta de Dente", Preco = 10.99M, CategoriaId = 2 },
                 new Produto { Id = 3, Nome = "Fralda Pampers", Preco = 180.50M, CategoriaId = 2 },
                 new Produto { Id = 4, Nome = "Tênis Adidas", Preco = 230.00M, CategoriaId = 3 },
                 new Produto { Id = 5, Nome = "Yakult", Preco = 20.19M, CategoriaId = 1 }
                 );
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id = 1, Nome = "Fabiano Nalin", Email = "fabiano.nalin@gmail.com", Senha = "123456".Encrypt(), Genero = Genero.Masculino },
                new Usuario { Id = 2, Nome = "Priscilla Mitui", Email = "priscilla.mitui@gmail.com", Senha = "123456".Encrypt(), Genero = Genero.Feminino },
                new Usuario { Id = 3, Nome = "Raphael Akuy", Email = "rapha.akuy@gmail.com", Senha = "789012".Encrypt(), Genero = Genero.Masculino },
                new Usuario { Id = 4, Nome = "Rafael Pereira", Email = "rafael.pereira@gmail.com", Senha = "123456".Encrypt(), Genero = Genero.Masculino },
                new Usuario { Id = 5, Nome = "Jose Carlos da Silva", Email = "jc.silva@gmail.com", Senha = "123456".Encrypt(), Genero = Genero.Masculino }
                );
            modelBuilder.Entity<Perfil>().HasData(
                new Perfil { Id = 1, Nome = "Administrador" },
                new Perfil { Id = 2, Nome = "Informatica" },
                new Perfil { Id = 3, Nome = "Financeiro" }
                );
        }
    }
}
