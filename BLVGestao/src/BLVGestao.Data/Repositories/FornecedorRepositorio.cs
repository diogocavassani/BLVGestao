using BLVGestao.Data.Interfaces;
using BLVGestao.Data.ORM;
using BLVGestao.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLVGestao.Data.Repositories
{
    public class FornecedorRepositorio : RepositorioBase<Fornecedor>, IFornecedorRepositorio
    {

        public FornecedorRepositorio(Context context) : base(context)
        {
        }

        async public Task<Fornecedor> ConsultarPorCnpj(string cnpj)
        {
            return await _context.Fornecedores.AsNoTracking().FirstOrDefaultAsync(f => f.Cnpj == cnpj && f.Ativo == true);
        }

        async public Task<ICollection<Fornecedor>> ConsultarPorNomeFantasia(string nomeFantasia)
        {
            return await _context.Fornecedores.Where(f => f.NomeFantasia == nomeFantasia && f.Ativo == true ).AsNoTracking().ToListAsync();
        }

        async public Task<ICollection<Fornecedor>> ListarAtivos()
        {
            return await _context.Fornecedores.Where(c => c.Ativo == true).AsNoTracking().ToListAsync();
        }
    }
}
