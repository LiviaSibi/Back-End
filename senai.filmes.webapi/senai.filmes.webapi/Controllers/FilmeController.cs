using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.filmes.webapi.Domains;
using senai.filmes.webapi.Interfaces;
using senai.filmes.webapi.Repositories;

namespace senai.filmes.webapi.Controllers
{
    [Produces ("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private IFilmeRepository _filmeRepository { get; set; }

        public FilmeController()
        {
            _filmeRepository = new FilmeRepository();
        }

        //Listar Todos
        [HttpGet]
        public IEnumerable<FilmeDomain> Get()
        {
            return _filmeRepository.Listar();
        }

        //Listar por ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            FilmeDomain filmeBuscado = _filmeRepository.GetById(id);

            if (filmeBuscado == null)
            {
                return NotFound("Nenhum Filme encontrado");
            }

            return StatusCode(200, filmeBuscado);
        }

        //Cadastrar
        [HttpPost]
        public IActionResult Cadastrar(FilmeDomain filme)
        {
            _filmeRepository.Cadastrar(filme);
            return StatusCode(201);
        }

        //Deletar por ID
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _filmeRepository.Deletar(id);
            return Ok("Filme Deletado");
        }

        //Atualizar por ID
        [HttpPut("{id}")]
        public IActionResult Update(int id, FilmeDomain filme)
        {
            FilmeDomain filmeBuscado = _filmeRepository.GetById(id);

            if (filmeBuscado == null)
            {
                return NotFound
                    (
                        new
                        {
                            mensagem = "Filme não encontrado",
                            erro = true
                        }
                    );
            }

            try
            {
                _filmeRepository.AtualizarUrl(id, filme);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        //Listar por titulo de filme
        [HttpGet("buscar/")]
        public IActionResult GetByName(FilmeDomain filme)
        {
            FilmeDomain filmeBuscado = _filmeRepository.GetByName(filme);

            if (filmeBuscado == null)
            {
                return NotFound("Nenhum Filme encontrado");
            }

            return StatusCode(200, filmeBuscado);
        }
    }
}