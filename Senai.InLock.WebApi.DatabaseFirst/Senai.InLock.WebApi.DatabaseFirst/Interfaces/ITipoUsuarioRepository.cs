using Senai.InLock.WebApi.DatabaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DatabaseFirst.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuario> Listar();

        void Cadastrar(TipoUsuario novoTipo);

        TipoUsuario BuscarPorId(int id);

        //void Atualizar(int id, TipoUsuario tipoUsuario);

        //void Deletar(int id);
    }
}
