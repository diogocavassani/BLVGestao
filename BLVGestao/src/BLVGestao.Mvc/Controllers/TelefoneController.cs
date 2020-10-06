using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLVGestao.Data.Interfaces;
using BLVGestao.Domain.Enums;
using BLVGestao.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BLVGestao.Mvc.Controllers
{
    public class TelefoneController : Controller
    {

        private readonly ITelefoneRepositorio _telefoneRepositorio;
        private readonly IPessoaRepositorio _pessoaRepositorio;



        public TelefoneController(ITelefoneRepositorio telefoneRepositorio, IPessoaRepositorio pessoaRepositorio)
        {
            _telefoneRepositorio = telefoneRepositorio;
            _pessoaRepositorio = pessoaRepositorio;
        }

        [Authorize(Roles = "Administrativo")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(int id, Telefone telefone)
        {

            var pessoa = await _pessoaRepositorio.ConsultarPorIdCompleto(id);
            pessoa.Telefones.Add(telefone);
            await _pessoaRepositorio.Alterar(pessoa);
            return RetornarDeAcordoComPessoa(telefone);
        }

        [Authorize(Roles = "Administrativo")]
        public async Task<ActionResult> Edit(int id)
        {
            var telefone = await _telefoneRepositorio.ListarPorId(id);
            if (telefone == null)
                return NotFound();

            return View(telefone);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Telefone telefone)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _telefoneRepositorio.AlterarTelefoneComPessoa(telefone);
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RetornarDeAcordoComPessoa(telefone);
            }

            return View(telefone);
        }

        [Authorize(Roles = "Administrativo")]
        public async Task<ActionResult> Delete(int id)
        {
            var telefone = await _telefoneRepositorio.ListarPorId(id);
            if (telefone == null)
                return NotFound();

            return View(telefone);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var telefone = _telefoneRepositorio.BuscarComInclude(id);
            telefone.Inativar();
            await _telefoneRepositorio.AlterarTelefoneComPessoa(telefone);
            return RetornarDeAcordoComPessoa(telefone);
        }

        [Authorize(Roles = "Administrativo")]
        private ActionResult RetornarDeAcordoComPessoa(Telefone telefone)
        {
            if (telefone.Pessoa is Cliente)
                return RedirectToAction("Index", "Clientes");
            return RedirectToAction("Index", "Fornecedores");
        }
    }
}
