using BLVGestao.Domain.Model;
using System.Threading.Tasks;

namespace BLVGestao.Data.Interfaces
{
    public interface IEnderecoRepositorio : IRepositorioBase<Endereco>
    {
        Task AlterarEnderecoComPessoa(Endereco endereco);
        Endereco BuscarComInclude(int id);
    }
}
