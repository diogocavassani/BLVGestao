using BLVGestao.Data.Interfaces;
using BLVGestao.Data.ORM;
using BLVGestao.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLVGestao.Data.Repositories
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(Context context) : base(context)
        {
        }


        async public Task<ICollection<Usuario>> ListarAtivos()
        {
            return await _context.Usuarios.Include(u => u.GrupoAcesso).Where(u => u.Ativo == true).AsNoTracking().ToListAsync();
                    
        }
    }
}
