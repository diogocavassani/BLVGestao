using BLVGestao.Domain.Model;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLVGestao.Data.Interfaces
{
    public interface IFormaDePagamentoRepositorio : IRepositorioBase<FormaDePagamento>
    {
        Task<ICollection<FormaDePagamento>> ListarAtivos();
    }
}
