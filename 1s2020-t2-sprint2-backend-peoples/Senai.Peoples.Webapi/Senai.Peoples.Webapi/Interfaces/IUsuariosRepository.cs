using Senai.Peoples.Webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.Webapi.Interfaces
{
    interface IUsuariosRepository
    {
        List<UsuarioDomain> Listar();

        UsuarioDomain GetById(int id);

        void Cadastrar(UsuarioDomain usuario);

        void Atualizar(int id, UsuarioDomain usuario);

        void Deletar(int id);

        UsuarioDomain BuscarPorEmailSenha(string email, string senha);
    }
}
