using BLVGestao.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diofab.BLVGestao.Data.Mapping
{
    class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.Property(f => f.RazaoSocial).HasColumnType("varchar(50)").HasMaxLength(50); ;
            builder.Property(f => f.NomeFantasia).HasColumnType("varchar(50)").HasMaxLength(50); ;
        }
    }
}
