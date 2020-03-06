using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    ///Tabela Filmes

namespace senai.filmes.webapi.Domains
{
    public class FilmeDomain
    {
        public int IDFilme { get; set; }

        public string Titulo { get; set; }

        public int IDGenero { get; set; }

        public GeneroDomain Genero { get; set; }
    }
}
