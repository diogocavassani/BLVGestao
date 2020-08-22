namespace BLVGestao.Domain.Model
{
    public class ItemVenda
    {
        public int VendaId { get; private set; }
        public int ProdutoId { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorTotal { get; private set; }

        public virtual Venda Venda { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
