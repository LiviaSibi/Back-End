using Senai.InLock.WebApi.DatabaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DatabaseFirst.Interfaces
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
