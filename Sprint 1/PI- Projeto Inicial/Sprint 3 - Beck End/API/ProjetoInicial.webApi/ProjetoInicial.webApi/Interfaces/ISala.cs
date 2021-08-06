using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoInicial.webApi.Domains;

namespace ProjetoInicial.webApi.Interfaces
{
    interface ISala
    {
        List<Sala> ListarTodos();

        void Cadastrar(Sala novaSala);

        void Atualizar(int id, Sala salaAtualizada);

        void Deletar(int id);

    }
}
