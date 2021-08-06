using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoInicial.webApi.Interfaces;
using ProjetoInicial.webApi.Repositories;
using ProjetoInicial.webApi.Domains;
using ProjetoInicial.webApi.ViewModels;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace ProjetoInicial.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuario _usuarioRepository { get;  set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try{
                Usuario usuario = _usuarioRepository.Login(login.Email, login.Senha);
                if(usuario == null)
                {
                    return NotFound("E-mail e/ou senha inválidos!");
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuario.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuario.IdTiposUsuario.ToString()),
                    new Claim("role", usuario.IdTiposUsuario.ToString())
                };


                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("projetoInicial-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "ProjetoInicial.WebApi",
                    audience: "ProjetoInicial.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddHours(2),
                    signingCredentials: creds
                    );




                return Ok(
                        new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token)
                        }
                    );

            } catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
