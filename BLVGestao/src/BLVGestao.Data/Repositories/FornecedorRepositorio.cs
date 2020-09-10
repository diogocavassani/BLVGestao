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
            return await _context.Fornecedores.AsNoTracking().FirstOrDefaultAsync(f => f.Cnpj == cnpj);
        }

        async public Task<ICollection<Fornecedor>> ConsultarPorNomeFantasia(string nomeFantasia)
        {
            return await _context.Fornecedores.Where(f => f.NomeFantasia == nomeFantasia).AsNoTracking().ToListAsync();
        }
        async public Task<Fornecedor> ConsultarPorIdCompleto(int id)
        {
            var telefones = _context.Telefones.Where(t => t.PessoaId == id).AsNoTracking().ToList();
            var enderecos = _context.Enderecos.Where(e => e.PessoaId == id).AsNoTracking().ToList();
            var fornecedor = await _context.Fornecedores.AsNoTracking().FirstAsync(c => c.PessoaId == id);
            fornecedor.Telefones = telefones;
            fornecedor.Enderecos = enderecos;
            return fornecedor;
        }
    }
}
