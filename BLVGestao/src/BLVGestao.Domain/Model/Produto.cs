using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLVGestao.Domain.Model
{
    public class Produto : EntityBase
    {
        //public Produto(int produtoId, int fornecedorId, string descricao, string observacao,  string unidade, decimal valorVenda, decimal valorCusto) 
        //{
        //    ProdutoId = produtoId;
        //    FornecedorId = fornecedorId;
        //    Descricao = descricao;
        //    Observacao = observacao;
        //    Unidade = unidade;
        //    ValorVenda = valorVenda;
        //    ValorCusto = valorCusto;
        //}

        public Produto()
        {

        }

        public int ProdutoId { get; set; }
        public int FornecedorId { get; set; }
        [MaxLength(50, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        [MaxLength(3, ErrorMessage = "Este campo deve conter entre 1 e 3 caracteres")]
        [MinLength(1, ErrorMessage = "Este campo deve conter entre 1 e 3 caracteres")]
        public string Unidade { get; set; }
        public float ValorVenda { get; set; }
        public decimal ValorCusto { get; set; }
        public decimal Quantidade { get; set; }
        public DateTime Validade { get; set; }
        public virtual ICollection<ItemVenda> ItensVendas { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public ICollection<Movimentacao> Movimentacao{ get; set; }
    }
}
