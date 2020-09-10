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
    public class ClientesController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        //private readonly Cliente _cliente;

        public ClientesController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
            //_cliente = new Cliente(0, null, DateTime.Now, null, null);
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _clienteRepositorio.ListarTodos());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var cliente = await _clienteRepositorio.ConsultarPorIdCompleto(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cliente cliente)
        {

            await _clienteRepositorio.Inserir(cliente);
            
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int id, Cliente cliente)
        {
            if(id != cliente.PessoaId)
                return NotFound();
            if(ModelState.IsValid)
            {
                try
                {
                    await _clienteRepositorio.Alterar(cliente);
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                    if (!ClienteExists(cliente.PessoaId))
                        return NotFound();
                    else
                        throw;
                   
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _clienteRepositorio.Alterar(cliente);
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                }
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
           var cliente =  await _clienteRepositorio.ListarPorId(id);
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
