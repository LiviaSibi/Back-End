using Senai.InLock.WebApi.CodeFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.CodeFirst.Interfaces
{
    interface IJogoRepository
    {
        List<Jogos> Listar();

        void Cadastrar(Jogos novoJogo);

        Jogos BuscarPorId(int id);

        void Atualizar(int id, Jogos jogoUpdate);

        void Deletar(int id);

        List<Jogos> ListarComEstudios();

        List<Jogos> ListarUmEstudio(int id);
    }
}
