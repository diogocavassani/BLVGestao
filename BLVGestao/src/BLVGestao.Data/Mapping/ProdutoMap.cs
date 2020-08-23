using BLVGestao.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diofab.BLVGestao.Data.Mapping
{
    class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(d => d.Descricao).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired(); 
            builder.Property(u => u.Unidade).HasColumnType("varchar(3)").HasMaxLength(3).IsRequired(); ;
            builder.Property(vv => vv.ValorVenda).HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(vc => vc.ValorCusto).HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(a => a.Ativo).HasColumnType("bool");

            builder.HasOne(p => p.Fornecedor).WithMany(f => f.Produtos)
                .HasForeignKey(p => p.FornecedorId);

            builder.ToTable(nameof(Produto));


        }
    }
}
