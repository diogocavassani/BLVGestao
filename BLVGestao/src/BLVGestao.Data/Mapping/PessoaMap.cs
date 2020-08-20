using BLVGestao.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diofab.BLVGestao.Data.Mapping
{
    class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {

            builder.HasKey(i => i.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Ativo).HasColumnType("bool");


        }
    }
}
