using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLVGestao.Data.Interfaces;
using BLVGestao.Domain.Model;

namespace BLVGestao.Data.Repositories
{
    public class UsuarioRepositorio : IRepositorioBase<Usuario>, IUsuarioRepositorio
    {
        public Task<IEnumerable<Usuario>> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> ListarPorId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task Inserir(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public Task Alterar(Usuario entity)
        {
            throw new NotImplementedException();
        }
    }
}