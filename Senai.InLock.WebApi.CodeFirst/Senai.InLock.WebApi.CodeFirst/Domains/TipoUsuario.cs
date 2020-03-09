using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.CodeFirst.Domains
{
    //Define o nome da tabela
    [Table("TipoUsuario")]
    public class TipoUsuario
    {
        //Define chave primaria
        [Key]
        //Define o auto incremento
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoUsuario { get; set; }

        //Tipo do dado
        [Column(TypeName = "VARCHAR (255)")]
        //Propriedade é obrigatória
        [Required(ErrorMessage = "O titulo do tipo de usuário é obrigatório")]
        public string Titulo { get; set; }
    }
}
