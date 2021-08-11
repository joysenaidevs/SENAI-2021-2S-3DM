using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoInicial.webApi.Domains;
using ProjetoInicial.webApi.Interfaces;
using ProjetoInicial.webApi.Contexts;

namespace ProjetoInicial.webApi.Repositories
{
    public class EquipamentosRepository : IEquipamento
    {

        primeiroProjetoContext ctx = new primeiroProjetoContext();

        public void Atualizar(int id, Equipamento equipamentoAtualizado)
        {
            Equipamento equipamentoBuscado = ctx.Equipamentos.Find(id);

            if(equipamentoBuscado != null)
            {
                equipamentoBuscado.Marca = equipamentoAtualizado.Marca;
                equipamentoBuscado.Tipo = equipamentoAtualizado.Tipo;
                equipamentoBuscado.NumeroSerie = equipamentoAtualizado.NumeroSerie;
                equipamentoBuscado.NumeroPatrimonio = equipamentoAtualizado.NumeroPatrimonio;
                equipamentoBuscado.Disponivel = equipamentoAtualizado.Disponivel;
                equipamentoBuscado.Descricao = equipamentoAtualizado.Descricao;
            }

            ctx.Equipamentos.Update(equipamentoBuscado);

            ctx.SaveChanges();

        }

        public void Cadastrar(Equipamento novoEquipamento)
        {
            ctx.Equipamentos.Add(novoEquipamento);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Equipamento equipamentoBuscado = ctx.Equipamentos.Find(id);

            if(equipamentoBuscado != null)
            {
                ctx.Equipamentos.Remove(equipamentoBuscado);
                ctx.SaveChanges();
            }
            
        }

        public Equipamento BuscarPorId(int id)
        {
            return ctx.Equipamentos.FirstOrDefault(equipamento => equipamento.IdEquipamento == id);
        }

        public List<Equipamento> ListarTodos()
        {
            return ctx.Equipamentos.ToList();
        }
    }
}
