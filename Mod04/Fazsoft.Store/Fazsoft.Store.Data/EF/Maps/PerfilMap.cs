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
    public class PerfilMap : EntityMap<Perfil>, IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.ToTable("Perfil") //Table
                   .HasKey(x => x.Id); //PK

            builder.Property(x => x.Nome)
                   .HasColumnType("varchar(50)")//.HasMaxLength(50)
                   .IsRequired();


            builder.HasOne(x => x.Usuario)
                   .WithMany(x => x.PerfisAtualizado)
                   .HasForeignKey(x => x.UsuarioId)
                   .OnDelete(DeleteBehavior.Restrict);


            base.Setup(builder);
        }

    }
}
