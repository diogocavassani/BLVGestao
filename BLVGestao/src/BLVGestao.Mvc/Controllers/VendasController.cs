using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BLVGestao.Data.ORM;
using BLVGestao.Domain.Model;
using BLVGestao.Data.Repositories;
using BLVGestao.Data.Interfaces;
using BLVGestao.Domain.Enums;
using BLVGestao.Mvc.Models;

namespace BLVGestao.Mvc.Controllers
{
    public class VendasController : Controller
    {
        private readonly IVendaRepositorio _vendaRepositorio;
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IFormaDePagamentoRepositorio _formaDePagementoRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public VendasController(IVendaRepositorio vendaRepositorio,IProdutoRepositorio produtoRepositorio,IClienteRepositorio clienteRepositorio,
            IFormaDePagamentoRepositorio formaDePagamentoRepositorio,IUsuarioRepositorio usuarioRepositorio)
        {
            _vendaRepositorio = vendaRepositorio;
            _produtoRepositorio = produtoRepositorio;
            _clienteRepositorio = clienteRepositorio;
            _formaDePagementoRepositorio = formaDePagamentoRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
        }

       
        public async Task<IActionResult> Index()
        {
            var vendas = await _vendaRepositorio.BuscarVendas();
            return View(vendas);
        }
        public async Task<IActionResult> Details(int id)
        {
            var venda = await _vendaRepositorio.BuscarPorIdCompleto(id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }
        public async Task<IActionResult> Create()
        {
            var vendaViewModel = new VendaViewModel();
            vendaViewModel.ListaCliente = await _clienteRepositorio.ListarAtivos();
            vendaViewModel.ListaProduto = await _produtoRepositorio.ListarAtivos();
            vendaViewModel.ListaFormaDePagamento = await _formaDePagementoRepositorio.ListarAtivos();

            //var produtos = await _produtoRepositorio.ListarAtivos();
            //var clientes = await _clienteRepositorio.ListarAtivos();
            //var formaPagamento = await _formaDePagementoRepositorio.ListarAtivos();
            //var usuario = await _usuarioRepositorio.ListarAtivos();
            //ViewData["ProdutoId"] = new SelectList(produtos,"ProdutoId","Descricao");
            //ViewData["ClienteId"] = new SelectList(clientes, "PessoaId", "Nome");
            //ViewData["FormaDePagamentoId"] = new SelectList(formaPagamento,"FormaDePagamentoId","Descricao");
            //ViewData["UsuarioId"] = new SelectList(usuario, "UsuarioId", "Login");
            return  View(vendaViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ClienteId,ItensVenda,UsuarioId,FormaPagamentoId,Data,")]Venda venda)      
        {
            
            await _vendaRepositorio.InserirVenda(venda);
            return RedirectToAction(nameof(Index));
        }

        
        public async Task<IActionResult> Edit(int id)
        {
            var venda = await _vendaRepositorio.BuscarPorIdCompleto(id);
            if (venda == null)
                return NotFound();
            return View(venda);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Venda venda)
        {
            
            if (ModelState.IsValid)
            {
                await _vendaRepositorio.AlterarVenda(venda);
                return RedirectToAction(nameof(Index));
            }

            return View(venda);


        }


        public async Task<IActionResult> Delete(int id)
        {
            var venda = await _vendaRepositorio.BuscarPorIdCompleto(id);

            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venda = await _vendaRepositorio.BuscarPorIdCompleto(id);
            venda.Cancelar();
            await _vendaRepositorio.Alterar(venda);
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            var cliente = _vendaRepositorio.ListarPorId(id);

            if (cliente == null)
                return false;
            return true;
        }

    }
}
