using senai.filmes.webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.filmes.webapi.Interfaces
{

    /// <summary>
    /// Interface responsável pelo repositório Genero
    /// </summary>
   

    interface IGeneroRepository
    {
        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns> retorna uma lista de gêneros </returns>
        List<GeneroDomain> Listar();

        void Cadastrar(GeneroDomain genero);

        void Deletar(int id);

        GeneroDomain GetById(int id);

        void AtualizarUrl(int id, GeneroDomain genero);

        void AtualizarCorpo(GeneroDomain genero);

    }
}
