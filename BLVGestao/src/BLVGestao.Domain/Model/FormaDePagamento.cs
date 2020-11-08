using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [MaxLength(50, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        public string Descricao { get; set; }
        public int PrazoRecebimento { get; set; }

        public virtual ICollection<Venda> Vendas { get; set; }
    }
}
