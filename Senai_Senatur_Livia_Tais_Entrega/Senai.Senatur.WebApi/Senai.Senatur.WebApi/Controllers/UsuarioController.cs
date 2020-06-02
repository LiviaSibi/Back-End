using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Inlock.WebApi.Repositories;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;

namespace Senai.Senatur.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Retorna todos os usuários</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            // Retora a resposta da requisição fazendo a chamada para o método
            return Ok(_usuarioRepository.Listar());
        }

        /// <summary>
        /// Lista os usuários por id
        /// </summary>
        /// <param name="id">Id que será buscado</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retora a resposta da requisição fazendo a chamada para o método
            return Ok(_usuarioRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um usuário
        /// </summary>
        /// <param name="novoUsuario">Nome do usuário que será cadastrado</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public IActionResult Post(Usuarios novoUsuario)
        {
            // Faz a chamada para o método
            _usuarioRepository.Cadastrar(novoUsuario);

            // Retorna um status code
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um usuário
        /// </summary>
        /// <param name="id">Id que será atualizado</param>
        /// <param name="usuario">Atualização dos dados do usuário</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuarios usuario)
        {
            Usuarios usuarioBuscado = _usuarioRepository.BuscarPorId(id);

            if (usuarioBuscado == null)
            {
                return NotFound
                    (
                        new
                        {
                            mensagem = "Usuario não encontrado",
                            erro = true
                        }
                    );
            }
            try
            {
                _usuarioRepository.Atualizar(id, usuario);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta um usuário
        /// </summary>
        /// <param name="id">Id do usuário que será deletado</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _usuarioRepository.Deletar(id);
            return Ok("Usuario Deletado");
        }
    }
}