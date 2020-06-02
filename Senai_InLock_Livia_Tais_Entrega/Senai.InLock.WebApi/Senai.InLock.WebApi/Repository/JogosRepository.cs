using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repository
{
    public class JogosRepository : IJogosRepository
    {
        private string StringConexao = "Data Source=DEV10\\SQLEXPRESS; initial catalog=InLock_Games_M; user Id=sa; pwd=sa@132";

        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Retorna todos os jogos</returns>
        public List<JogoDomain> Listar()
        {
            List<JogoDomain> jogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IdJogo, NomeJogo, Descricao, DataLancamento, Valor, Jogo.IdEstudio, Estudio.IdEstudio, Estudio.NomeEstudio FROM Jogo " +
                                "INNER JOIN Estudio ON Jogo.IdEstudio = Estudio.IdEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain
                        {
                            IdJogo = Convert.ToInt32(rdr[0]),
                            NomeJogo = rdr[1].ToString(),
                            Descricao = rdr[2].ToString(),
                            DataLancamento = Convert.ToDateTime(rdr[3]),
                            Valor = Convert.ToDouble(rdr[4]),
                            IdEstudio = Convert.ToInt32(rdr[5]),

                            Estudio = new EstudioDomain
                            {
                                IdEstudio = Convert.ToInt32(rdr[6]),
                                NomeEstudio = rdr[7].ToString()
                            }
                        };
                        jogos.Add(jogo);
                    }
                }
            }
            return jogos;
        }

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="cadastrarJogo">Novo jogo que será cadastrado</param>
        public void Cadastrar(JogoDomain cadastrarJogo)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "INSERT INTO Jogo (NomeJogo, Descricao, DataLancamento, Valor, IdEstudio) VALUES (@NomeJogo, @Descricao, @DataLancamento, @Valor, @IdEstudio)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@NomeJogo", cadastrarJogo.NomeJogo);
                cmd.Parameters.AddWithValue("@Descricao", cadastrarJogo.Descricao);
                cmd.Parameters.AddWithValue("@DataLancamento", cadastrarJogo.DataLancamento);
                cmd.Parameters.AddWithValue("@Valor", cadastrarJogo.Valor);
                cmd.Parameters.AddWithValue("@IdEstudio", cadastrarJogo.IdEstudio);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
