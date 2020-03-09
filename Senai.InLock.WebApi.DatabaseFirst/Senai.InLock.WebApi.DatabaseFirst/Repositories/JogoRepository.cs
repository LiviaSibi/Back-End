using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.DatabaseFirst.Domains;
using Senai.InLock.WebApi.DatabaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DatabaseFirst.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        InLockContext ctx = new InLockContext();

        public Jogo BuscarPorId(int id)
        {
            return ctx.Jogo.FirstOrDefault(e => e.IdJogo == id);
        }

        public void Cadastrar(Jogo novoJogo)
        {
            ctx.Jogo.Add(novoJogo);
            ctx.SaveChanges();
        }

        public List<Jogo> Listar()
        {
            return ctx.Jogo.ToList();
        }

        public void Atualizar(int id, Jogo jogoUpdate)
        {
            Jogo jogoBuscado = ctx.Jogo.Find(id);

            jogoBuscado.NomeJogo = jogoUpdate.NomeJogo;
            jogoBuscado.Descricao = jogoUpdate.Descricao;
            jogoBuscado.DataLancamento = jogoUpdate.DataLancamento;
            jogoBuscado.Valor = jogoUpdate.Valor;
            jogoBuscado.IdEstudio = jogoUpdate.IdEstudio;

            ctx.Jogo.Update(jogoBuscado);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Jogo jogoBuscado = ctx.Jogo.Find(id);

            ctx.Jogo.Remove(jogoBuscado);

            ctx.SaveChanges();
        }

        public List<Jogo> ListarComEstudios()
        {
            // Retorna uma lista com todas as informações dos jogos e estúdios
            return ctx.Jogo.Include(e => e.IdEstudioNavigation).ToList();
            // Outra forma de fazer: return ctx.Jogos.Include("IdEstudioNavigation").ToList();
        }

        public List<Jogo> ListarUmEstudio(int id)
        {
            return ctx.Jogo.ToList().FindAll(j => j.IdEstudio == id);
        }

    }
}
