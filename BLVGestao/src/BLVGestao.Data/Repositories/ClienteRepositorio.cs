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
    public class ClienteRepositorio : RepositorioBase<Cliente>, IClienteRepositorio
    {

        public ClienteRepositorio(Context context) : base(context)
        {

        }

        async public Task<Cliente> ConsultarPorCpf(string cpf)
        {
            return await _context.Clientes.AsNoTracking().FirstOrDefaultAsync(c => c.Cpf == cpf);
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