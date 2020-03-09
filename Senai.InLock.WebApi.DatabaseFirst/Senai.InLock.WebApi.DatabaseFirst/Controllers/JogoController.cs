using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.DatabaseFirst.Domains;
using Senai.InLock.WebApi.DatabaseFirst.Interfaces;
using Senai.InLock.WebApi.DatabaseFirst.Repositories;

namespace Senai.InLock.WebApi.DatabaseFirst.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        private IJogoRepository _jogoRepository;

        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            // Retora a resposta da requisição fazendo a chamada para o método
            return Ok(_jogoRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retora a resposta da requisição fazendo a chamada para o método
            return Ok(_jogoRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(Jogo novoJogo)
        {
            // Faz a chamada para o método
            _jogoRepository.Cadastrar(novoJogo);

            // Retorna um status code
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Jogo jogo)
        {
            Jogo jogoBuscado = _jogoRepository.BuscarPorId(id);

            if (jogoBuscado == null)
            {
                return NotFound
                    (
                        new
                        {
                            mensagem = "Jogo não encontrado",
                            erro = true
                        }
                    );
            }
            try
            {
                _jogoRepository.Atualizar(id, jogo);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _jogoRepository.Deletar(id);
            return Ok("Jogo Deletado");
        }

        [HttpGet("Estudios")]
        public IActionResult GetEstudios()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_jogoRepository.ListarComEstudios());
        }

        [HttpGet("Estudios/{id}")]
        public IActionResult GetUmEstudio(int id)
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_jogoRepository.ListarUmEstudio(id));
        }
    }
}