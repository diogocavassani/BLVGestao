using System;
using BLVGestao.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BLVGestao.Data.Mapping
{
    public class ContaReceberMap : IEntityTypeConfiguration<ContaReceber>
    {
        public void Configure(EntityTypeBuilder<ContaReceber> builder)
        {
            builder.HasKey(cr => cr.ContaReceberId);
            builder.Property(cr => cr.ContaReceberId).ValueGeneratedOnAdd();
            builder.Property(cr => cr.ValorTotal).HasColumnType("decimal").IsRequired();
            builder.Property(cr => cr.Status).IsRequired();

            builder.HasOne(v => v.Venda).WithMany(cr => cr.ContasReceber)
                .HasForeignKey(cr => cr.ContaReceberId);
            builder.HasOne(c => c.Cliente).WithOne(cr => cr.ContaReceber);

            builder.ToTable(nameof(ContaReceber));
        }
    }
}
