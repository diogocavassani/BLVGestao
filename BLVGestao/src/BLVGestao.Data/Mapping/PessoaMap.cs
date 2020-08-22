using BLVGestao.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diofab.BLVGestao.Data.Mapping
{
    class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(i => i.PessoaId);
            builder.Property(p => p.PessoaId).ValueGeneratedOnAdd();
            builder.Property(a => a.Ativo).HasColumnType("bool");

            builder.ToTable(nameof(Pessoa));
        }
    }
}
