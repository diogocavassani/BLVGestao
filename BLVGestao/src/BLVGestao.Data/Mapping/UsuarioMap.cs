﻿using BLVGestao.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diofab.BLVGestao.Data.Mapping
{
    internal class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.UsuarioId);
            builder.Property(u => u.UsuarioId).ValueGeneratedOnAdd();
            builder.Property(l => l.Login).HasColumnType("varchar(20)").HasMaxLength(20); ;
            builder.Property(s => s.Senha).HasColumnType("varchar(20)").HasMaxLength(20); ;
            builder.Property(a => a.Ativo).HasColumnType("bool");

            builder.HasOne(ga => ga.GrupoAcesso).WithMany(u => u.Usuarios)
                .HasForeignKey(ga => ga.GrupoAcessoId);
        }
    }
}