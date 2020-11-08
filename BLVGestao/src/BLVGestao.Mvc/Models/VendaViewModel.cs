using BLVGestao.Domain.Enums;
using BLVGestao.Domain.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace BLVGestao.Mvc.Models
{
    public class VendaViewModel
    {
        public Cliente Cliente { get; set; }
        public ICollection<Cliente> ListaCliente { get; set; }
        public Produto Produto { get; set; }
        public ICollection<Produto> ListaProduto { get; set; }
        public decimal Quantidade { get; set; }
        public ICollection<ItemVenda> ItemVenda { get; set; }
        public FormaDePagamento FormaDePagamento { get; set; }
        public ICollection<FormaDePagamento> ListaFormaDePagamento { get; set; }
        public decimal ValorPagamento { get; set; }
        public decimal TrocoPagamento { get; set; }



    }
}
