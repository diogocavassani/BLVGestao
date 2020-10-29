using System;
using System.Collections.Generic;
using System.Text;
using BLVGestao.Domain.Enums;

namespace BLVGestao.Domain.Model
{
    public class Venda
    {
        public Venda(int vendaId, int clienteId, int usuarioId, int formaDePagamentoId, DateTime data, decimal total, SituacaoVendaEnum situacao)
        {
            VendaId = vendaId;
            ClienteId = clienteId;
            UsuarioId = usuarioId;
            FormaDePagamentoId = formaDePagamentoId;
            Data = data;
            Total = total;
            Situacao = situacao;
        }
        public int VendaId { get; private set; }
        public int ClienteId { get; private set; }
        public int UsuarioId { get; private set; }
        public int FormaDePagamentoId { get; private set; }
        public DateTime Data { get; private set; }
        public decimal Total { get; private set; }
        public SituacaoVendaEnum Situacao { get; private set; }
        public void Inativar()
        {
            this.Situacao = SituacaoVendaEnum.Cancelada;
        }
        public void Ativar()
        {
            this.Situacao = SituacaoVendaEnum.Confirmada;
        }

        public Usuario Usuario { get; set; }
        public Cliente Cliente { get; set; }
        public FormaDePagamento FormaDePagamento { get; set; }
        public virtual ICollection<ItemVenda> ItensVendas { get; set; }
        public virtual ICollection<ContaReceber> ContasReceber { get; set; }
       
    }
}
