using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.CodeFirst.Contexts;
using Senai.InLock.WebApi.CodeFirst.Domains;
using Senai.InLock.WebApi.CodeFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.CodeFirst.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        InLockContext ctx = new InLockContext();

        public Jogos BuscarPorId(int id)
        {
            return ctx.Jogos.FirstOrDefault(e => e.IdJogo == id);
        }

        public void Cadastrar(Jogos novoJogo)
        {
            ctx.Jogos.Add(novoJogo);
            ctx.SaveChanges();
        }

        public List<Jogos> Listar()
        {
            return ctx.Jogos.ToList();
        }

        public void Atualizar(int id, Jogos jogoUpdate)
        {
            Jogos jogoBuscado = ctx.Jogos.Find(id);

            jogoBuscado.NomeJogo = jogoUpdate.NomeJogo;
            jogoBuscado.Descricao = jogoUpdate.Descricao;
            jogoBuscado.DataLancamento = jogoUpdate.DataLancamento;
            jogoBuscado.Valor = jogoUpdate.Valor;
            jogoBuscado.IdEstudio = jogoUpdate.IdEstudio;

            ctx.Jogos.Update(jogoBuscado);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Jogos jogoBuscado = ctx.Jogos.Find(id);

            ctx.Jogos.Remove(jogoBuscado);

            ctx.SaveChanges();
        }

        public List<Jogos> ListarComEstudios()
        {
            // Retorna uma lista com todas as informações dos jogos e estúdios
            return ctx.Jogos.Include(e => e.IdEstudio).ToList();
            // Outra forma de fazer: return ctx.Jogos.Include("IdEstudioNavigation").ToList();
        }

        public List<Jogos> ListarUmEstudio(int id)
        {
            return ctx.Jogos.ToList().FindAll(j => j.IdEstudio == id);
        }

    }
}
