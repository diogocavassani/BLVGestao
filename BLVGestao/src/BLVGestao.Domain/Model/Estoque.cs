namespace BLVGestao.Domain.Model
{
    public class Estoque : EntityBase
    {
        public Estoque(int estoqueId, int produtoId, decimal quantidade, bool ativo)
            : base(ativo)
        {
            EstoqueId = estoqueId;
            ProdutoId = produtoId;
            Quantidade = quantidade;
        }
        public int EstoqueId { get; private set; }
        public int ProdutoId { get; private set; }
        public decimal Quantidade { get; private set; }
    }
}
