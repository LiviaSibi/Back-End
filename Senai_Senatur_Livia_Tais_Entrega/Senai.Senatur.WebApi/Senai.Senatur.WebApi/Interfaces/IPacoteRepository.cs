using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Senai.Senai.WebApi.Interfaces
{
    interface IPacoteRepository
    {
        List<Pacotes> Listar();

        void Cadastrar(Pacotes cadastrarPacote);

        Pacotes BuscarPorId(int id);

        void Atualizar(int id, Pacotes pacoteAtualizado);

        void Deletar(int id);

        void AtualizarPropriedade(int id, Pacotes pacoteAtualizado);
    }
}
