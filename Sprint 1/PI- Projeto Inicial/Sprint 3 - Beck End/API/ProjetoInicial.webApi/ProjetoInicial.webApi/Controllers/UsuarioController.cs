using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoInicial.webApi.Interfaces;
using ProjetoInicial.webApi.Repositories;
using ProjetoInicial.webApi.Domains;
using Microsoft.AspNetCore.Authorization;

namespace ProjetoInicial.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuario _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

       /// <summary>
       /// Método Get para listar todos os usuários
       /// </summary>
       /// <returns>Retorna uma lista de usuários com seu Nome e Email</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_usuarioRepository.ListarTodos());
            }
            catch (Exception er)
            {
                return BadRequest(er);
            }
        }

        /// <summary>
        /// Método HTTP que será responsável por passar os dados através de um Objeto JSON e cadastrar um novo usuário no Banco de dados
        /// </summary>
        /// <param name="novoUsuario">Dados do novo usuário, passados pelo administrador do sistema.</param>
        /// <returns>Retorna um StatusCode 201 caso o cadastro tenha sucesso!</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            try
            {

                _usuarioRepository.Cadastrar(novoUsuario);

                return StatusCode(201);

            }catch(Exception er)
            {
                return BadRequest(er);
            }
        }

        /// <summary>
        /// Método responsável por captar dados informados pelo Administrador do sistema e atualizar o Banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usuarioAtualizado"></param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Usuario usuarioAtualizado)
        {
            try
            {
                _usuarioRepository.Atualizar(id, usuarioAtualizado);

                return StatusCode(202);

            }catch(Exception er)
            {
                return BadRequest(er);
            }
        }

        /// <summary>
        /// Método responsável por Receber o id do usuário que será deletado
        /// </summary>
        /// <param name="id">Id do usuário selecionado</param>
        /// <returns>Retorna um statusCode de 204 caso a exclusão do usuário aconteça</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {

                _usuarioRepository.Deletar(id);

                return StatusCode(204);

            }catch(Exception er)
            {
                return BadRequest(er);
            }
        }
    }
}
