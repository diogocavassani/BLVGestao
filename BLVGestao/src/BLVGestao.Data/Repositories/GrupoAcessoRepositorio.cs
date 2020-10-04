using BLVGestao.Data.Interfaces;
using BLVGestao.Data.ORM;
using BLVGestao.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLVGestao.Data.Repositories
{
    public class GrupoAcessoRepositorio : RepositorioBase<GrupoAcesso>, IGrupoAcessoRepositorio
    {
        public GrupoAcessoRepositorio(Context context) : base(context)
        {
        }

        async public Task<ICollection<GrupoAcesso>> ListarAtivos()
        {
            return await _context.GruposAcesso.Where(ga => ga.Ativo == true).AsNoTracking().ToListAsync();
        }
    }
}
