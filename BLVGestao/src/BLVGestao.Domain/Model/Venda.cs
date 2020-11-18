using System;
using System.Collections.Generic;
using System.Text;
using BLVGestao.Domain.Enums;

namespace BLVGestao.Domain.Model
{
    public class Venda
    {
        public Venda(int vendaId, int clienteId, int usuarioId, int formaDePagamentoId, DateTime data, float total, SituacaoVendaEnum situacao)
        {
            VendaId = vendaId;
            ClienteId = clienteId;
            UsuarioId = usuarioId;
            FormaDePagamentoId = formaDePagamentoId;
            Data = data;
            Total = total;
            Situacao = situacao;
        }
        public Venda()
        {
            Situacao = SituacaoVendaEnum.Confirmada;
        }
        
        public int VendaId { get; set; }
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public int FormaDePagamentoId { get; set; }
        public DateTime Data { get; set; }
        public float Total { get; set; }
        public float ValorPagamento { get; set; }
        public SituacaoVendaEnum Situacao { get; set; }
        public void Cancelar()
        {
            this.Situacao = SituacaoVendaEnum.Cancelada;
        }
       

        public Usuario Usuario { get; set; }
        public Cliente Cliente { get; set; }
        public FormaDePagamento FormaDePagamento { get; set; }
        public virtual ICollection<ItemVenda> ItensVendas { get; set; }
        public virtual ICollection<ContaReceber> ContasReceber { get; set; }
       
    }
}
