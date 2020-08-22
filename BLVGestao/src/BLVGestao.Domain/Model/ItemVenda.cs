namespace BLVGestao.Domain.Model
{
    public class ItemVenda : EntityBase
    {
        public ItemVenda(int vendaId, int produtoId, decimal quantidade, decimal valorTotal, bool ativo) 
            : base(ativo)
        {
            VendaId = vendaId;
            ProdutoId = produtoId;
            Quantidade = quantidade;
            ValorTotal = valorTotal;
        }

        public int VendaId { get; private set; }
        public int ProdutoId { get; private set; }
        public decimal Quantidade { get; private set; }
        public decimal ValorTotal { get; private set; }

        public virtual Venda Venda { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
