using BLVGestao.Domain.Enums;
using BLVGestao.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLVGestao.Data.Interfaces
{
    public interface IVendaRepositorio :IRepositorioBase<Venda>
    {
        Task<ICollection<Venda>> ConsultarPorCliente(string nome);
        
        Task<ICollection<Venda>> ConsultarPorData(string datainicial, string datafinal);
        Task<bool> InserirVenda(Venda venda);
        Task AlterarVenda(Venda venda);
        Task<ICollection<Venda>> BuscarVendas();
        Task<Venda> BuscarPorIdCompleto(int id);
        Task<ICollection<Venda>> BuscarPorFormaPagamento(int formaPagamentoId);

        Task<ICollection<Venda>> BuscarPorProduto(string produto);
        Task<ICollection<Venda>> BuscarPorSituacao(SituacaoVendaEnum stiaucao);
    }
}
