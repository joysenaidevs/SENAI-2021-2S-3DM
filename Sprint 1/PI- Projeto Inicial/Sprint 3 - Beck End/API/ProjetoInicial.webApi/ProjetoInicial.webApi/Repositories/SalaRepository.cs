using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoInicial.webApi.Domains;
using ProjetoInicial.webApi.Interfaces;
using ProjetoInicial.webApi.Contexts;

namespace ProjetoInicial.webApi.Repositories
{
    public class SalaRepository : ISala
    {

        primeiroProjetoContext ctx = new primeiroProjetoContext();
        public void Atualizar(int id, Sala salaAtualizada)
        {
            Sala salaBuscada = ctx.Salas.Find(id);

            if(salaBuscada != null)
            {
                salaBuscada.Andar = salaAtualizada.Andar;
                salaBuscada.Metragem = salaAtualizada.Metragem;
                salaBuscada.Nome = salaAtualizada.Nome;
            }

            ctx.Salas.Update(salaBuscada);

            ctx.SaveChanges();
        }

        public void Cadastrar(Sala novaSala)
        {
            ctx.Salas.Add(novaSala);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Sala salaBuscada = ctx.Salas.Find(id);

            if(salaBuscada != null)
            {
                ctx.Salas.Remove(salaBuscada);

                ctx.SaveChanges();
            }
        }

        public List<Sala> Listar()
        {
            return ctx.Salas.ToList();
        }

        public List<Sala> ListarTodos(int id)
        {

            Sala sala = ctx.Salas.FirstOrDefault(sala => sala.IdUsuario == id);

            return ctx.Salas
                 .Where(c => c.IdUsuario == sala.IdUsuario)
                 .ToList();
        }
    }
}
