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
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [Authorize(Roles = "2")]
        [HttpGet]
        public IEnumerable<TipoUsuariosDomain> Get()
        {
            return _tipoUsuarioRepository.Listar();
        }

        [Authorize(Roles = "2")]
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            TipoUsuariosDomain tipoUsuarioBuscado = _tipoUsuarioRepository.GetById(id);

            if (tipoUsuarioBuscado == null)
            {
                return NotFound("Tipo não encontrado");
            }

            return StatusCode(200, tipoUsuarioBuscado);
        }

        [Authorize(Roles = "2")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, TipoUsuariosDomain tipoUsuario)
        {
            TipoUsuariosDomain tipoUsuarioBuscado = _tipoUsuarioRepository.GetById(id);

            if (tipoUsuarioBuscado == null)
            {
                return NotFound
                    (
                        new
                        {
                            mensagem = "Tipo não encontrado",
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

        [Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _tipoUsuarioRepository.Deletar(id);
            return Ok("Tipo deletado");
        }
    }
}