using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.Interfaces;
using Senai.Gufi.WebApi.Repositories;

namespace Senai.Gufi.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuariosRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista todos os usuario
        /// </summary>
        /// <returns>Retorna todos os usuarios</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usuarioRepository.Listar());
        }

        /// <summary>
        /// Lista os usuarios por id
        /// </summary>
        /// <param name="id">Id que será buscado</param>
        /// <returns>Retorna o usuario do id buscado</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_usuarioRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo usuarios
        /// </summary>
        /// <param name="novoUsuario">Nome do usuario que será cadastrado</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        //[Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Usuarios novoUsuario)
        {
            _usuarioRepository.Cadastrar(novoUsuario);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um usuario
        /// </summary>
        /// <param name="id">Id que será atualizado</param>
        /// <param name="usuarioAtualizado">Atualização dos dados do usuario</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuarios usuarioAtualizado)
        {
            Usuarios usuarioBuscado = _usuarioRepository.BuscarPorId(id);

            if (usuarioBuscado == null)
            {
                return NotFound
                    (
                        new
                        {
                            mensagem = "Usuário não encontrado",
                            erro = true
                        }
                    );
            }
            try
            {
                _usuarioRepository.Atualizar(id, usuarioAtualizado);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta um usuario
        /// </summary>
        /// <param name="id">Id do usuario que será deletado</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _usuarioRepository.Deletar(id);

            return Ok("Usuario Deletado");
        }
    }
}