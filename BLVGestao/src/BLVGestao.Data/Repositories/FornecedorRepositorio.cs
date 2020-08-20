using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLVGestao.Data.Interfaces;
using BLVGestao.Domain.Model;

namespace BLVGestao.Data.Repositories
{
    public class FornecedorRepositorio : IRepositorioBase<Fornecedor>, IFornecedorRepositorio
    {
        public Task<IEnumerable<Fornecedor>> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Fornecedor>> ListarPorId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task Inserir(Fornecedor entity)
        {
            throw new NotImplementedException();
        }

        public Task Alterar(Fornecedor entity)
        {
            throw new NotImplementedException();
        }
    }
}