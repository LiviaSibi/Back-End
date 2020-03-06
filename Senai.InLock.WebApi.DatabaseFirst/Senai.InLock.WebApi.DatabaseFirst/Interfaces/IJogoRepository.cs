using Senai.InLock.WebApi.DatabaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DatabaseFirst.Interfaces
{
    interface IJogoRepository
    {
        List<Jogo> Listar();

        void Cadastrar(Jogo novoJogo);

        Jogo BuscarPorId(int id);
    }
}
