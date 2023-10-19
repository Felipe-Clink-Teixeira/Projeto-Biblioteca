using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Controllers;

namespace Biblioteca.Models
{
    public class UsuarioService
    {
        public List<Usuario> Listar()
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.Usuarios.ToList();
            }
        }
        public Usuario Listar(int id)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.Usuarios.Find(id);
            }
        }
        public void IncluirUsuario(Usuario u)
        {
             using(BibliotecaContext bc = new BibliotecaContext())
            {
                bc.Add(u);
                bc.SaveChanges();
            }

        }
        public void editarUsuario(Usuario u)
        {
             using(BibliotecaContext bc = new BibliotecaContext())
            {
                Usuario usuarioBD = bc.Usuarios.Find(u.Id);
                usuarioBD.Login = u.Login;
                usuarioBD.Senha = u.Senha;
                if(usuarioBD.Senha != u.Senha)
                {
                    usuarioBD.Senha = Ciptrografo.TextoCriptografado(u.Senha);
                }
                else{
                    usuarioBD.Senha = u.Senha;
                }
                usuarioBD.Nome = u.Nome;
                usuarioBD.Tipo = u.Tipo;
                bc.SaveChanges();
            }
        }
        public void ExcluirUsuario(int id)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                bc.Usuarios.Remove(bc.Usuarios.Find(id));
                bc.SaveChanges();
            }
        }
    }
}