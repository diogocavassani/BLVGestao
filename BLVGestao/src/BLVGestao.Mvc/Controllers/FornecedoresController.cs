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

namespace BLVGestao.Mvc.Controllers
{
    public class FornecedoresController : Controller
    {
        private readonly IFornecedorRepositorio _fornecedorRepositorio;

        public FornecedoresController(IFornecedorRepositorio fornecedorRepositorio)
        {
            _fornecedorRepositorio = fornecedorRepositorio;
        }

        // GET: Fornecedores
        public async Task<IActionResult> Index()
        {
            return View(await _fornecedorRepositorio.ListarTodos());
        }

        // GET: Fornecedores/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var fornecedor = await _fornecedorRepositorio.ConsultarPorIdCompleto(id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        // GET: Fornecedores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fornecedores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RazaoSocial,NomeFantasia,Cnpj,PessoaId,TipoPessoa,Ativo")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                await _fornecedorRepositorio.Inserir(fornecedor);
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedor);
        }

        // GET: Fornecedores/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var fornecedor = await _fornecedorRepositorio.ListarPorId(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return View(fornecedor);
        }

        // POST: Fornecedores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RazaoSocial,NomeFantasia,Cnpj,PessoaId,TipoPessoa,Ativo")] Fornecedor fornecedor)
        {
            if (id != fornecedor.PessoaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _fornecedorRepositorio.Alterar(fornecedor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FornecedorExists(fornecedor.PessoaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedor);
        }

        // GET: Fornecedores/Delete/5
        public async Task<IActionResult> Delete(int id)
        {


            var fornecedor = await _fornecedorRepositorio.ListarPorId(id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        // POST: Fornecedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fornecedor = await _fornecedorRepositorio.ListarPorId(id);
            fornecedor.Inativar();
            await _fornecedorRepositorio.Alterar(fornecedor);
            return RedirectToAction(nameof(Index));
        }

        private bool FornecedorExists(int id)
        {
            var cliente = _fornecedorRepositorio.ListarPorId(id);
            if(cliente == null)
                return false;
            return true;
        }
    }
}
