using Senai.Peoples.Webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.Webapi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuariosDomain> Listar();

        TipoUsuariosDomain GetById(int id);

        void Atualizar(int id, TipoUsuariosDomain tipoUsuario);

        void Deletar(int id);
    }
}
