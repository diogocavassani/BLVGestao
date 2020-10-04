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
    public class FormasDePagamentoController : Controller
    {
        private readonly IFormaDePagamentoRepositorio _formaDePagamentoRepositorio;

        public FormasDePagamentoController(IFormaDePagamentoRepositorio formaDePagamentoRepositorio)
        {
            _formaDePagamentoRepositorio = formaDePagamentoRepositorio;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _formaDePagamentoRepositorio.ListarAtivos());
        }


        public async Task<IActionResult> Details(int id)
        {


            var formaDePagamento = await _formaDePagamentoRepositorio.ListarPorId(id);
            if (formaDePagamento == null)
            {
                return NotFound();
            }

            return View(formaDePagamento);
        }


        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FormaDePagamento formaDePagamento)
        {
            if (ModelState.IsValid)
            {
                await _formaDePagamentoRepositorio.Inserir(formaDePagamento);
                return RedirectToAction(nameof(Index));
            }
            return View(formaDePagamento);
        }


        public async Task<IActionResult> Edit(int id)
        {


            var formaDePagamento = await _formaDePagamentoRepositorio.ListarPorId(id);
            if (formaDePagamento == null)
            {
                return NotFound();
            }
            return View(formaDePagamento);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FormaDePagamento formaDePagamento)
        {
        

            if (ModelState.IsValid)
            {
                try
                {
                    await _formaDePagamentoRepositorio.Alterar(formaDePagamento);
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(formaDePagamento);
        }

        // GET: FormasDePagamento/Delete/5
        public async Task<IActionResult> Delete(int id)
        {


            var formaDePagamento = await _formaDePagamentoRepositorio.ListarPorId(id);
            if (formaDePagamento == null)
            {
                return NotFound();
            }

            return View(formaDePagamento);
        }

        // POST: FormasDePagamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formaDePagamento = await _formaDePagamentoRepositorio.ListarPorId(id);
            formaDePagamento.Inativar();
            await _formaDePagamentoRepositorio.Alterar(formaDePagamento);
            return RedirectToAction(nameof(Index));
        }

 
    }
}
