using Senai.InLock.WebApi.DatabaseFirst.Domains;
using Senai.InLock.WebApi.DatabaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DatabaseFirst.Repositories
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

        //public void Atualizar(int id, TipoUsuario tipoUsuario)
        //{
        //    ctx.TipoUsuario.FirstOrDefault(e => e.IdTipoUsuario == id);

        //    ctx.TipoUsuario.UpdateRange(id, tipoUsuario);

       //     ctx.SaveChanges();
       // }

        //public void Deletar(int id)
        //{
        //    ctx.TipoUsuario.Remove();
        //}
    }
}
