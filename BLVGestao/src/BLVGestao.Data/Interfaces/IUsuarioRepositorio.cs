using BLVGestao.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLVGestao.Data.Interfaces
{
    public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
    {
        Task<ICollection<Usuario>> ListarAtivos();
    }
}
