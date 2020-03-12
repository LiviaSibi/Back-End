using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.CodeFirst.Domains;
using Senai.InLock.WebApi.CodeFirst.Interfaces;
using Senai.InLock.WebApi.CodeFirst.Repositories;

namespace Senai.InLock.WebApi.CodeFirst.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository;

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            // Retora a resposta da requisição fazendo a chamada para o método
            return Ok(_estudioRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retora a resposta da requisição fazendo a chamada para o método
            return Ok(_estudioRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(Estudios novoEstudio)
        {
            // Faz a chamada para o método
            _estudioRepository.Cadastrar(novoEstudio);

            // Retorna um status code
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Estudios estudio)
        {
            Estudios estudioBuscado = _estudioRepository.BuscarPorId(id);
        
            if (estudioBuscado == null)
            {
                return NotFound
                    (
                        new
                        {
                            mensagem = "Estudio não encontrado",
                            erro = true
                        }
                    );
            }
            try
            {
                _estudioRepository.Atualizar(id, estudio);
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
            _estudioRepository.Deletar(id);
            return Ok("Estudio Deletado");
        }

        [HttpGet("Jogos")]
        public IActionResult GetJogos()
        {
            return Ok(_estudioRepository.ListarJogos());
        }
    }
}