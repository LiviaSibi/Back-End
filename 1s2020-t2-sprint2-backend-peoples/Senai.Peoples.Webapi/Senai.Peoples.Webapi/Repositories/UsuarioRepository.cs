using Senai.Peoples.Webapi.Domains;
using Senai.Peoples.Webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.Webapi.Repositories
{
    public class UsuarioRepository : IUsuariosRepository
    {
        private string StringConexao = "Data Source=DEV10\\SQLEXPRESS; initial catalog=M_Peoples; user Id=sa; pwd=sa@132";

        public List<UsuarioDomain> Listar()
        {
            List<UsuarioDomain> usuarios = new List<UsuarioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query =  "SELECT IDUsuario, Email, Senha, Usuarios.IDTipoUsuario, TipoUsuarios.Titulo AS TipoUsuario FROM Usuarios " +
                                "INNER JOIN TipoUsuarios ON Usuarios.IDUsuario = TipoUsuarios.IDTipoUsuario";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain
                        {
                            IDUsuario = Convert.ToInt32(rdr[0]),
                            Email = rdr[1].ToString(),
                            Senha = rdr[2].ToString(),
                            IDTipoUsuario = Convert.ToInt32(rdr[3]),

                            TipoUsuario = new TipoUsuariosDomain
                            {
                                IDTipoUsuario = Convert.ToInt32(rdr[0]),
                                Titulo = rdr[1].ToString()
                            }
                        };
                        usuarios.Add(usuario);
                    }
                }
            }
            return usuarios;
        }

        public UsuarioDomain GetById(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IDUsuario, Email, Senha, Usuarios.IDTipoUsuario, TipoUsuarios.Titulo AS TipoUsuario FROM Usuarios " +
                                "INNER JOIN TipoUsuarios ON Usuarios.IDUsuario = TipoUsuarios.IDTipoUsuario " +
                                "WHERE IDUsuario = @ID";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            IDUsuario = Convert.ToInt32(rdr[0]),
                            Email = rdr[1].ToString(),
                            Senha = rdr[2].ToString(),
                            IDTipoUsuario = Convert.ToInt32(rdr[3]),

                            TipoUsuario = new TipoUsuariosDomain
                            {
                                IDTipoUsuario = Convert.ToInt32(rdr[0]),
                                Titulo = rdr[1].ToString()
                            }
                        };
                        return usuario;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(UsuarioDomain usuario)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "INSERT INTO Usuarios(Email, Senha, IDTipoUsuario) VALUES (@Email, @Senha, @IDTipoUsuario)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("Email", usuario.Email);
                cmd.Parameters.AddWithValue("Senha", usuario.Senha);
                cmd.Parameters.AddWithValue("IDTipoUsuario", usuario.IDTipoUsuario);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Atualizar(int id, UsuarioDomain usuario)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "UPDATE Usuarios SET Email = @Email, Senha = @Senha, IDTipoUsuario = @IDTipoUsuario WHERE IDUsuario = @ID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);
                    cmd.Parameters.AddWithValue("@Senha", usuario.Senha);
                    cmd.Parameters.AddWithValue("@IDTipoUsuario", usuario.IDTipoUsuario);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "DELETE FROM Usuarios WHERE IDUsuario = @IDUsuario";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@IDUsuario", id);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT U.IDUsuario, U.Email, U.IDTipoUsuario, TU.Titulo FROM Usuarios U INNER JOIN TipoUsuarios TU ON U.IDTipoUsuario = TU.IDTipoUsuario WHERE Email = @Email AND Senha = @Senha";
                
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);
                    
                    con.Open();
                    
                    SqlDataReader rdr = cmd.ExecuteReader();
                    
                    if (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain
                        {
                            IDUsuario = Convert.ToInt32(rdr["IDUsuario"])
                            ,
                            Email = rdr["Email"].ToString()
                            ,
                            IDTipoUsuario = Convert.ToInt32(rdr["IDTipoUsuario"])
                            ,
                            TipoUsuario = new TipoUsuariosDomain
                            {
                                IDTipoUsuario = Convert.ToInt32(rdr["IDTipoUsuario"])
                                ,
                                Titulo = rdr["Titulo"].ToString()
                            }
                        };
                        return usuario;
                    }
                }
               
                return null;
            }
        }
    }
}
