using System.Collections.Generic;
using System.Threading.Tasks;
using BLVGestao.Domain.Model;

namespace BLVGestao.Data.Interfaces
{
    public interface IClienteRepositorio : IRepositorioBase<Cliente>
    {
        Task<IEnumerable<Cliente>> ConsultarPorNome(string nome);
        Task<IEnumerable<Cliente>> ConsultarPorCpf(string cpf);
    }
}
