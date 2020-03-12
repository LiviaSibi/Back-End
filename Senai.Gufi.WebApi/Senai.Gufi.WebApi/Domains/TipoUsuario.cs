using System;
using System.Collections.Generic;

namespace Senai.Gufi.WebApi.Domains
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdTipoUsuario { get; set; }
        public string TipoUsuario1 { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
