using System.Collections.Generic;
using System.Threading.Tasks;
using BLVGestao.Domain.Model;

namespace BLVGestao.Data.Interfaces
{
    public interface IClienteRepositorio : IRepositorioBase<Cliente>
    {
        Task<ICollection<Cliente>> ConsultarPorNome(string nome);
        Task<Cliente> ConsultarPorCpf(string cpf);
    }
}
