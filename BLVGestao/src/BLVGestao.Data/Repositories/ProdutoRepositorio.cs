using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLVGestao.Data.Interfaces;
using BLVGestao.Domain.Model;

namespace BLVGestao.Data.Repositories
{
    public class ProdutoRepositorio : IRepositorioBase<Produto>, IProdutoRepositorio
    {
        public Task<IEnumerable<Produto>> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Produto>> ListarPorId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task Inserir(Produto entity)
        {
            throw new NotImplementedException();
        }

        public Task Alterar(Produto entity)
        {
            throw new NotImplementedException();
        }
    }
}