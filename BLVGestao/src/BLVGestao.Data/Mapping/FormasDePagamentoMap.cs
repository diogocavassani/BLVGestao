﻿using BLVGestao.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diofab.BLVGestao.Data.Mapping
{
    class FormaDePagamentoMap : IEntityTypeConfiguration<FormaDePagamento>
    {
        public void Configure(EntityTypeBuilder<FormaDePagamento> builder)
        {
            builder.HasKey(fp => fp.FormaDePagamentoId);
            builder.Property(fp => fp.FormaDePagamentoId).ValueGeneratedOnAdd();
            builder.Property(fp => fp.Descricao).HasColumnType("varchar(50)").HasMaxLength(50);
            builder.Property(fp => fp.PrazoRecebimento).HasColumnType("int");
        }
    }
}
