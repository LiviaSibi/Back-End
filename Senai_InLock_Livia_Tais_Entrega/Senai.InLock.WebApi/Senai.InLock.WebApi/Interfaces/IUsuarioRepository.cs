using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<UsuarioDomain> Listar();

        void Cadastrar(UsuarioDomain cadastrarUsuario);

        UsuarioDomain BuscarEmailSenha(string email, string senha);
    }
}
