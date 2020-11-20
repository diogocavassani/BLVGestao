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
    public class ContaReceberRepositorio : RepositorioBase<ContaReceber>, IContaReceberRepositorio
    {
        public ContaReceberRepositorio(Context context) : base(context)
        {

        }
        public async Task<ICollection<ContaReceber>> ConsultarPorCliente(string nome)
        {
            return await _context.ContasReceber.Where(c => c.Cliente.Nome.ToLower().Contains(nome.ToLower())).Include(c => c.Cliente).Include(c => c.Venda).AsNoTracking().ToListAsync();
        }
        

        public async Task<ICollection<ContaReceber>> ConsultarPorCodigoCliente(int id)
        {

            Cliente cliente = _context.Set<Cliente>().Where(c => c.PessoaId == id).AsNoTracking().FirstOrDefault();
            List<ContaReceber> contas = await _context.ContasReceber.Where(c => c.ClienteId == id).AsNoTracking().ToListAsync();
            foreach (ContaReceber c in contas)
            {
                c.Cliente = cliente;
                c.Venda = _context.Set<Venda>().Where(c => c.VendaId == c.VendaId).AsNoTracking().FirstOrDefault();
            }
            return contas;


        }

        public async Task<ICollection<ContaReceber>> ConsultarPorData(string data)
        {
            DateTime datafiltro1 = DateTime.Parse(data);
            return await _context.ContasReceber.Where(c => c.Venda.Data >= datafiltro1&&c.Venda.Data<= datafiltro1.AddHours(23)).Include(c => c.Cliente).Include(c => c.Venda).AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<ContaReceber>> ConsultarPorVencimento(string data)
        {
            DateTime datafiltro1 = DateTime.Parse(data);
            datafiltro1.AddDays(30);
            return await _context.ContasReceber.Where(c => c.Venda.Data.AddDays(30) >= datafiltro1&&c.Venda.Data.AddDays(30) <=datafiltro1.AddHours(23)).Include(c => c.Cliente).Include(c => c.Venda).AsNoTracking().ToListAsync();
        }
    }
}
