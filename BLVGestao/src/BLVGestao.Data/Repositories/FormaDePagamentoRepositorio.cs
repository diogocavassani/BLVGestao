using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLVGestao.Data.Interfaces;
using BLVGestao.Domain.Model;

namespace BLVGestao.Data.Repositories
{
    public class FormaDePagamentoRepositorio : IRepositorioBase<FormaDePagamento>, IFormaDePagamentoRepositorio
    {
        public Task<IEnumerable<FormaDePagamento>> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FormaDePagamento>> ListarPorId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task Inserir(FormaDePagamento entity)
        {
            throw new NotImplementedException();
        }

        public Task Alterar(FormaDePagamento entity)
        {
            throw new NotImplementedException();
        }
    }
}