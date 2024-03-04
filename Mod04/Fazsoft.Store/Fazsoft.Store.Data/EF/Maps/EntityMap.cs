using Fazsoft.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fazsoft.Store.Data.EF.Maps
{
    public abstract class EntityMap<T> where T : Entity
    {
        protected void Setup(EntityTypeBuilder<T> builder) 
        {
            builder.Property(x => x.DataCadastro)
                   .HasColumnType("datetime2")
                   .IsRequired();

            builder.Property(x => x.DataAlteracao)
                   .HasColumnType("datetime2")
                   .IsRequired();

            builder.Property(x => x.UsuarioId)
                   .HasColumnType("int")
                   .IsRequired();

            //builder.HasOne(x => x.Usuario)
            //       .WithMany(nameof(T));

        }
    }
}