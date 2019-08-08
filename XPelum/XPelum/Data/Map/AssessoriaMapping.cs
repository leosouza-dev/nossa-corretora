using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XPelum.Models;

namespace XPelum.Data.Map
{
    public class AcessoriaMapping : IEntityTypeConfiguration<Assessoria>
    {
        public void Configure(EntityTypeBuilder<Assessoria> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Investimento)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.Property(p => p.Imagem)
                .IsRequired();
        }
    }
}
