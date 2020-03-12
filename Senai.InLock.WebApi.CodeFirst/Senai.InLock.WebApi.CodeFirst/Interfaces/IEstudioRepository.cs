using Senai.InLock.WebApi.CodeFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.CodeFirst.Interfaces
{
    interface IEstudioRepository
    {
        List<Estudios> Listar();

        void Cadastrar(Estudios novoEstudio);

        Estudios BuscarPorId(int id);

        void Atualizar(int id, Estudios estudio);

        void Deletar(int id);

        List<Estudios> ListarJogos();
    }
}
