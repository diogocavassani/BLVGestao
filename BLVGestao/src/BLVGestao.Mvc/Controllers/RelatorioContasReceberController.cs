using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLVGestao.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BLVGestao.Mvc.Controllers
{
    public class RelatorioContasReceberController : Controller
    {
        private readonly IContaReceberRepositorio _contaReceberRepositorio;




        public RelatorioContasReceberController(IContaReceberRepositorio contaReceberRepositorio)
        {
            _contaReceberRepositorio = contaReceberRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Listar(string filtro, string campo)
        {
            if (campo == "Compra" && filtro != null && filtro != "")
            {
                var resultado = await _contaReceberRepositorio.ConsultarPorData(filtro);
                return View("Index", resultado);
            }
            else if (campo == "Vencimento" && filtro != null && filtro != "")
            {
                var resultado = await _contaReceberRepositorio.ConsultarPorVencimento(filtro);
                return View("Index", resultado);
            }
            else if (campo == "CodigoCliente" && filtro != null && filtro != "")
            {
                int id = int.Parse(filtro);
                var resultado = await _contaReceberRepositorio.ConsultarPorCodigoCliente(id);

                return View("Index", resultado);
            }
            else if (campo == "Cliente" && filtro != null && filtro != "")
            {

                var resultado = await _contaReceberRepositorio.ConsultarPorCliente(filtro);
                return View("Index", resultado);
            }

            else
                return View("Index");
        }

        public async Task<IActionResult> ListarContasPorCliente(string nome)
        {
            var resultado = await _contaReceberRepositorio.ConsultarPorCliente(nome);
            return View(resultado);
        }
        public async Task<IActionResult> ListarContasPorCodigoCliente(int id)
        {
            var resultado = await _contaReceberRepositorio.ConsultarPorCodigoCliente(id);
            return View(resultado);
        }
        public async Task<IActionResult> ListarContasPorData(string data)
        {
            var resultado = await _contaReceberRepositorio.ConsultarPorData(data);
            return View(resultado);
        }
        public async Task<IActionResult> ListarContasPorVencimento(string data)
        {
            var resultado = await _contaReceberRepositorio.ConsultarPorVencimento(data);
            return View(resultado);
        }
    }
}
