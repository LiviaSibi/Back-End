using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.CodeFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.CodeFirst.Contexts
{
    /// <summary>
    /// Classe responsável pelo contexto do projeto
    /// Faz a comunicação entre API e Banco de Dados
    /// </summary>
    public class InLockContext : DbContext
    {
        //Define as entidades do banco de dados
        public DbSet<TipoUsuario> TipoUsuario { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Estudios> Estudios { get; set; }

        public DbSet<Jogos> Jogos { get; set; }

        /// <summary>
        /// Define as opções de construção do banco
        /// </summary>
        /// <param name="optionsBuilder">Objeto com as configurações definidas</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DEV10\\SQLEXPRESS; Database=InLock_Games_CodeFirst; user Id=sa; pwd=sa@132;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoUsuario>().HasData(
                new TipoUsuario
                {
                    IdTipoUsuario = 1,
                    Titulo = "Administrador"
                },
                new TipoUsuario
                {
                    IdTipoUsuario = 2,
                    Titulo = "Cliente"
                });

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    IdUsuario =1,
                    Email = "admin@admin.com",
                    Senha = "admin",
                    IdTipoUsuario = 1
                },
                new Usuario
                {
                    IdUsuario = 2,
                    Email = "cliente@cliente.com",
                    Senha = "cliente",
                    IdTipoUsuario = 2
                });

            modelBuilder.Entity<Estudios>().HasData(
                new Estudios { IdEstudio = 1, NomeEstudio = "Blizzard" },
                new Estudios { IdEstudio = 2, NomeEstudio = "Rockstar Studios" },
                new Estudios { IdEstudio = 3, NomeEstudio = "Square Enix" });

            modelBuilder.Entity<Jogos>().HasData(
                new Jogos
                {
                    IdJogo = 1,
                    NomeJogo = "Diablo 3",
                    DataLancamento = Convert.ToDateTime("15/05/2012"),
                    Descricao = "Descrição do jogo",
                    Valor = Convert.ToDecimal("99,00"),
                    IdEstudio = 1
                },
                new Jogos
                {
                    IdJogo = 2,
                    NomeJogo = "Red Dead Redemption II",
                    DataLancamento = Convert.ToDateTime("26/10/2018"),
                    Descricao = "Descrição do jogo",
                    Valor = Convert.ToDecimal("120,00"),
                    IdEstudio = 2
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
