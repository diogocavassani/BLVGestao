using System.Collections.Generic;

namespace BLVGestao.Domain.Model
{
    public class FormaDePagamento : EntityBase
    {
        public FormaDePagamento(int formaDePagamentoId, string descricao, int prazoRecebimento)
        {
            FormaDePagamentoId = formaDePagamentoId;
            Descricao = descricao;
            PrazoRecebimento = prazoRecebimento;
        }
        public FormaDePagamento()
        {

        }
        public int FormaDePagamentoId { get; set; }
        public string Descricao { get; set; }
        public int PrazoRecebimento { get; set; }

        public virtual ICollection<Venda> Vendas { get; set; }
    }
}
