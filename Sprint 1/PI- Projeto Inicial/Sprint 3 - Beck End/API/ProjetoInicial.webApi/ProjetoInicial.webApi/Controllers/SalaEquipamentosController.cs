using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoInicial.webApi.Domains;
using ProjetoInicial.webApi.Interfaces;
using ProjetoInicial.webApi.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace ProjetoInicial.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SalaEquipamentosController : ControllerBase
    {
        private ISalasEquipamento _salaEquipamentosRepository { get; set; }

        public SalaEquipamentosController()
        {
            _salaEquipamentosRepository = new SalasEquipamentoRepository();
        }

        /// <summary>
        /// Método responsável por listar todas as Equipamentos em suas respectivas salas
        /// </summary>
        /// <returns>Retorna um StatusCode 201 - Ok , caso a operação dê certo</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_salaEquipamentosRepository.ListarTodos());

            }catch(Exception er)
            {
                return BadRequest(er);
            }
        }

        /// <summary>
        /// Método responsável por 
        /// </summary>
        /// <param name="novaSalaEquipamento"></param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(SalasEquipamento novaSalaEquipamento)
        {
            try
            {

                _salaEquipamentosRepository.Cadastrar(novaSalaEquipamento);

                return StatusCode(201);

            }catch(Exception er)
            {
                return BadRequest(er);
            }
        }

        /// <summary>
        /// Método Responsável por atualizar informações parciais(PATCH) dentro do Banco de dados
        /// </summary>
        /// <param name="id">id selecionado para a mudança</param>
        /// <param name="salaEquipamentoAtualizada">Novos valores</param>
        /// <returns>StatusCode de 202, caso a atualização de certo</returns>
        [Authorize(Roles = "1")]
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, SalasEquipamento salaEquipamentoAtualizada)
        {
            try
            {
                _salaEquipamentosRepository.Atualizar(id, salaEquipamentoAtualizada);

                return StatusCode(202);

            }catch(Exception er)
            {
                return BadRequest(er);
            }
        }

        /// <summary>
        /// Método responsável por deletar 
        /// </summary>
        /// <param name="id">id selecionado</param>
        /// <returns>StatusCode de 204 - caso dê certo</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _salaEquipamentosRepository.Deletar(id);

                return StatusCode(204);

            }catch(Exception er)
            {
                return BadRequest(er);
            }
        }
    }
}
