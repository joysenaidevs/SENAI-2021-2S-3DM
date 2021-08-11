using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoInicial.webApi.Domains;

namespace ProjetoInicial.webApi.Interfaces
{
    interface ITiposUsuario
    {
       List<TiposUsuario> ListarTodos();

        void Cadastrar(TiposUsuario novoTipo);

        void Atualizar(int id, TiposUsuario tiposUsuarioAtualizado);

        void Deletar(int id);
    }
}
