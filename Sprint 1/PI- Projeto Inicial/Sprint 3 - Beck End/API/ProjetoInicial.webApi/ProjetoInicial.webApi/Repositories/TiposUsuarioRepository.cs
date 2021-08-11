using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoInicial.webApi.Interfaces;
using ProjetoInicial.webApi.Domains;
using ProjetoInicial.webApi.Contexts;

namespace ProjetoInicial.webApi.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuario
    {

        primeiroProjetoContext ctx = new primeiroProjetoContext();

        public void Atualizar(int id, TiposUsuario tiposUsuarioAtualizado)
        {
            TiposUsuario tipoBuscado = ctx.TiposUsuarios.Find(id);

            if(tipoBuscado != null)
            {
                tipoBuscado.Nome = tiposUsuarioAtualizado.Nome;
            }

            ctx.TiposUsuarios.Update(tipoBuscado);

            ctx.SaveChanges();
        }

        public void Cadastrar(TiposUsuario novoTipo)
        {
            ctx.TiposUsuarios.Add(novoTipo);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TiposUsuario tipoBuscado = ctx.TiposUsuarios.Find(id);

            if(tipoBuscado != null)
            {
                ctx.TiposUsuarios.Remove(tipoBuscado);

                ctx.SaveChanges();
            }
        }

        public List<TiposUsuario> ListarTodos()
        {
            return ctx.TiposUsuarios.ToList();
        }
    }
}
