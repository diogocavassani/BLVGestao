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
    public class GruposAcessoController : Controller
    {
        private readonly IGrupoAcessoRepositorio _grupoAcessoRepositorio;

        public GruposAcessoController(IGrupoAcessoRepositorio grupoAcessoRepositorio)
        {
            _grupoAcessoRepositorio = grupoAcessoRepositorio;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _grupoAcessoRepositorio.ListarAtivos());
        }


        public async Task<IActionResult> Details(int id)
        {
            var grupoAcesso = await _grupoAcessoRepositorio.ListarPorId(id);
            if (grupoAcesso == null)
            {
                return NotFound();
            }

            return View(grupoAcesso);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GrupoAcesso grupoAcesso)
        {
            if (ModelState.IsValid)
            {
               await _grupoAcessoRepositorio.Inserir(grupoAcesso);
                return RedirectToAction(nameof(Index));
            }
            return View(grupoAcesso);
        }


        public async Task<IActionResult> Edit(int id)
        {

            var grupoAcesso = await _grupoAcessoRepositorio.ListarPorId(id);
            if (grupoAcesso == null)
            {
                return NotFound();
            }
            return View(grupoAcesso);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GrupoAcesso grupoAcesso)
        {
            if (id != grupoAcesso.GrupoAcessoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _grupoAcessoRepositorio.Alterar(grupoAcesso);
                }
                catch (DbUpdateConcurrencyException)
                {
                   
                }
                return RedirectToAction(nameof(Index));
            }
            return View(grupoAcesso);
        }


        public async Task<IActionResult> Delete(int id)
        {


            var grupoAcesso = await _grupoAcessoRepositorio.ListarPorId(id);

            if (grupoAcesso == null)
            {
                return NotFound();
            }

            return View(grupoAcesso);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grupoAcesso = await _grupoAcessoRepositorio.ListarPorId(id);
            grupoAcesso.Inativar();
            await _grupoAcessoRepositorio.Alterar(grupoAcesso);
            return RedirectToAction(nameof(Index));
        }
    }
}
