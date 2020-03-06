using Senai.InLock.WebApi.DatabaseFirst.Domains;
using Senai.InLock.WebApi.DatabaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DatabaseFirst.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        InLockContext ctx = new InLockContext();

        public Estudio BuscarPorId(int id)
        {
            // Retorna o primeiro estúdio encontrado para o ID informado
            return ctx.Estudio.FirstOrDefault(e => e.IdEstudio == id);
        }

        public void Cadastrar(Estudio novoEstudio)
        {
            // Adiciona este novoEstudio
            ctx.Estudio.Add(novoEstudio);
            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public List<Estudio> Listar()
        {
            // Retorna uma lista com todas as informações dos estúdios
            return ctx.Estudio.ToList();
        }

        //public void Atualizar(int id, Estudio estudio)
        //{
        //    ctx.Estudio.FirstOrDefault(e => e.IdEstudio == id);

        //    ctx.Estudio.UpdateRange(id, estudio);

        //    ctx.SaveChanges();
        //}

        //public void Deletar(int id)
        //{
        //    ctx.Estudio.FirstOrDefault(e => e.IdEstudio == id);
        //    ctx.Estudio.RemoveRange(id);
        //}
    }
}
