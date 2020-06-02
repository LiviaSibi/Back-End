using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.Webapi.Domains;
using Senai.Peoples.Webapi.Interfaces;
using Senai.Peoples.Webapi.Repositories;

namespace Senai.Peoples.Webapi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FuncionarioController : ControllerBase
    {
        private IFuncionarioRepository _funcionarioRepository { get; set; }

        public FuncionarioController()
        {
            _funcionarioRepository = new FuncionarioRepository();
        }

        //Listar Todos
        [HttpGet]
        public IEnumerable<FuncionarioDomain> Get()
        {
            return _funcionarioRepository.Listar();
        }

        //Cadastrar com erro caso não seja digitado o nome (extra)
        [HttpPost]
        public IActionResult Cadastrar(FuncionarioDomain funcionarioRecebido)
        {
            if (funcionarioRecebido.Nome != null)
            {
                _funcionarioRepository.Cadastrar(funcionarioRecebido);
                return StatusCode(201);
            }
            return BadRequest("Nome não digitado");
        }

        //Listar pelo ID na URL
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.GetById(id);

            if (funcionarioBuscado == null)
            {
                return NotFound("Funcionario não encontrado");
            }

            return StatusCode(200, funcionarioBuscado);
        }

        //Atualizar pelo ID
        [Authorize(Roles = "2")]
        [HttpPut("{id}")]
        public IActionResult UpdateUrl(int id, FuncionarioDomain funcionario)
        {
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.GetById(id);

            if (funcionarioBuscado == null)
            {
                return NotFound
                    (
                        new
                        {
                            mensagem = "Funcionario não encontrado",
                            erro = true
                        }
                    );
            }

            try
            {
                _funcionarioRepository.AtualizarUrl(id, funcionario);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        //Deletar pelo ID
        [Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _funcionarioRepository.Deletar(id);
            return Ok("Funcionario deletado");
        }

        //Listar pelo nome na URL
        [HttpGet("buscar/{nome}")]
        public IActionResult GetByNameUrl(string nome)
        {
            return Ok(_funcionarioRepository.GetByNameUrl(nome));
        }

        [Authorize(Roles = "2")]
        [HttpGet("nomescompletos")]
        public IEnumerable<FuncionarioDomain> NomeCompleto()
        {
            return _funcionarioRepository.NomesCompletos();
        }
    }
}