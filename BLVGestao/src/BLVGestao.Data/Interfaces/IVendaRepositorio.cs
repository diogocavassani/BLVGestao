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
        
        Task<ICollection<Venda>> ConsultarPorData(string data);
        Task InserirVenda(Venda venda);
        Task AlterarVenda(Venda venda);
        Task<ICollection<Venda>> BuscarVendas();
        Task<Venda> BuscarPorIdCompleto(int id);
    }
}
