using BLVGestao.Data.Interfaces;
using BLVGestao.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLVGestao.Data.Repositories
{
    public class ClienteRepositorio : IRepositorioBase<Cliente>, IClienteRepositorio
    {
        public Task<IEnumerable<Cliente>> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cliente>> ListarPorId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task Inserir(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public Task Alterar(Cliente entity)
        {
            throw new NotImplementedException();
        }

    }
}
