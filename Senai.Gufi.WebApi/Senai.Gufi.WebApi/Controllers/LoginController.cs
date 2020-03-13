using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.Interfaces;
using Senai.Gufi.WebApi.Repositories;
using Senai.Gufi.WebApi.ViewModels;

namespace Senai.Gufi.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuariosRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="Login">Objeto login que contém o e-mail e a senha do usuário</param>
        /// <returns>Retorna um token com as informações do usuário</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public IActionResult Post(LoginViewModel Login)
        {
            Usuarios usuarioBuscado = _usuarioRepository.BuscarEmailSenha(Login.Email, Login.Senha);

            if (usuarioBuscado == null)
            {
                // Retorna NotFound com uma mensagem de erro
                return NotFound("E-mail ou senha inválidos");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("gufi-chave-autenticacao"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "Senai.Gufi.WebApi",
                audience: "Senai.Gufi.WebApi",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}