using System;
using System.Collections.Generic;

namespace Senai.Gufi.WebApi.Domains
{
    public partial class Instituicao
    {
        public Instituicao()
        {
            Eventos = new HashSet<Eventos>();
        }

        public int IdInstituicao { get; set; }
        public string Cnpj { get; set; }
        public string NomeFantasia { get; set; }
        public string Endereco { get; set; }

        public ICollection<Eventos> Eventos { get; set; }
    }
}
