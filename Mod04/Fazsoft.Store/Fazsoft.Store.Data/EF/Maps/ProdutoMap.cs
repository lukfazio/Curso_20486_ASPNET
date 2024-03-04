using Fazsoft.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazsoft.Store.Data.EF.Maps
{
    public class ProdutoMap : EntityMap<Produto>, IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto") //Table
                   .HasKey(x => x.Id); //PK

            builder.Property(x => x.Nome)
                   .HasColumnName("NomeCompleto")
                   .HasColumnType("varchar(50)")//.HasMaxLength(50)
                   .IsRequired();

            builder.Property(x => x.Preco)
                   .HasColumnType("money")
                   .IsRequired();

            builder.Property(x => x.CategoriaId)
                   .HasColumnType("int")
                   .IsRequired();

            builder.HasOne(x => x.Categoria)
                   .WithMany(x => x.Produtos)
                   .HasForeignKey(x => x.CategoriaId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Usuario)
                   .WithMany(x => x.Produtos)
                   .HasForeignKey(x => x.UsuarioId)
                   .OnDelete(DeleteBehavior.Restrict);


            base.Setup(builder);
        }
    }
}
