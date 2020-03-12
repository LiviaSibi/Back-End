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
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Lista todos os tipos de eventos
        /// </summary>
        /// <returns>Retorna todos os tipos de eventos</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoUsuarioRepository.Listar());
        }

        /// <summary>
        /// Lista os tipos de evento por id
        /// </summary>
        /// <param name="id">Id que será buscado</param>
        /// <returns>Retorna o tipos de evento do id buscado</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_tipoUsuarioRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo tipo de evento
        /// </summary>
        /// <param name="novoTipoEvento">Nome do tipo de evento que será cadastrado</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        //[Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(TipoUsuario novoTipoUsuario)
        {
            _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um Tipo de Evento
        /// </summary>
        /// <param name="id">Id que será atualizado</param>
        /// <param name="tipoEventoAtualizado">Atualização dos dados do Tipo de Evento</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            TipoUsuario tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);

            if (tipoUsuarioBuscado == null)
            {
                return NotFound
                    (
                        new
                        {
                            mensagem = "Tipo de Usuário não encontrado",
                            erro = true
                        }
                    );
            }
            try
            {
                _tipoUsuarioRepository.Atualizar(id, tipoUsuarioAtualizado);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta um Tipo de Evento
        /// </summary>
        /// <param name="id">Id do Tipo de Evento que será deletado</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _tipoUsuarioRepository.Deletar(id);

            return Ok("Tipo de Usuario Deletado");
        }
    }
}