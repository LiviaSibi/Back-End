using System;
using System.Collections.Generic;

namespace Senai.Gufi.WebApi.Domains
{
    public partial class Presencas
    {
        public int IdPresenca { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdEvento { get; set; }
        public string Situacao { get; set; }

        public Eventos IdEventoNavigation { get; set; }
        public Usuarios IdUsuarioNavigation { get; set; }
    }
}
