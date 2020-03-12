using Senai.InLock.WebApi.CodeFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.CodeFirst.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> Listar();

        void Cadastrar(Usuario novoUsuario);

        Usuario BuscarPorId(int id);

        void Atualizar(int id, Usuario usuarioAtualizado);
        
        void Deletar(int id);
    }
}
