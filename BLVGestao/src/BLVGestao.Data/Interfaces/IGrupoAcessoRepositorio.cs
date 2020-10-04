using BLVGestao.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLVGestao.Data.Interfaces
{
    public interface IGrupoAcessoRepositorio :  IRepositorioBase<GrupoAcesso>
    {
        Task<ICollection<GrupoAcesso>> ListarAtivos();
    }
}
