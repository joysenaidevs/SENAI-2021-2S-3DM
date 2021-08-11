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
    public class TiposUsuarioController : ControllerBase
    {
        private ITiposUsuario _tiposUsuarioRepository { get; set; }

        public TiposUsuarioController()
        {
            _tiposUsuarioRepository = new TiposUsuarioRepository();
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {

                return Ok(_tiposUsuarioRepository.ListarTodos());

            } catch(Exception er)
            {
                return BadRequest(er);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(TiposUsuario novoTipo)
        {
            try
            {

                _tiposUsuarioRepository.Cadastrar(novoTipo);

                return StatusCode(200);
            } catch(Exception er)
            {
                return BadRequest(er);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, TiposUsuario tipoAtualizado)
        {
            try
            {
                _tiposUsuarioRepository.Atualizar( id, tipoAtualizado);

                return StatusCode(200);
            } catch(Exception er)
            {
                return BadRequest(er);
            }
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _tiposUsuarioRepository.Deletar(id);

                return StatusCode(200);
            }catch(Exception er)
            {
                return BadRequest(er);
            }
        }
    }
}
