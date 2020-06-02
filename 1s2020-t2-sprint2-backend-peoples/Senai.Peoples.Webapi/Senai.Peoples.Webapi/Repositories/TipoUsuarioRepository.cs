using Senai.Peoples.Webapi.Domains;
using Senai.Peoples.Webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.Webapi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private string StringConexao = "Data Source=DEV10\\SQLEXPRESS; initial catalog=M_Peoples; user Id=sa; pwd=sa@132";

        public List<TipoUsuariosDomain> Listar()
        {
            List<TipoUsuariosDomain> tipoUsuarios = new List<TipoUsuariosDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IDTipoUsuario, Titulo FROM TipoUsuarios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TipoUsuariosDomain tipoUsuario = new TipoUsuariosDomain
                        {
                            IDTipoUsuario = Convert.ToInt32(rdr[0]),
                            Titulo = rdr[1].ToString()
                        };
                        tipoUsuarios.Add(tipoUsuario);
                    }
                }
            }
            return tipoUsuarios;
        }

        public TipoUsuariosDomain GetById(int id )
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IDTipoUsuario, Titulo FROM TipoUsuarios WHERE IDTipoUsuario = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        TipoUsuariosDomain tipoUsuario = new TipoUsuariosDomain
                        {
                            IDTipoUsuario = Convert.ToInt32(rdr[0]),
                            Titulo = rdr[1].ToString()
                        };
                        return tipoUsuario;
                    }
                    return null;
                }
            }
        }

        public void Atualizar(int id, TipoUsuariosDomain tipoUsuario)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "UPDATE TipoUsuarios SET Titulo = @Titulo WHERE IDTipoUsuario = @ID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Titulo", tipoUsuario.Titulo);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "DELETE FROM TipoUsuarios WHERE IDTipoUsuario = @ID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
