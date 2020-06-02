using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repository
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private string StringConexao = "Data Source=DEV10\\SQLEXPRESS; initial catalog=InLock_Games_M; user Id=sa; pwd=sa@132";

        /// <summary>
        /// Lista todos os tipos de usuário
        /// </summary>
        /// <returns>Retorna todos os tipos</returns>
        public List<TipoUsuarioDomain> Listar()
        {
            List<TipoUsuarioDomain> tipoUsuarios = new List<TipoUsuarioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IdTipoUsuario, Titulo FROM TipoUsuario";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr[0]),
                            Titulo = rdr[1].ToString()
                        };
                        tipoUsuarios.Add(tipoUsuario);
                    }
                }
            }
            return tipoUsuarios;
        }
    }
}
