using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLVGestao.Data.Interfaces
{
    public interface IRepositorioBase<TEntity> : IDisposable
    {
        Task<ICollection<TEntity>> ListarTodos();
        Task<TEntity> ListarPorId(int id);
        Task Inserir(TEntity entity);
        Task Alterar(TEntity entity);
        Task Inativar(TEntity entity);


    }
}
