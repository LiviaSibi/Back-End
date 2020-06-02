using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Senai.WebApi.Interfaces;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Repositories;

namespace Senai.Senatur.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PacoteController : ControllerBase
    {
        private IPacoteRepository _pacoteRepository;

        public PacoteController()
        {
            _pacoteRepository = new PacoteRepository();
        }

        /// <summary>
        /// Lista todos os pacotes
        /// </summary>
        /// <returns>Retorna todos os pacotes</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult Get()
        {
            // Retora a resposta da requisição fazendo a chamada para o método
            return Ok(_pacoteRepository.Listar());
        }

        /// <summary>
        /// Lista os pacotes por id
        /// </summary>
        /// <param name="id">Id que será buscado</param>
        /// <returns>Retorna o pacote do id buscado</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retora a resposta da requisição fazendo a chamada para o método
            return Ok(_pacoteRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo Pacote
        /// </summary>
        /// <param name="novoPacote">Nome do Pacote que será cadastrado</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Pacotes novoPacote)
        {
            // Faz a chamada para o método
            _pacoteRepository.Cadastrar(novoPacote);

            // Retorna um status code
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um pacote
        /// </summary>
        /// <param name="id">Id que será atualizado</param>
        /// <param name="pacote">Atualização dos dados do pacote</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Pacotes pacote)
        {
            Pacotes pacoteBuscado = _pacoteRepository.BuscarPorId(id);

            if (pacoteBuscado == null)
            {
                return NotFound
                    (
                        new
                        {
                            mensagem = "Pacote não encontrado",
                            erro = true
                        }
                    );
            }
            try
            {
                _pacoteRepository.Atualizar(id, pacote);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut("{id}/Propriedade")]
        public IActionResult AtualizarPropriedade(int id, Pacotes pacote)
        {
            Pacotes pacoteBuscado = _pacoteRepository.BuscarPorId(id);

            if (pacoteBuscado == null)
            {
                return NotFound
                    (
                        new
                        {
                            mensagem = "Pacote não encontrado",
                            erro = true
                        }
                    );
            }
            try
            {
                _pacoteRepository.AtualizarPropriedade(id, pacote);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta um pacote
        /// </summary>
        /// <param name="id">Id do pacote que será deletado</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _pacoteRepository.Deletar(id);
            return Ok("Pacote Deletado");
        }
    }
}