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
        private readonly IPessoaRepositorio _pessoaRepositorio;
        private readonly IFornecedorRepositorio _fornecedorRepositorio;



        public FornecedoresController(IPessoaRepositorio pessoaRepositorio, IFornecedorRepositorio fornecedorRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio;
            _fornecedorRepositorio = fornecedorRepositorio;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _fornecedorRepositorio.ListarAtivos());
        }


        public async Task<IActionResult> Details(int id)
        {
            var fornecedor = await _pessoaRepositorio.ConsultarPorIdCompleto(id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                await _fornecedorRepositorio.Inserir(fornecedor);
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedor);
        }



        public async Task<IActionResult> Edit(int id)
        {
            var fornecedor = await _fornecedorRepositorio.ListarPorId(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return View(fornecedor);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Fornecedor fornecedor)
        {
            fornecedor.PessoaId = id;
            if (ModelState.IsValid)
            {
                await _fornecedorRepositorio.Alterar(fornecedor);
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
    }
}
