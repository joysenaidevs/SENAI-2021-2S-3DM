using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoInicial.webApi.Domains;

namespace ProjetoInicial.webApi.Interfaces
{
    interface IEquipamento
    {
        List<Equipamento> ListarTodos();

        void Cadastrar(Equipamento novoEquipamento);

        void Atualizar(int id, Equipamento equipamentoAtualizado);

        void Deletar(int id);

        Equipamento BuscarPorId(int id);
    }
}
