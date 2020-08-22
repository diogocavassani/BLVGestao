namespace BLVGestao.Domain.Model
{
    public class FormaDePagamento : EntityBase
    {
        public FormaDePagamento(int formaDePagamentoId, string descricao, int prazoRecebimento, bool ativo) 
            : base(ativo)
        {
            FormaDePagamentoId = formaDePagamentoId;
            Descricao = descricao;
            PrazoRecebimento = prazoRecebimento;
        }

        public int FormaDePagamentoId { get; private set; }
        public string Descricao { get; private set; }
        public int PrazoRecebimento { get; private set; }
    }
}
