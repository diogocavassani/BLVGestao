using BLVGestao.Data.Interfaces;
using BLVGestao.Data.ORM;
using BLVGestao.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLVGestao.Data.Repositories
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly Context _context;
        public ClienteRepositorio(Context context)
        {
            _context = context;
        }

        async public Task<ICollection<Cliente>> ListarTodos()
        {
            return await _context.Clientes.Where(c => c.Ativo == true).AsNoTracking().ToListAsync();
        }

        async public Task<Cliente> ListarPorId(int id)
        {
            return await _context.Clientes.AsNoTracking().FirstOrDefaultAsync(c => c.PessoaId == id);
        }

        async public Task Inserir(Cliente cliente)
        {
             _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }

        async public Task Alterar(Cliente cliente)
        {
              _context.Update(cliente);
            await _context.SaveChangesAsync();
        }

        async public Task<ICollection<Cliente>> ConsultarPorNome(string nome)
        {
            return await _context.Clientes.Where(c => c.Nome == nome).AsNoTracking().ToListAsync();
        }

        async public Task<Cliente> ConsultarPorCpf(string cpf)
        {
            return await _context.Clientes.AsNoTracking().FirstOrDefaultAsync(c => c.Cpf == cpf);
        }

        async public Task Inativar(Cliente cliente)
        {
            cliente.Inativar();
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        


    }
}