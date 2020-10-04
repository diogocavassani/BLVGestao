using BLVGestao.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLVGestao.Data.Interfaces
{
    public interface IProdutoRepositorio : IRepositorioBase<Produto>
    {
        Task<ICollection<Produto>> ListarAtivos();
    }
}
