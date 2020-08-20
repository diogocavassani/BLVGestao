using BLVGestao.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BLVGestao.Data.Mapping
{
    class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(c => c.Nome).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
            builder.Property(c => c.DataNascimento).HasColumnType("datetime");
            builder.Property(c => c.Cpf).HasColumnType("varchar(11)").HasMaxLength(11); ;
            builder.Property(c => c.Rg).HasColumnType("varchar(12)").HasMaxLength(12); ;
        }
    }
}
