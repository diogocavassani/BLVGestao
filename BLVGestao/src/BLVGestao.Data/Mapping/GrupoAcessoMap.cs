using System;
using BLVGestao.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BLVGestao.Data.Mapping
{
    public class GrupoAcessoMap : IEntityTypeConfiguration<GrupoAcesso>
    {
        public void Configure(EntityTypeBuilder<GrupoAcesso> builder)
        {
            builder.HasKey(ga => ga.GrupoAcessoId);
            builder.Property(ga => ga.GrupoAcessoId).ValueGeneratedOnAdd();
            builder.Property(ga => ga.Descricao).HasColumnType("varchar(50)").IsRequired();
            builder.Property(ga => ga.Permissao).HasColumnType("varchar(50)").IsRequired();
            
            builder.ToTable(nameof(GrupoAcesso));
        }
    }
}
