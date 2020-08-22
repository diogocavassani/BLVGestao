using System;
using BLVGestao.Domain.Enums;

namespace BLVGestao.Domain.Model
{
    //TODO:Verificar esta classe
    public class Movimentacao : EntityBase
    {
        public Movimentacao(int movimentacaoId, int produtoId, TipoMovimentoEnum tipoMovimento, DateTime data, bool ativo) 
            : base(ativo)
        {
            MovimentacaoId = movimentacaoId;
            ProdutoId = produtoId;
            TipoMovimento = tipoMovimento;
            Data = data;
        }

        public int MovimentacaoId { get; private set; }
        public int ProdutoId { get; private set; }
        public TipoMovimentoEnum TipoMovimento { get; private set; }
        public DateTime Data { get; private set; }



    }
}
