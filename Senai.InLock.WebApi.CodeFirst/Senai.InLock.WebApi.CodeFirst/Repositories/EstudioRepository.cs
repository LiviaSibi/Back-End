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
    public class EstudioRepository : IEstudioRepository
    {
        InLockContext ctx = new InLockContext();

        public Estudios BuscarPorId(int id)
        {
            // Retorna o primeiro estúdio encontrado para o ID informado
            return ctx.Estudios.FirstOrDefault(e => e.IdEstudio == id);
        }

        public void Cadastrar(Estudios novoEstudio)
        {
            // Adiciona este novoEstudio
            ctx.Estudios.Add(novoEstudio);
            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public List<Estudios> Listar()
        {
            // Retorna uma lista com todas as informações dos estúdios
            return ctx.Estudios.ToList();
        }

        public void Atualizar(int id, Estudios estudio)
        {
            Estudios estudioBuscado = ctx.Estudios.Find(id);

            estudioBuscado.NomeEstudio = estudio.NomeEstudio;

            ctx.Estudios.Update(estudioBuscado);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Estudios estudioBuscado = ctx.Estudios.Find(id);

            ctx.Estudios.RemoveRange(estudioBuscado);

            ctx.SaveChanges();
        }

        public List<Estudios> ListarJogos()
        {
            //Junção de duas tabelas (Include)
            return ctx.Estudios.Include(e => e.Jogos).ToList();
        }
    }
}
