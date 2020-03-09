using Senai.InLock.WebApi.DatabaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DatabaseFirst.Interfaces
{
    interface IEstudioRepository
    {
        List<Estudio> Listar();

        void Cadastrar(Estudio novoEstudio);

        Estudio BuscarPorId(int id);

        void Atualizar(int id, Estudio estudio);

        void Deletar(int id);

        List<Estudio> ListarJogos();
    }
}
