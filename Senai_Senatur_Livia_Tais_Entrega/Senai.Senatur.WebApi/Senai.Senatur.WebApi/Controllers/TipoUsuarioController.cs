using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using Senai.Senatur.WebApi.Repositories;

namespace Senai.Senatur.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "1")]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository;

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Lista todos os Tipos de usuário
        /// </summary>
        /// <returns>Retorna todos os tipos de usuário</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult Get()
        {
            // Retora a resposta da requisição fazendo a chamada para o método
            return Ok(_tipoUsuarioRepository.Listar());
        }

        /// <summary>
        /// Lista os tipos de usuário por id
        /// </summary>
        /// <param name="id">Id que será buscado</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retora a resposta da requisição fazendo a chamada para o método
            return Ok(_tipoUsuarioRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipoUsuario">Nome do tipo de usuário que será cadastrado</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public IActionResult Post(TiposUsuario novoTipoUsuario)
        {
            // Faz a chamada para o método
            _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);

            // Retorna um status code
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um tipo de usuário
        /// </summary>
        /// <param name="id">Id que será atualizado</param>
        /// <param name="tipoUsuario">Atualização dos dados do tipo de usuário</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, TiposUsuario tipoUsuario)
        {
            TiposUsuario tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);

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
                _tipoUsuarioRepository.Atualizar(id, tipoUsuario);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta um tipo de usuário
        /// </summary>
        /// <param name="id">Id do tipo de usuário que será deletado</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _tipoUsuarioRepository.Deletar(id);
            return Ok("Tipo de Usuário Deletado");
        }
    }
}