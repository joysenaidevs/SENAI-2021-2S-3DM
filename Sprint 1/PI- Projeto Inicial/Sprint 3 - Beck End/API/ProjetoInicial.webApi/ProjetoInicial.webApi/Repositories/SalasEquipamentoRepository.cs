using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoInicial.webApi.Domains;
using ProjetoInicial.webApi.Interfaces;
using ProjetoInicial.webApi.Contexts;

namespace ProjetoInicial.webApi.Repositories
{
    public class SalasEquipamentoRepository : ISalasEquipamento
    {

        primeiroProjetoContext ctx = new primeiroProjetoContext();

        public void Atualizar(int id, SalasEquipamento salaEquipamentoAtualizada)
        {
            SalasEquipamento salaEquipamentoBuscado = ctx.SalasEquipamentos.Find(id);

            if(salaEquipamentoBuscado.IdSala != 0 || salaEquipamentoBuscado.IdEquipamento != 0)
            {
                salaEquipamentoBuscado.IdSala = salaEquipamentoAtualizada.IdSala;
                salaEquipamentoBuscado.IdEquipamento = salaEquipamentoAtualizada.IdEquipamento;
            }

            ctx.SalasEquipamentos.Update(salaEquipamentoBuscado);

            ctx.SaveChanges();
        }

        public void Cadastrar(SalasEquipamento novaSalaEquipamento)
        {
            ctx.SalasEquipamentos.Add(novaSalaEquipamento);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            SalasEquipamento salasEquipamentoBuscado = ctx.SalasEquipamentos.Find(id);

            if(salasEquipamentoBuscado != null)
            {
                ctx.SalasEquipamentos.Remove(salasEquipamentoBuscado);

                ctx.SaveChanges();
            }

            
        }

        public List<SalasEquipamento> ListarTodos()
        {
            ///Realizar SELECT na sala equipamentos para serem listados
            ///
            return ctx.SalasEquipamentos.Select(u => new SalasEquipamento
            {
                IdEquipamentoNavigation = new Equipamento
                {
                    IdEquipamento = u.IdEquipamentoNavigation.IdEquipamento,
                    Marca = u.IdEquipamentoNavigation.Marca,
                    Descricao = u.IdEquipamentoNavigation.Descricao,
                    NumeroSerie = u.IdEquipamentoNavigation.NumeroSerie
                },
                
                IdSalaNavigation = new Sala
                {
                    IdSala = u.IdSalaNavigation.IdSala,
                    Nome = u.IdSalaNavigation.Nome,
                    Metragem = u.IdSalaNavigation.Metragem,
                    Andar = u.IdSalaNavigation.Andar
                }

            }).ToList();
        }
    }
}
