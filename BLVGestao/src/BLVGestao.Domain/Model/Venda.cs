using System;
using System.Collections.Generic;
using System.Text;

namespace BLVGestao.Domain.Model
{
    public class Venda
    {
        public int VendaId { get; set; }
        public DateTime Data { get; set; }
        public Cliente Cliente { get; set; }
        public decimal Total { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<ItemVenda> VendaItens { get; set; }
        public FormaDePagamento FormaDePagamento { get; set; }
        public Usuario Usuario { get; set; }
       
    }
}
