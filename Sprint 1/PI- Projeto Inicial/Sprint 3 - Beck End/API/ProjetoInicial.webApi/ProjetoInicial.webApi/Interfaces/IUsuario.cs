using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoInicial.webApi.Domains;

namespace ProjetoInicial.webApi.Interfaces
{
    interface IUsuario
    {
        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Credenciais do novo usuário cadastrado</param>/
        void Cadastrar(Usuario novoUsuario);
        /// <summary>
        /// Deleta um usuário
        /// </summary>
        /// <param name="id">Id do usuário que será deletado</param>
        void Deletar(int id);
        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Retorna uma lista de usuários</returns>///
        List<Usuario> ListarTodos();
        /// <summary>
        /// Buscar por um usuário através de seu Id
        /// </summary>
        /// <param name="id">Id do usuário que será buscado</param>
        /// <returns>Retorna um usuário</returns>
        Usuario BuscarPorId(int id);
        /// <summary>
        /// Atualiza um usuário
        /// </summary>
        /// <param name="id">Id do usuário buscado</param>
        /// <param name="novoUsuario">Credenciais do novo usuário</param>/
        void Atualizar(int id, Usuario novoUsuario);
        /// <summary>
        /// Faz login do usuário
        /// </summary>
        /// <param name="email">Email do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns></returns>
        Usuario Login(string email, string senha);
    }
}
