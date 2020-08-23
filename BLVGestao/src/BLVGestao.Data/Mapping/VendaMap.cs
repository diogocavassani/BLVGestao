using System;
using BLVGestao.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BLVGestao.Data.Mapping
{
    public class VendaMap : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.HasKey(v => v.VendaId);
            builder.Property(v => v.VendaId).ValueGeneratedOnAdd();
            builder.Property(v => v.Data).HasColumnType("datetime").IsRequired();
            builder.Property(v => v.Total).HasColumnType("decimal(10,2)").IsRequired();
            
            builder.HasOne(u => u.Usuario).WithMany(v => v.Vendas)
                .HasForeignKey(v => v.UsuarioId);
            builder.HasOne(u => u.Cliente).WithMany(v => v.Vendas)
                .HasForeignKey(v => v.ClienteId);
            builder.HasOne(u => u.FormaDePagamento).WithMany(v => v.Vendas)
                .HasForeignKey(v => v.FormaDePagamentoId);

        }
    }
}
