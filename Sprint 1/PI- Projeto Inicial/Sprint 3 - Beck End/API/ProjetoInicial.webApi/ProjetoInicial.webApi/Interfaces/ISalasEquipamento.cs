using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoInicial.webApi.Domains;

namespace ProjetoInicial.webApi.Interfaces
{
    interface ISalasEquipamento
    {
        List<SalasEquipamento> ListarTodos();

        void Cadastrar(SalasEquipamento novaSalaEquipamento);

        void Atualizar(int id, SalasEquipamento salaEquipamentoAtualizada);

        void Deletar(int id);
    }
}
