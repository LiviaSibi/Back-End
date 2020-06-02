using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repository
{
    public class EstudioRepository : IEstudioRepository
    {
        private string StringConexao = "Data Source=DEV10\\SQLEXPRESS; initial catalog= InLock_Games_M; user Id=sa; pwd=sa@132";

        /// <summary>
        /// Lista todos os estúdios
        /// </summary>
        /// <returns>Retorna todos os estudios</returns>
        public List<EstudioDomain> Listar()
        {
            List<EstudioDomain> estudios = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IdEstudio, NomeEstudio FROM Estudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain
                        {
                            IdEstudio = Convert.ToInt32(rdr[0]),
                            NomeEstudio = rdr[1].ToString()
                        };
                        estudios.Add(estudio);
                    }
                }
            }
            return estudios;
        }

        /// <summary>
        /// Cadastra um novo estúdio
        /// </summary>
        /// <param name="cadastrarEstudio">Novo estúdio que será cadastrados</param>
        public void Cadastrar(EstudioDomain cadastrarEstudio)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "INSERT INTO Estudio (NomeEstudio) VALUES (@NomeEstudio)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@NomeEstudio", cadastrarEstudio.NomeEstudio);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
