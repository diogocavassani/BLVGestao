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
            return await _context.Produtos.Where(p => p.Ativo == true).AsNoTracking().ToListAsync();
        }
    }
}
