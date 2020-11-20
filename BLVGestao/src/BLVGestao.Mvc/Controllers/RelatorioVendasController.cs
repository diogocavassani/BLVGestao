using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLVGestao.Data.Interfaces;
using BLVGestao.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace BLVGestao.Mvc.Controllers
{
    public class RelatorioVendasController : Controller
    {
        private readonly IVendaRepositorio _vendaRepositorio;




        public RelatorioVendasController(IVendaRepositorio vendaRepositorio)
        {
            _vendaRepositorio = vendaRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Listar(string filtro1,string? filtro2, string campo)
        {
            if (campo == "Periodo" && filtro1 != null && filtro1 != "" && filtro2 != null && filtro2 != "")
            {
                var resultado = await _vendaRepositorio.ConsultarPorData(filtro1, filtro2);
                return View("Index", resultado);
            }
            else if (campo == "FormaPagamento" && filtro1 != null && filtro1 != "")
            {
                int id = int.Parse(filtro1);
                var resultado = await _vendaRepositorio.BuscarPorFormaPagamento(id);
                return View("Index", resultado);
            }
            else if (campo == "Cliente" && filtro1 != null && filtro1 != "")
            {
                var resultado = await _vendaRepositorio.ConsultarPorCliente(filtro1);
                return View("Index", resultado);
            }
            else if (campo == "Produto" && filtro1 != null && filtro1 != "")
            {
                var resultado = await _vendaRepositorio.BuscarPorProduto(filtro1);
                return View("Index", resultado);
            }
            else if (campo == "Ativo" )
            {
                SituacaoVendaEnum status = SituacaoVendaEnum.Confirmada;

                var resultado = await _vendaRepositorio.BuscarPorSituacao(status);
                return View(resultado);
            }
            else if (campo == "NaoAtivo")
            {
                SituacaoVendaEnum status = SituacaoVendaEnum.Cancelada;

                var resultado = await _vendaRepositorio.BuscarPorSituacao(status);
                return View(resultado);
            }
            else
                return View("index");
        }
            public async Task<IActionResult> ListarVendas(int id)
        {
            var resultado = await _vendaRepositorio.BuscarPorFormaPagamento(id);
            return View(resultado);
        }
        public async Task<IActionResult> ListarVendasPorData(string datainicial, string datafinal)
        {
            var resultado = await _vendaRepositorio.ConsultarPorData(datainicial, datafinal);
            return View(resultado);
        }
        public async Task<IActionResult> ListarVendasPorCliente(string nome)
        {
            var resultado = await _vendaRepositorio.ConsultarPorCliente(nome);
            return View(resultado);
        }
        public async Task<IActionResult> ListarVendasPorProduto(string produto)
        {
            var resultado = await _vendaRepositorio.BuscarPorProduto(produto);
            return View(resultado);
        }
        public async Task<IActionResult> ListarPorStatus(int filtro)
        {
            SituacaoVendaEnum status;
            if (filtro == 1)
            {
                status = SituacaoVendaEnum.Confirmada;
            }
            else
                status = SituacaoVendaEnum.Cancelada;
            var resultado = await _vendaRepositorio.BuscarPorSituacao(status);
            return View(resultado);
        }

    }
}
