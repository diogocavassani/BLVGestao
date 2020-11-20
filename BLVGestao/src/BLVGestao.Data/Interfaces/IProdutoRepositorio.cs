using BLVGestao.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLVGestao.Data.Interfaces
{
    public interface IProdutoRepositorio : IRepositorioBase<Produto>
    {
        Task<ICollection<Produto>> ListarAtivos();
        Task<ICollection<Produto>> ListarPorFornecedor(int fornecedorId);
        Task<ICollection<Produto>> ListarPorValidade();
        Task<ICollection<Produto>> ListarPorNome(string descricao);
        Task<ICollection<Produto>> ListarPorStatus(bool status);
    }
}
