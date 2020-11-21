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

        public async Task<ICollection<Venda>> ConsultarPorCliente(string nome)
        {
            return await _context.Vendas.Where(v => v.Cliente.Nome.ToLower().Contains(nome.ToLower())).Include(v => v.Cliente).Include(v=>v.FormaDePagamento).AsNoTracking().ToListAsync();
        }

        public async Task<bool> InserirVenda(Venda venda)
        {
            _context.Set<Venda>().Add(venda);
            var teste = _context.SaveChangesAsync().Result;
            await _context.SaveChangesAsync();
            return true;
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

        public async Task<ICollection<Venda>> ConsultarPorData(string datainicial, string datafinal)
        {
            DateTime datafiltro1 = DateTime.Parse(datainicial);
            DateTime datafiltro2 = DateTime.Parse(datafinal);

            datafiltro2 = datafiltro2.AddHours(23);

            return await _context.Vendas.Where(v => v.Data >= datafiltro1 && v.Data <= datafiltro2).Include(v => v.Cliente).Include(v=>v.FormaDePagamento).AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<Venda>> BuscarPorFormaPagamento(string filtro)
        {
            return await _context.Vendas.Where(v => v.FormaDePagamento.Descricao.ToLower().Contains(filtro.ToLower())).Include(v => v.Cliente).Include(v => v.FormaDePagamento).AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<Venda>> BuscarPorProduto(string produto)
        {
            var itens = await _context.ItensVenda.Where(i => i.Produto.Descricao.ToLower().Contains(produto.ToLower())).AsNoTracking().ToListAsync();
            ICollection<Venda> lista = new List<Venda>();
            Venda vendalocal = new Venda();
            foreach (ItemVenda venda in itens)
            {
                vendalocal = await _context.Vendas.AsNoTracking().Include(v => v.Cliente).Include(v=> v.FormaDePagamento).FirstOrDefaultAsync(v => v.VendaId == venda.VendaId);
                lista.Add(vendalocal);
            }
            return lista;
        }

        public async Task<ICollection<Venda>> BuscarPorSituacao(SituacaoVendaEnum situacao)
        {
            return await _context.Vendas.Where(v => v.Situacao == situacao).Include(v => v.Cliente).AsNoTracking().Include(v => v.FormaDePagamento).ToListAsync();
        }
    }
}
