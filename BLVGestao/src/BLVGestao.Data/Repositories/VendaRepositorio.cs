using BLVGestao.Data.Interfaces;
using BLVGestao.Data.ORM;
using BLVGestao.Domain.Enums;
using BLVGestao.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLVGestao.Data.Repositories
{
    public class VendaRepositorio : RepositorioBase<Venda>, IVendaRepositorio
    {
        public VendaRepositorio(Context context) : base(context)
        {

        }
        public Task<ICollection<Venda>> ConsultarPorData(string data)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Venda>> ConsultarPorCliente(string nome)
        {
            throw new NotImplementedException();
        }

        public async Task InserirVenda(Venda venda)
        {
            _context.Set<Venda>().Add(venda);
            foreach(ItemVenda item in venda.ItensVendas)
            {
                _context.Set<ItemVenda>().Add(item);
            }
            await _context.SaveChangesAsync();
        }

        public async Task AlterarVenda(Venda venda)
        {
            _context.Set<Venda>().Update(venda);
            foreach (ItemVenda item in venda.ItensVendas)
            {
                _context.Set<ItemVenda>().Update(item);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Venda>> BuscarVendas()
        {
            return await _context.Vendas.Where(v => v.Situacao == SituacaoVendaEnum.Confirmada).Include(v => v.Cliente).Include(v => v.ItensVendas).Include(v=>v.Usuario).Include(v=>v.FormaDePagamento).AsNoTracking().ToListAsync();
        }

        public async Task<Venda> BuscarPorIdCompleto(int id)
        {
            var itensvenda = await _context.ItensVenda.Where(i => i.VendaId == id).Include(i => i.Produto).AsNoTracking().ToListAsync();
            var vendas= await _context.Vendas.Where(v=>v.VendaId==id).Include(v => v.Cliente).Include(v => v.Usuario).Include(v => v.FormaDePagamento).AsNoTracking().FirstOrDefaultAsync();
            vendas.ItensVendas = itensvenda;
            return vendas;
        }
    }
}
