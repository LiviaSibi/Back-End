using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    public class JogoDomain
    {
        public int IdJogo { get; set; }

        [Required(ErrorMessage = "Informe o nome do jogo")]
        public string NomeJogo { get; set; }

        [Required(ErrorMessage = "Informe a descrição do jogo")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe a data de lançamento")]
        public DateTime DataLancamento { get; set; }

        [Required(ErrorMessage = "Informe o valor do jogo")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "Informe o estúdio")]
        public int IdEstudio { get; set; }

        public EstudioDomain Estudio { get; set; }
    }
}
