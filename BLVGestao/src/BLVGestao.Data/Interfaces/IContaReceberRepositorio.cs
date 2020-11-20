using BLVGestao.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLVGestao.Data.Interfaces
{
    public interface IContaReceberRepositorio : IRepositorioBase<ContaReceber>
    {
        Task<ICollection<ContaReceber>> ConsultarPorData(string data);
        Task<ICollection<ContaReceber>> ConsultarPorVencimento(string data);
        Task<ICollection<ContaReceber>> ConsultarPorCodigoCliente(int id);
        Task<ICollection<ContaReceber>> ConsultarPorCliente(string nome);
    }
}
