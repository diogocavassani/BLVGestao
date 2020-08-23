using System;
using BLVGestao.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BLVGestao.Data.Mapping
{
    public class MovimentacaoMap : IEntityTypeConfiguration<Movimentacao>
    {
        public void Configure(EntityTypeBuilder<Movimentacao> builder)
        {
            builder.HasKey(m => m.MovimentacaoId);
            builder.Property(m => m.MovimentacaoId).ValueGeneratedOnAdd();
            builder.Property(m => m.Data).HasColumnType("datetime").IsRequired();

            builder.HasOne(m => m.Produto).WithMany(p => p.Movimentacao)
                .HasForeignKey(m => m.ProdutoId);

        }
    }
}
