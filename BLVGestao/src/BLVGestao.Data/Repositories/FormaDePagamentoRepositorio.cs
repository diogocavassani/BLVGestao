using BLVGestao.Data.Interfaces;
using BLVGestao.Data.ORM;
using BLVGestao.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLVGestao.Data.Repositories
{
    public class FormaDePagamentoRepositorio : RepositorioBase<FormaDePagamento>, IFormaDePagamentoRepositorio
    {
        public FormaDePagamentoRepositorio(Context context) : base(context)
        {
        }

        async public Task<ICollection<FormaDePagamento>> ListarAtivos()
        {
            return await _context.FormasDePagamento.Where(fp => fp.Ativo == true).AsNoTracking().ToListAsync();
        }
    }
}
