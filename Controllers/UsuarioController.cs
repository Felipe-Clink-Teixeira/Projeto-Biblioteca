
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Biblioteca.Models;

namespace Biblioteca.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Sair()
        {
           HttpContext.Session.Clear();
           return RedirectToAction("Index", "Home");

        }
        public IActionResult administrador()
        {
            return View();
        }
        public IActionResult ListaDeUsuarios()
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaseUsuarioEAdmin(this);
            return View(new UsuarioService().Listar());
        }
        public IActionResult RegistrarUsuario()
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaseUsuarioEAdmin(this);
            return View();
        }
        [HttpPost]
       public IActionResult RegistrarUsuario(Usuario noveuser)
        {
           noveuser.Senha = Ciptrografo.TextoCriptografado(noveuser.Senha);
           new UsuarioService().IncluirUsuario(noveuser);
           return RedirectToAction("ListaDeUsuarios");
        }
        public IActionResult EditarUsuario(int id)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaseUsuarioEAdmin(this);

            
           return View(new UsuarioService().Listar(id));

        }
        [HttpPost]
        public IActionResult EditarUsuario(Usuario userEditado)
        {
           new UsuarioService().editarUsuario(userEditado);
           return RedirectToAction("ListaDeUsuarios");

        }
        public IActionResult ExcluirUsuario(int Id)
        {
           new UsuarioService().ExcluirUsuario(Id);
            return RedirectToAction("ListaDeUsuarios");
        }
    }
}