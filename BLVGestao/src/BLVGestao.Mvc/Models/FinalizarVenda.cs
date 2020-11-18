using BLVGestao.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLVGestao.Mvc.Models
{
    public class FinalizarVenda
    {
        public Cliente Cliente { get; set; }
        public IList<ItemVenda> ItensVenda { get; set; }
        public FormaDePagamento FromaDePagamento { get; set; }
        public float ValorPagamento { get; set; }

    }
}
