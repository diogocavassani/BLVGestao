using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLVGestao.Data.Interfaces;
using BLVGestao.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BLVGestao.Mvc.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;
        private readonly IEnderecoRepositorio _enderecoRepositorio;

        private Pessoa pessoa;


        public EnderecoController(IPessoaRepositorio pessoaRepositorio, IEnderecoRepositorio enderecoRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio;
            _enderecoRepositorio = enderecoRepositorio;
        }
        // GET: EnderecoController
        [Authorize(Roles = "Administrativo")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(int id, Endereco endereco)
        {

            pessoa = await _pessoaRepositorio.ConsultarPorIdCompleto(id);
            pessoa.Enderecos.Add(endereco);
            await _pessoaRepositorio.Alterar(pessoa);
            return RetornarDeAcordoComPessoa(endereco);
        }

        // GET: EnderecoController/Edit/5
        [Authorize(Roles = "Administrativo")]
        public async Task<ActionResult> Edit(int id)
        {
            var endereco = await _enderecoRepositorio.ListarPorId(id);
            if (endereco == null)
                return NotFound();
            return View(endereco);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _enderecoRepositorio.AlterarEnderecoComPessoa(endereco);
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                }
                return RetornarDeAcordoComPessoa(endereco);
            }
            return View(endereco);
            
        }

        [Authorize(Roles = "Administrativo")]
        public async Task<ActionResult> Delete(int id)
        {
            var endereco = await _enderecoRepositorio.ListarPorId(id);
            if (endereco == null)
                return NotFound();
            return View(endereco);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var endereco = _enderecoRepositorio.BuscarComInclude(id);
            endereco.Inativar();
            await _enderecoRepositorio.AlterarEnderecoComPessoa(endereco);
            return RetornarDeAcordoComPessoa(endereco);
        }

        private ActionResult RetornarDeAcordoComPessoa(Endereco endereco)
        {
            if (endereco.Pessoa is Cliente)
                return RedirectToAction("Index", "Clientes");
            return RedirectToAction("Index", "Fornecedores");
        }
    }
}
