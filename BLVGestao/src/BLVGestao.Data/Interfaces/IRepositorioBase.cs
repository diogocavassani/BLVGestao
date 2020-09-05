using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLVGestao.Data.Interfaces
{
    public interface IRepositorioBase<T> : IDisposable
    {
        Task<ICollection<T>> ListarTodos();
        Task<T> ListarPorId(int id);
        Task Inserir(T entity);
        Task Alterar(T entity);
         //Task Inativar(T entity);


    }
}
