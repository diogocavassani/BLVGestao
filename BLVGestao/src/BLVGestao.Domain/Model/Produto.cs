using System.Collections.Generic;

namespace BLVGestao.Domain.Model
{
    public class Produto : EntityBase
    {
        public Produto(int produtoId, int fornecedorId, string descricao, string observacao,  string unidade, decimal valorVenda, decimal valorCusto, bool ativo) 
            : base(ativo)
        {
            ProdutoId = produtoId;
            FornecedorId = fornecedorId;
            Descricao = descricao;
            Observacao = observacao;
            Unidade = unidade;
            ValorVenda = valorVenda;
            ValorCusto = valorCusto;
        }

        public int ProdutoId { get; private set; }
        public int FornecedorId { get; private set; }
        public string Descricao { get; private set; }
        public string Observacao { get; private set; }
        public string Unidade { get; private set; }
        public decimal ValorVenda { get; private set; }
        public decimal ValorCusto { get; private set; }

        public virtual ICollection<ItemVenda> ItemVenda { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}
