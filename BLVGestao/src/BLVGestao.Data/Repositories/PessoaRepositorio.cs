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
    public class PessoaRepositorio : RepositorioBase<Pessoa>, IPessoaRepositorio
    {
        public PessoaRepositorio(Context context) : base(context)
        {
        }
        
        async public Task Inativar(int id, Pessoa pessoa)
        {
            pessoa = await ListarPorId(id);
            pessoa.Inativar();
            _context.Pessoas.Update(pessoa);
            await _context.SaveChangesAsync();
        }
        async public Task Ativar(int id, Pessoa pessoa)
        {
            pessoa = await ListarPorId(id);
            pessoa.Ativar();
            _context.Pessoas.Update(pessoa);
            await _context.SaveChangesAsync();
        }

        async public Task<Pessoa> ConsultarPorIdCompleto(int id)
        {
            var telefones = _context.Telefones.Where(t => t.PessoaId == id).AsNoTracking().ToList();
            var enderecos = _context.Enderecos.Where(e => e.PessoaId == id).AsNoTracking().ToList();
            var pessoa = await _context.Pessoas.AsNoTracking().FirstAsync(c => c.PessoaId == id);
            pessoa.Telefones = telefones;
            pessoa.Enderecos = enderecos;
            return pessoa;
        }


    }
}
