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
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace BLVGestao.Mvc.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IGrupoAcessoRepositorio _grupoAcessoRepositorio;

        public UsuariosController(IUsuarioRepositorio usuarioRepositorio, IGrupoAcessoRepositorio grupoAcessoRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _grupoAcessoRepositorio = grupoAcessoRepositorio;
        }

        [Authorize(Roles = "Administrativo")]
        public async Task<IActionResult> Index()
        {
           //TODO:Tentar fazer pesquisa com include.
            return View(await _usuarioRepositorio.ListarAtivos());
        }


        public async Task<IActionResult> Details(int id)
        {

            var usuario = await _usuarioRepositorio.ListarPorId(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [Authorize(Roles = "Administrativo")]
        public async Task<IActionResult> Create()
        {
            var grupo =  (System.Collections.IEnumerable)await _grupoAcessoRepositorio.ListarTodos();
             ViewData["GrupoAcessoId"] = new SelectList(grupo, "GrupoAcessoId", "Descricao");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                await _usuarioRepositorio.Inserir(usuario);
                return RedirectToAction(nameof(Index));
            }
            var grupo = (System.Collections.IEnumerable)await _grupoAcessoRepositorio.ListarTodos();
            ViewData["GrupoAcessoId"] = new SelectList(grupo, "GrupoAcessoId", "Descricao");
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        [Authorize(Roles = "Administrativo")]
        public async Task<IActionResult> Edit(int id)
        {


            var usuario = await _usuarioRepositorio.ListarPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }

            ViewData["GrupoAcessoId"] = new SelectList(await ListaGrupoAcesso(), "GrupoAcessoId", "Descricao", usuario.GrupoAcessoId);
            return View(usuario);
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Usuario usuario)
        {
            if (id != usuario.UsuarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _usuarioRepositorio.Alterar(usuario);
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["GrupoAcessoId"] = new SelectList(await ListaGrupoAcesso(), "GrupoAcessoId", "Descricao", usuario.GrupoAcessoId);
            return View(usuario);
        }

        [Authorize(Roles = "Administrativo")]
        public async Task<IActionResult> Delete(int id)
        {

            var usuario = await _usuarioRepositorio.ListarPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _usuarioRepositorio.ListarPorId(id);
            usuario.Inativar();
            await _usuarioRepositorio.Alterar(usuario);
            return RedirectToAction(nameof(Index));
        }

        private async  Task<IEnumerable<GrupoAcesso>> ListaGrupoAcesso()
        {
            return (IEnumerable<GrupoAcesso>)await _grupoAcessoRepositorio.ListarAtivos();
        }
        [HttpGet]
        public ActionResult LogarUsuario()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogarUsuario([Bind] Usuario usuario) {
            var user =  _usuarioRepositorio.LogarUsuario(usuario.Login,usuario.Senha);
            if(user != null)
            {
                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.Login),
                    new Claim(ClaimTypes.Role, user.GrupoAcesso.Permissao.ToString()),
                };
                var minhaIdentity = new ClaimsIdentity(userClaims,"Usuario");
                var userPrincipal = new ClaimsPrincipal(new[] { minhaIdentity});
                await HttpContext.SignInAsync(userPrincipal);
                return RedirectToAction("Index","Home");
            }
            ViewBag.Message = "Credenciais inválidas!";
            return View(usuario);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
        public IActionResult AcessoNegado()
        {
            return View();
        }
    }
}
