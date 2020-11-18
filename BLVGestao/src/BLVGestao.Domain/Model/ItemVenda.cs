namespace BLVGestao.Domain.Model
{
    public class ItemVenda : EntityBase
    {
        //public ItemVenda(int vendaId, int produtoId, decimal quantidade, decimal valorTotal) 

        //{
        //    VendaId = vendaId;
        //    ProdutoId = produtoId;
        //    Quantidade = quantidade;
        //    ValorTotal = valorTotal;
        //}

        public ItemVenda()
        {

        }
        public int ItemVendaId { get; set; }
        public int VendaId { get; set; }
        public int ProdutoId { get; set; }
        public float Quantidade { get; set; }
        public float ValorTotal { get; set; }

        public virtual Venda Venda { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
