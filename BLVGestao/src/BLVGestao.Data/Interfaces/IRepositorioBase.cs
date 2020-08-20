using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLVGestao.Data.Interfaces
{
    public interface IRepositorioBase<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> ListarTodos();
        Task<IEnumerable<TEntity>> ListarPorId(int Id);
        Task Inserir(TEntity entity);
        Task Alterar(TEntity entity);

    }
}
