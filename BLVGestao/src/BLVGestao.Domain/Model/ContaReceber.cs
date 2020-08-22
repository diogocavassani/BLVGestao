using BLVGestao.Domain.Enums;

namespace BLVGestao.Domain.Model
{
    public class ContaReceber : EntityBase
    {
        public ContaReceber(int contaReceberId, int vendaId, int clienteId, decimal valorTotal, StatusEnum status, bool ativo)
            : base(ativo)
        {
            ContaReceberId = contaReceberId;
            VendaId = vendaId;
            ClienteId = clienteId;
            ValorTotal = valorTotal;
            Status = status;  
        }
        public int ContaReceberId { get; private set; }
        public int VendaId { get; private set; }
        public int ClienteId { get; private set; }
        public decimal ValorTotal { get; private set; }
        public StatusEnum Status { get; private set; }

        public Venda Venda { get; set; }
        public Cliente Cliente { get; set; }
    }
}
