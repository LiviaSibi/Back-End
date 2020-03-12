using System;
using System.Collections.Generic;

namespace Senai.Gufi.WebApi.Domains
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Presencas = new HashSet<Presencas>();
        }

        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime? DataCadastro { get; set; }
        public string Genero { get; set; }
        public int? IdTipoUsuario { get; set; }

        public TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public ICollection<Presencas> Presencas { get; set; }
    }
}
