using Senai.InLock.WebApi.CodeFirst.Contexts;
using Senai.InLock.WebApi.CodeFirst.Domains;
using Senai.InLock.WebApi.CodeFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.CodeFirst.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        InLockContext ctx = new InLockContext();

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuario.FirstOrDefault(e => e.IdUsuario == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuario.Add(novoUsuario);
            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuario.ToList();
        }

        public void Atualizar(int id, Usuario usuarioUpdate)
        {
            Usuario usuarioBuscado = ctx.Usuario.Find(id);

            usuarioBuscado.Email = usuarioUpdate.Email;
            usuarioBuscado.Senha = usuarioUpdate.Senha;
            usuarioBuscado.IdTipoUsuario = usuarioUpdate.IdTipoUsuario;

            ctx.Usuario.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario usuarioBuscado = ctx.Usuario.Find(id);

            ctx.Usuario.Remove(usuarioBuscado);

            ctx.SaveChanges();
        }
    }
}
