using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoInicial.webApi.Interfaces;
using ProjetoInicial.webApi.Domains;
using ProjetoInicial.webApi.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace ProjetoInicial.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        private ISala _salaRepository { get; set; }

        public SalaController()
        {
            _salaRepository = new SalaRepository();
        }

        /// <summary>
        /// Lista todas as salas
        /// </summary>
        /// <returns>Retorna uma lista de salas</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_salaRepository.ListarTodos());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Cadastra uma nova sala
        /// </summary>
        /// <param name="novaSala">Credenciais da nova sala</param>
        /// <returns>Retorna um StatusCode Created</returns>
        [HttpPost]
        [Authorize]
        public IActionResult Post(Sala novaSala)
        {
            try
            {
                _salaRepository.Cadastrar(novaSala);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Atualiza uma sala
        /// </summary>
        /// <param name="id">Id da sala que será atualizada</param>
        /// <param name="salaAtualizada">Credenciais atualizadas da sala</param>
        /// <returns>Retorna um StatusCode NoContent</returns>
        [HttpPatch("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Patch(int id, Sala salaAtualizada)
        {
            try
            {
                _salaRepository.Atualizar(id, salaAtualizada);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Deleta uma sala que será deletada
        /// </summary>
        /// <param name="id">Id da sala que será deletada</param>
        /// <returns>Retorna um StatusCode NoContent</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Delete(int id)
        {
            try
            {
                _salaRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
