using System;
using System.Collections.Generic;

namespace Senai.Gufi.WebApi.Domains
{
    public partial class Eventos
    {
        public Eventos()
        {
            Presencas = new HashSet<Presencas>();
        }

        public int IdEvento { get; set; }
        public string NomeEvento { get; set; }
        public DateTime DataEvento { get; set; }
        public string Descricao { get; set; }
        public bool? AcessoLivre { get; set; }
        public int? IdInstituicao { get; set; }
        public int? IdTipoEvento { get; set; }

        public Instituicao IdInstituicaoNavigation { get; set; }
        public TipoEvento IdTipoEventoNavigation { get; set; }
        public ICollection<Presencas> Presencas { get; set; }
    }
}
