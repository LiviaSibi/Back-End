using Senai.Gufi.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Interfaces
{
    interface IUsuariosRepository
    {
        List<Usuarios> Listar();

        void Cadastrar(Usuarios novoUsuario);

        void Atualizar(int id, Usuarios usuarioAtualizado);

        void Deletar(int id);

        Usuarios BuscarPorId(int id);

        Usuarios BuscarEmailSenha(string email, string senha);
    }
}
