using BLVGestao.Data.Interfaces;
using BLVGestao.Data.ORM;
using BLVGestao.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLVGestao.Data.Repositories
{
    public class TelefoneRepositorio : RepositorioBase<Telefone>, ITelefoneRepositorio
    {
        public TelefoneRepositorio(Context context) : base(context)
        {
        }
       
        async public Task<Telefone> AlterarTelefoneComPessoa(Telefone telefone)
        {
            var telefoneCompleto = BuscarComInclude(telefone.TelefoneId);
            telefone.PessoaId = telefoneCompleto.PessoaId;
            _context.Telefones.Update(telefone);
            await _context.SaveChangesAsync();
            return telefoneCompleto;
        }

        public Telefone BuscarComInclude(int id)
        {
            return _context.Telefones.Include(t => t.Pessoa).Where(t => t.TelefoneId == id).AsNoTracking().FirstOrDefault();
        }
    }
}
