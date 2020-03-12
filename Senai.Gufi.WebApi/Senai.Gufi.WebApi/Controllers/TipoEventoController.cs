using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    public class TipoEventoController : ControllerBase
    {
        private ITipoEventoRepository _tipoEventoRepository { get; set; }

        public TipoEventoController()
        {
            _tipoEventoRepository = new TipoEventoRepository();
        }

        /// <summary>
        /// Lista todos os tipos de eventos
        /// </summary>
        /// <returns>Retorna todos os tipos de eventos</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoEventoRepository.Listar());
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
            return Ok(_tipoEventoRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo tipo de evento
        /// </summary>
        /// <param name="novoTipoEvento">Nome do tipo de evento que será cadastrado</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        //[Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(TipoEvento novoTipoEvento)
        {
            _tipoEventoRepository.Cadastrar(novoTipoEvento);
            
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
        public IActionResult Put(int id, TipoEvento tipoEventoAtualizado)
        {
            TipoEvento tipoEventoBuscado = _tipoEventoRepository.BuscarPorId(id);

            if (tipoEventoBuscado == null)
            {
                return NotFound
                    (
                        new
                        {
                            mensagem = "Tipo de Evento não encontrado",
                            erro = true
                        }
                    );
            }
            try
            {
                _tipoEventoRepository.Atualizar(id, tipoEventoAtualizado);
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
            _tipoEventoRepository.Deletar(id);

            return Ok("Tipo de Evento Deletado");
        }

    }
}