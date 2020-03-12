using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Repositories
{
    public class UsuarioRepository : IUsuariosRepository
    {
        GufiContext ctx = new GufiContext();

        public void Atualizar(int id, Usuarios usuarioAtualizado)
        {
            Usuarios usuarioBuscado = ctx.Usuarios.Find(id);

            usuarioBuscado.NomeUsuario = usuarioAtualizado.NomeUsuario;
            usuarioBuscado.Email = usuarioAtualizado.Email;
            usuarioBuscado.Senha = usuarioAtualizado.Senha;
            usuarioBuscado.DataCadastro = usuarioAtualizado.DataCadastro;
            usuarioBuscado.Genero = usuarioAtualizado.Genero;
            usuarioBuscado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;

            ctx.Usuarios.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        public Usuarios BuscarEmailSenha(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public Usuarios BuscarPorId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.IdUsuario == id);
        }

        public void Cadastrar(Usuarios novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuarios usuarioBuscado = ctx.Usuarios.Find(id);

            ctx.Usuarios.Remove(usuarioBuscado);

            ctx.SaveChanges();
        }

        public List<Usuarios> Listar()
        {
            return ctx.Usuarios.ToList();
        }
    }
}
