namespace BLVGestao.Domain.Model
{
    public class Estoque
    {
        public int EstoqueId { get; set; }
        public int ProdutoId { get; set; }
        public decimal Quantidade { get; set; }
    }
}
