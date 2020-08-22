using System;
using BLVGestao.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BLVGestao.Data.Mapping
{
    public class EstoqueMap : IEntityTypeConfiguration<Estoque>
    {
        public void Configure(EntityTypeBuilder<Estoque> builder)
        {
            builder.HasKey(e => e.EstoqueId);
            builder.Property(e => e.EstoqueId).ValueGeneratedOnAdd();
            builder.Property(e => e.Quantidade).HasColumnType("decimal").IsRequired();
            builder.ToTable(nameof(Estoque));
        }
    }
}
