using System.Collections.Generic;

namespace BLVGestao.Domain.Model
{
    public class Produto : EntityBase
    {
        public Produto(int produtoId, int fornecedorId, string descricao, string observacao,  string unidade, decimal valorVenda, decimal valorCusto) 
        {
            ProdutoId = produtoId;
            FornecedorId = fornecedorId;
            Descricao = descricao;
            Observacao = observacao;
            Unidade = unidade;
            ValorVenda = valorVenda;
            ValorCusto = valorCusto;
        }

        public Produto()
        {

        }

        public int ProdutoId { get; set; }
        public int FornecedorId { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public string Unidade { get; set; }
        public decimal ValorVenda { get; set; }
        public decimal ValorCusto { get; set; }
        public decimal Quantidade { get; set; }

        public virtual ICollection<ItemVenda> ItensVendas { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public ICollection<Movimentacao> Movimentacao{ get; set; }
    }
}
