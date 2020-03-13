using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Repositories
{
    public class PresencaRepository : IPresencaRepository
    {
        GufiContext ctx = new GufiContext();

        public List<Presencas> Listar()
        {
            return ctx.Presencas.ToList();
        }
    }
}
