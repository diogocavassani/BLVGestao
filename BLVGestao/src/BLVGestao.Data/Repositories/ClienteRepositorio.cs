using BLVGestao.Data.Interfaces;
using BLVGestao.Data.ORM;
using BLVGestao.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLVGestao.Data.Repositories
{
    public class ClienteRepositorio : IRepositorioBase<Cliente>, IClienteRepositorio
    {
        private readonly Context _context;
        public ClienteRepositorio(Context context)
        {
            _context = context;
        }

        public Task Alterar(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cliente>> ConsultarPorCpf(string cpf)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cliente>> ConsultarPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public Task Inserir(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cliente>> ListarPorId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cliente>> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
