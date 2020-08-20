using BLVGestao.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diofab.BLVGestao.Data.Mapping
{
    class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(d => d.Descricao).HasColumnType("varchar(50)").HasMaxLength(50); ;
            builder.Property(u => u.Unidade).HasColumnType("varchar(3)").HasMaxLength(3); ;
            builder.Property(vv => vv.ValorVenda).HasColumnType("decimal");
            builder.Property(vc => vc.ValorCusto).HasColumnType("decimal");
            builder.Property(a => a.Ativo).HasColumnType("bool");


        }
    }
}
