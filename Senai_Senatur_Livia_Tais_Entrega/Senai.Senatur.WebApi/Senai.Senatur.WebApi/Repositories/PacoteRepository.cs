using Senai.Senai.WebApi.Interfaces;
using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    public class PacoteRepository : IPacoteRepository
    {
        SenaturContext ctx = new SenaturContext();


        public void Atualizar(int id, Pacotes pacoteAtualizado)
        {
            Pacotes pacoteBuscado = ctx.Pacotes.Find(id);
            
            if (pacoteAtualizado.NomePacote != null)
            {
                pacoteBuscado.NomePacote = pacoteAtualizado.NomePacote;
            }
            if (pacoteAtualizado.Descricao != null)
            {
                pacoteBuscado.Descricao = pacoteAtualizado.Descricao;
            }
            if (pacoteAtualizado.DataIda != null)
            {
                pacoteBuscado.DataIda = pacoteAtualizado.DataIda;
            }
            if (pacoteAtualizado.DataVolta != null)
            {
                pacoteBuscado.DataVolta = pacoteAtualizado.DataVolta;
            }
            if (pacoteAtualizado.Valor != 0)
            {
                pacoteBuscado.Valor = pacoteAtualizado.Valor;
            }
            if (pacoteAtualizado.Ativo == true || pacoteAtualizado.Ativo == false)
            {
                pacoteBuscado.Ativo = pacoteAtualizado.Ativo;
            }
            if (pacoteAtualizado.NomeCidade != null)
            {
                pacoteBuscado.NomeCidade = pacoteAtualizado.NomeCidade;
            }
            ctx.Pacotes.Update(pacoteBuscado);

            ctx.SaveChanges();
        }

        public void AtualizarPropriedade(int id, Pacotes pacoteAtualizado)
        {
            Pacotes pacoteBuscado = ctx.Pacotes.Find(id);

            pacoteBuscado.NomePacote = pacoteAtualizado.NomePacote;
            pacoteBuscado.Descricao = pacoteAtualizado.Descricao;
            pacoteBuscado.DataIda = pacoteAtualizado.DataIda;
            pacoteBuscado.DataVolta = pacoteAtualizado.DataVolta;
            pacoteBuscado.Valor = pacoteAtualizado.Valor;
            pacoteBuscado.Ativo = pacoteAtualizado.Ativo;
            pacoteBuscado.NomeCidade = pacoteAtualizado.NomeCidade;

            ctx.Entry(pacoteAtualizado).Property(p => p.NomePacote).IsModified= true;
            ctx.Entry(pacoteAtualizado).Property(p => p.Descricao).IsModified = true;
            ctx.Entry(pacoteAtualizado).Property(p => p.DataIda).IsModified = true;
            ctx.Entry(pacoteAtualizado).Property(p => p.DataVolta).IsModified = true;
            ctx.Entry(pacoteAtualizado).Property(p => p.Valor).IsModified = true;
            ctx.Entry(pacoteAtualizado).Property(p => p.Ativo).IsModified = true;
            ctx.Entry(pacoteAtualizado).Property(p => p.NomeCidade).IsModified = true;

            ctx.SaveChanges();
        }

        public void Cadastrar(Pacotes cadastrarPacote)
        {
            ctx.Pacotes.Add(cadastrarPacote);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Pacotes pacoteBuscado = ctx.Pacotes.Find(id);

            ctx.Pacotes.Remove(pacoteBuscado);

            ctx.SaveChanges();
        }

        public Pacotes BuscarPorId(int id)
        {
            // Retorna o primeiro estúdio encontrado para o ID informado
            return ctx.Pacotes.FirstOrDefault(p => p.IdPacote == id);
        }

        public List<Pacotes> Listar()
        {
            return ctx.Pacotes.ToList();
        }
    }
}
