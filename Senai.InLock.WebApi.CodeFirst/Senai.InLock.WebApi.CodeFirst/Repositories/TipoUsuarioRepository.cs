using Senai.InLock.WebApi.CodeFirst.Contexts;
using Senai.InLock.WebApi.CodeFirst.Domains;
using Senai.InLock.WebApi.CodeFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.CodeFirst.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        InLockContext ctx = new InLockContext();

        public TipoUsuario BuscarPorId(int id)
        {
            return ctx.TipoUsuario.FirstOrDefault(e => e.IdTipoUsuario == id);
        }

        public void Cadastrar(TipoUsuario novoTipo)
        {
            ctx.TipoUsuario.Add(novoTipo);
            ctx.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuario.ToList();
        }

        public void Atualizar(int id, TipoUsuario tipoUsuarioUpdate)
        {
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuario.Find(id);
            
            tipoUsuarioBuscado.Titulo = tipoUsuarioUpdate.Titulo;

            ctx.TipoUsuario.Update(tipoUsuarioBuscado);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuario.Find(id);

            ctx.TipoUsuario.Remove(tipoUsuarioBuscado);

            ctx.SaveChanges();
        }
    }
}
