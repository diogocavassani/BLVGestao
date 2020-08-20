namespace BLVGestao.Domain.Model
{
    public class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Unidade { get; set; }
        public int Quantidade { get; set; }
        public float ValorVenda { get; set; }
        public float ValorCusto { get; set; }
        public bool Ativo { get; set; } = true;
    }
}
