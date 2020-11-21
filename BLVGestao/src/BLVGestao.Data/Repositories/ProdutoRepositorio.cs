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
    public class ProdutoRepositorio : RepositorioBase<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(Context context) : base(context)
        {
        }

        async public Task<ICollection<Produto>> ListarAtivos()
        {
            return await _context.Produtos.Where(p => p.Ativo == true).Include(p => p.Fornecedor).AsNoTracking().ToListAsync();
        }



        public async Task<ICollection<Produto>> ListarPorFornecedor(int fornecedorId)
        {
            return await _context.Produtos.Where(p => p.FornecedorId == fornecedorId).Include(p => p.Fornecedor).AsNoTracking().ToListAsync();
        }
        public async Task<ICollection<Produto>> ListarPorIdCompleto(int id)
        {
            return await _context.Produtos.Where(p => p.ProdutoId == id).Include(p => p.Fornecedor).AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<Produto>> ListarPorNome(string descricao)
        {
            return await _context.Produtos.Where(p => p.Descricao.ToLower().Contains(descricao)).Include(p => p.Fornecedor).AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<Produto>> ListarPorStatus(bool status)
        {

            return await _context.Produtos.Where(p => p.Ativo == status).Include(p => p.Fornecedor).AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<Produto>> ListarPorValidade(string data)
        {
            DateTime filtro = DateTime.Parse(data);
            return await _context.Produtos.Where(p => p.Validade >= filtro && p.Validade <= filtro.AddHours(23)).Include(p => p.Fornecedor).AsNoTracking().ToListAsync();

        }
    }
}
