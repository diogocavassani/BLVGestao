using BLVGestao.Domain.Enums;

namespace BLVGestao.Domain.Model
{
    public class ContaReceber
    {
        public int ContaReceberId { get; set; }
        public int VendaId { get; set; }
        public int ClienteId { get; set; }
        public decimal ValorTotal { get; set; }
        public StatusEnum Status { get; set; }
    }
}
