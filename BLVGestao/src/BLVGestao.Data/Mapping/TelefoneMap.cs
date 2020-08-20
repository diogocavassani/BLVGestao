using BLVGestao.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diofab.BLVGestao.Data.Mapping
{
    class TelefoneMap : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();
            builder.Property(n => n.Numero).HasColumnType("varchar(13)").HasMaxLength(13); ;

            builder.HasOne(p => p.Pessoa).WithMany(t => t.Telefone)
                .HasForeignKey(p => p.PessoaId).HasPrincipalKey(t => t.Id);

            builder.ToTable("Telefone");
        }
    }
}
