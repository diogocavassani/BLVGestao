namespace BLVGestao.Domain.Model
{
    public class Estoque : EntityBase
    {
        public Estoque(int estoqueId, int produtoId, decimal quantidade)

        {
            EstoqueId = estoqueId;
            ProdutoId = produtoId;
            Quantidade = quantidade;
        }
        public int EstoqueId { get; private set; }
        public int ProdutoId { get; private set; }
        public decimal Quantidade { get; private set; }

        public Produto Produto { get; set; }
    }
}
