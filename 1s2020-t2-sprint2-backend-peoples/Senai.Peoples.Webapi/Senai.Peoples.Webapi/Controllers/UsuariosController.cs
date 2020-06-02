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
    public class UsuariosController : ControllerBase
    {
        private IUsuariosRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [Authorize(Roles = "2")]    // Somente o tipo de usuário 2 (administrador) pode acessar o endpoint
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usuarioRepository.Listar());
        }

        [HttpPost]
        public IActionResult Post(UsuarioDomain novoUsuario)
        {
            if (novoUsuario.Email != null)
            {
                _usuarioRepository.Cadastrar(novoUsuario);
                return StatusCode(201);
            }
            return BadRequest("Nome não digitado");
        }

        [Authorize(Roles = "2")]    // Somente o tipo de usuário 2 (administrador) pode acessar o endpoint
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.GetById(id);

            if (usuarioBuscado != null)
            {
                return Ok(usuarioBuscado);
            }

            return NotFound("Nenhum usuário encontrado para o identificador informado");
        }

        [Authorize(Roles = "2")]    // Somente o tipo de usuário 2 (administrador) pode acessar o endpoint
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, UsuarioDomain usuarioAtualizado)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.GetById(id);

            if (usuarioBuscado != null)
            {
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
            return NotFound
                (
                    new
                    {
                        mensagem = "Usuário não encontrado",
                        erro = true
                    }
                );
        }

        [Authorize(Roles = "2")]    // Somente o tipo de usuário 2 (administrador) pode acessar o endpoint
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.GetById(id);
            
            if (usuarioBuscado != null)
            {
                _usuarioRepository.Deletar(id);
                
                return Ok($"O usuário {id} foi deletado com sucesso!");
            }
            
            return NotFound("Nenhum usuário encontrado para o identificador informado");
        }
    }
}