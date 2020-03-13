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
    public class InstituicaoController : ControllerBase
    {
        private IInstituicaoRepository _instituicaoRepository { get; set; }

        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }

        /// <summary>
        /// Lista todas as Instituições
        /// </summary>
        /// <returns>Retorna todas as Instituições</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_instituicaoRepository.Listar());
        }

        /// <summary>
        /// Lista as Instituições por id
        /// </summary>
        /// <param name="id">Id que será buscado</param>
        /// <returns>Retorna a instituição do id buscado</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_instituicaoRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra uma nova instituição
        /// </summary>
        /// <param name="novaInstituicao">Nome da instituição que será cadastrado</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        //[Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Instituicao novaInstituicao)
        {
            _instituicaoRepository.Cadastrar(novaInstituicao);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza uma instituição
        /// </summary>
        /// <param name="id">Id que será atualizado</param>
        /// <param name="instituicaoAtualizada">Atualização dos dados da instituição</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Instituicao instituicaoAtualizada)
        {
            Instituicao instituicaoBuscada = _instituicaoRepository.BuscarPorId(id);

            if (instituicaoBuscada == null)
            {
                return NotFound
                    (
                        new
                        {
                            mensagem = "Instituição não encontrado",
                            erro = true
                        }
                    );
            }
            try
            {
                _instituicaoRepository.Atualizar(id, instituicaoAtualizada);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta uma instituição
        /// </summary>
        /// <param name="id">Id da instituição que será deletado</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _instituicaoRepository.Deletar(id);

            return Ok("Tipo de Evento Deletado");
        }
    }
}