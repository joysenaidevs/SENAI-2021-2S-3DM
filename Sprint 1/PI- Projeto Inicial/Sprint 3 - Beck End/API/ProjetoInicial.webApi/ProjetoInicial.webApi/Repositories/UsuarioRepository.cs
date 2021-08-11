using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoInicial.webApi.Interfaces;
using ProjetoInicial.webApi.Domains;
using ProjetoInicial.webApi.Contexts;

namespace ProjetoInicial.webApi.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        primeiroProjetoContext ctx = new primeiroProjetoContext();

        public void Atualizar(int id, Usuario novoUsuario)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);
            if(usuarioBuscado != null)
            {
                usuarioBuscado.Nome = novoUsuario.Nome;
                usuarioBuscado.Email = novoUsuario.Email;
                usuarioBuscado.Senha = novoUsuario.Senha;
            }

            ctx.Usuarios.Update(usuarioBuscado);
            ctx.SaveChanges();

        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(usuario => usuario.IdUsuario == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Usuarios.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Usuario> ListarTodos()
        {
            /* return ctx.Usuarios.Select(u => new Usuario
            {
                IdUsuario = u.IdUsuario,
                Nome  = u.Nome,
                Email  = u.Email,
                IdTiposUsuarioNavigation  = new TiposUsuario
                {
                    IdTiposUsuario = u.IdTiposUsuarioNavigation.IdTiposUsuario,
                    Nome = u.IdTiposUsuarioNavigation.Nome
                }
            }).ToList(); */

            return ctx.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(usuario => usuario.Email == email && usuario.Senha == senha);
        }
    }
}
