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
    public class EquipamentoController : ControllerBase
    {
        private IEquipamento _equipamentoRepository { get;  set; }

        public EquipamentoController()
        {
            _equipamentoRepository = new EquipamentosRepository();
        }

        /// <summary>
        /// Lista todos os equipamentos
        /// </summary>
        /// <returns>Retorna uma lista de equipamentos</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_equipamentoRepository.ListarTodos());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Cadastra um novo equipamento
        /// </summary>
        /// <param name="novoEquipamento">Credenciais desse equipamento</param>
        /// <returns>Retorna um StatusCode Created</returns>
        [Authorize]
        [HttpPost]
        public IActionResult Post(Equipamento novoEquipamento)
        {
            try
            {
                _equipamentoRepository.Cadastrar(novoEquipamento);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Atualiza um equipamento
        /// </summary>
        /// <param name="id">Id do equipamento que será atualizado</param>
        /// <param name="equipamentoAtualizado">Credenciais atualizadas desse equipamento</param>
        /// <returns>Retorna um StatusCode NoContent</returns>
        [Authorize(Roles = "1")]
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Equipamento equipamentoAtualizado)
        {
            try
            {
                _equipamentoRepository.Atualizar(id, equipamentoAtualizado);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Deleta um equipamento
        /// </summary>
        /// <param name="id">Id do equipamento que será deletado</param>
        /// <returns>Retorna um Status Code NoContent</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _equipamentoRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


    }
}
