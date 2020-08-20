using BLVGestao.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BLVGestao.Data.Mapping
{
    class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Logradouro).HasColumnType("varchar(30)").HasMaxLength(30); ;
            builder.Property(e => e.Numero).HasColumnType("varchar(10)").HasMaxLength(10); ;
            builder.Property(e => e.Bairro).HasColumnType("varchar(30)").HasMaxLength(30); ;

            //TODO: Relacionamento
            builder.HasOne(p => p.Pessoa).WithMany(e => e.Endereco)
                .HasForeignKey(e => e.PessoaId).HasPrincipalKey(e => e.Id);

            builder.ToTable("Endereco");
        }
    }
}
