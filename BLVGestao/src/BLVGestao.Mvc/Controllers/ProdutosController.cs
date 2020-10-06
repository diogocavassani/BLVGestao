using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BLVGestao.Data.ORM;
using BLVGestao.Domain.Model;
using BLVGestao.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace BLVGestao.Mvc.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IFornecedorRepositorio _fornecedorRepositorio;


        public ProdutosController(IProdutoRepositorio produtoRepositorio, IFornecedorRepositorio fornecedorRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
            _fornecedorRepositorio = fornecedorRepositorio;
        }

        // GET: Produtos
        [Authorize(Roles = "Administrativo")]
        public async Task<IActionResult> Index()
        {

            return View(await _produtoRepositorio.ListarAtivos());
        }

        // GET: Produtos/Details/5
        [Authorize(Roles = "Administrativo")]
        public async Task<IActionResult> Details(int id)
        {
            var produto = await _produtoRepositorio.ListarPorId(id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Create
        [Authorize(Roles = "Administrativo")]
        public async Task<IActionResult> Create()
        {
            var fornecedores = await _fornecedorRepositorio.ListarAtivos();
            ViewData["FornecedorId"] = new SelectList(fornecedores, "PessoaId", "RazaoSocial");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                await _produtoRepositorio.Inserir(produto);
                return RedirectToAction(nameof(Index));
            }
            ViewData["FornecedorId"] = new SelectList(await ListaFornecedores(), "PessoaId", "RazaoSocial", produto.FornecedorId);
            return View(produto);
        }

        // GET: Produtos/Edit/5
        [Authorize(Roles = "Administrativo")]
        public async Task<IActionResult> Edit(int id)
        {

            var produto = await _produtoRepositorio.ListarPorId(id);
            if (produto == null)
            {
                return NotFound();
            }
            ViewData["FornecedorId"] = new SelectList(await ListaFornecedores(), "PessoaId", "Discriminator", produto.FornecedorId);
            return View(produto);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _produtoRepositorio.Alterar(produto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FornecedorId"] = new SelectList(await ListaFornecedores(), "PessoaId", "Discriminator", produto.FornecedorId);
            return View(produto);
        }

        [Authorize(Roles = "Administrativo")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _produtoRepositorio.ListarPorId(id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _produtoRepositorio.ListarPorId(id);
            produto.Inativar();
            await _produtoRepositorio.Alterar(produto);
            return RedirectToAction(nameof(Index));
        }

        private async Task<IEnumerable<Fornecedor>> ListaFornecedores()
        {
            return (IEnumerable<Fornecedor>)await _produtoRepositorio.ListarTodos();
        }
    }
}
