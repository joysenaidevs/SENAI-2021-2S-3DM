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
using System.IdentityModel.Tokens.Jwt;

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
                int id = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_salaRepository.ListarTodos(id));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Authorize]
        [HttpGet("listar")]
        public IActionResult GetList()
        {
            try
            {
                return Ok(_salaRepository.Listar());

            } catch (Exception er)
            {
                return BadRequest(er);
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
        [HttpPut("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Put(int id, Sala salaAtualizada)
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
        [Authorize]
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
