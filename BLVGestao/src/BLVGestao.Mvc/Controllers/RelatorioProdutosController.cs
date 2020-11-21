using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLVGestao.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BLVGestao.Mvc.Controllers
{
    public class RelatorioProdutosController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;




        public RelatorioProdutosController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Listar(string filtro, string campo)
        {
            if (campo == "Todos")
            {
                var resultado = await _produtoRepositorio.ListarTodos();
                return View("Index", resultado);
            }
            else if (campo == "Fornecedor" && filtro != null && filtro != "")
            {
                int fornecedorId = int.Parse(filtro);
                var resultado = await _produtoRepositorio.ListarPorFornecedor(fornecedorId);
                return View("Index", resultado);
            }
            else if (campo == "CodigoProduto" && filtro != null && filtro != "")
            {
                int id = int.Parse(filtro);
                var resultado = await _produtoRepositorio.ListarPorIdCompleto(id);
                return View("Index", resultado);
            }
            else if (campo == "Validade" && filtro != null && filtro != "")
            {
                var resultado = await _produtoRepositorio.ListarPorValidade(filtro);
                return View("Index", resultado);
            }
            else if (campo == "NomeProduto" && filtro != null && filtro != "")
            {

                var resultado = await _produtoRepositorio.ListarPorNome(filtro);
                return View("Index", resultado);
            }
            else if (campo == "Ativo")
            {
                var resultado = await _produtoRepositorio.ListarPorStatus(true);
                return View("Index", resultado);
            }
            else if (campo == "NaoAtivo")
            {
                var resultado = await _produtoRepositorio.ListarPorStatus(false);
                return View("Index", resultado);
            }

            else
                return View("Index");
        }
        public async Task<IActionResult> ListarProdutos()
        {
            var resultado = await _produtoRepositorio.ListarTodos();
            return View(resultado);
        }
        public async Task<IActionResult> ListarProdutosPorFornecedor(int fornecedorId)
        {
            var resultado = await _produtoRepositorio.ListarPorFornecedor(fornecedorId);
            return View(resultado);
        }
        public async Task<IActionResult> ListarProdutosPorId(int id)
        {
            var resultado = await _produtoRepositorio.ListarPorId(id);
            return View(resultado);
        }
        public async Task<IActionResult> ListarProdutosPorValidade(string data)
        {
            var resultado = await _produtoRepositorio.ListarPorValidade(data);
            return View();
        }
        public async Task<IActionResult> ListarProdutosPorDescricao(string descricao)
        {
            var resultado = await _produtoRepositorio.ListarPorNome(descricao);
            return View(resultado);
        }
        public async Task<IActionResult> ListarProdutosPorStatus(bool status)
        {
            var resultado = await _produtoRepositorio.ListarPorStatus(status);
            return View(resultado);
        }


    }
}
