using System;
using System.Collections.Generic;

namespace Senai.Gufi.WebApi.Domains
{
    public partial class TipoEvento
    {
        public TipoEvento()
        {
            Eventos = new HashSet<Eventos>();
        }

        public int IdTipoEvento { get; set; }
        public string TipoEvento1 { get; set; }

        public ICollection<Eventos> Eventos { get; set; }
    }
}
