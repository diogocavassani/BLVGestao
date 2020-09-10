using BLVGestao.Data.Interfaces;
using BLVGestao.Data.ORM;
using BLVGestao.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLVGestao.Data.Repositories
{
    public class ClienteRepositorio : RepositorioBase<Cliente>, IClienteRepositorio
    {

        public ClienteRepositorio(Context context) : base(context)
        {

        }

        async public Task<Cliente> ConsultarPorCpf(string cpf)
        {
            return await _context.Clientes.AsNoTracking().FirstOrDefaultAsync(c => c.Cpf == cpf);
        }

         async public Task<Cliente> ConsultarPorIdCompleto(int id)
        {
            var telefones = _context.Telefones.Where(t => t.PessoaId == id).AsNoTracking().ToList();
            var enderecos = _context.Enderecos.Where(e => e.PessoaId == id).AsNoTracking().ToList();
            var cliente = await _context.Clientes.AsNoTracking().FirstAsync(c => c.PessoaId == id);
            cliente.Telefones = telefones;
            cliente.Enderecos = enderecos;
            return cliente;
        }

        async public Task<ICollection<Cliente>> ConsultarPorNome(string nome)
        {
            return await _context.Clientes.Where(c => c.Nome == nome).AsNoTracking().ToListAsync();
        }

        //async public Task Inativar(Cliente cliente)
        //{
        //    cliente.Inativar();
        //    _context.Clientes.Update(cliente);
        //    await _context.SaveChangesAsync();
        //}
    }
}