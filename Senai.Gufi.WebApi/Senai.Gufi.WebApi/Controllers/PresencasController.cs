using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufi.WebApi.Interfaces;
using Senai.Gufi.WebApi.Repositories;

namespace Senai.Gufi.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PresencasController : ControllerBase
    {
        private IPresencaRepository _presencaRepository { get; set; }

        public PresencasController()
        {
            _presencaRepository = new PresencaRepository();
        }

        /// <summary>
        /// Lista todas as presenças
        /// </summary>
        /// <returns>Retorna todas as presenças</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_presencaRepository.Listar());
        }
    }
}