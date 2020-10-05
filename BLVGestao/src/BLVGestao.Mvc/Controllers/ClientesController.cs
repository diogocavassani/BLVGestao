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
using BLVGestao.Mvc.Models;
using System.Collections;

namespace BLVGestao.Mvc.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;
        private readonly IClienteRepositorio _clienteRepositorio;



        public ClientesController(IPessoaRepositorio pessoaRepositorio, IClienteRepositorio clienteRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio;
            _clienteRepositorio = clienteRepositorio;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _clienteRepositorio.ListarAtivos());
        }

        public async Task<IActionResult> FiltarClientes()
        {
            return View(nameof(Index));
        }


        public async Task<IActionResult> Details(int id)
        {
            var cliente = await _pessoaRepositorio.ConsultarPorIdCompleto(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }


        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cliente cliente)
        {

            await _clienteRepositorio.Inserir(cliente);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int id)
        {
            var cliente = await _clienteRepositorio.ListarPorId(id);
            if (cliente == null)
                return NotFound();
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cliente cliente)
        {
            cliente.PessoaId = id;
            if (ModelState.IsValid)
            {
                await _clienteRepositorio.Alterar(cliente);
                return RedirectToAction(nameof(Index));
            }

            return View(cliente);

        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _clienteRepositorio.ListarPorId(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        //POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _clienteRepositorio.ListarPorId(id);
            cliente.Inativar();
            await _clienteRepositorio.Alterar(cliente);
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            var cliente = _clienteRepositorio.ListarPorId(id);

            if (cliente == null)
                return false;
            return true;
        }

    }
}
