using System;
using BLVGestao.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BLVGestao.Data.Mapping
{
    public class ItemVendaMap : IEntityTypeConfiguration<ItemVenda>
    {
        public void Configure(EntityTypeBuilder<ItemVenda> builder)
        {
            //builder.HasKey(iv => new { iv.VendaId, iv.ProdutoId });
            builder.HasKey(iv => iv.ItemVendaId);
            builder.HasOne(iv => iv.Venda).WithMany(v => v.ItensVendas).HasForeignKey(iv => iv.VendaId);
            builder.HasOne(iv => iv.Produto).WithMany(p => p.ItensVendas).HasForeignKey(iv => iv.ProdutoId);
        
            builder.Property(iv => iv.Quantidade).HasColumnType("int").IsRequired();
            builder.Property(iv => iv.ValorTotal).HasColumnType("decimal(10,2)").IsRequired();
        }
    }
}
