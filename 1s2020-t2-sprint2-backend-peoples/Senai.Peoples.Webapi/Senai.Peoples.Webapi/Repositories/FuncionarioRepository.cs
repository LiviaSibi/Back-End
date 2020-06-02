using Senai.Peoples.Webapi.Domains;
using Senai.Peoples.Webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.Webapi.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private string StringConexao = "Data Source=DEV10\\SQLEXPRESS; initial catalog=M_Peoples; user Id=sa; pwd=sa@132";

        //Listar todos
        public List<FuncionarioDomain> Listar()
        {
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IDFuncionario, Nome, Sobrenome, DataNascimento FROM Funcionarios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IDFuncionario = Convert.ToInt32(rdr[0]),
                            Nome = rdr[1].ToString(),
                            Sobrenome = rdr[2].ToString(),
                            DataNascimento = Convert.ToDateTime(rdr[3])
                        };

                        funcionarios.Add(funcionario);
                    }
                }
            }
            return funcionarios;
        }

        //Cadastrar
        public void Cadastrar(FuncionarioDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "INSERT INTO Funcionarios(Nome, Sobrenome, DataNascimento) VALUES (@Nome, @Sobrenome, @DataNascimento)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);
                cmd.Parameters.AddWithValue("@DataNascimento", funcionario.DataNascimento);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //Listar pelo ID na URL
        public FuncionarioDomain GetById(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IDFuncionario, Nome, Sobrenome, DataNascimento FROM Funcionarios WHERE IDFuncionario = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IDFuncionario = Convert.ToInt32(rdr[0]),
                            Nome = rdr[1].ToString(),
                            Sobrenome = rdr[2].ToString(),
                            DataNascimento = Convert.ToDateTime(rdr[3])
                        };
                        return funcionario;
                    }
                    return null;
                }
            }
        }

        //Atualizar pela URL
        public void AtualizarUrl(int id, FuncionarioDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "UPDATE Funcionarios SET Nome = @Nome, Sobrenome = @Sobrenome, DataNascimento = @DataNascimento WHERE IDFuncionario = @ID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);
                    cmd.Parameters.AddWithValue("@DataNascimento", funcionario.DataNascimento);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //Deletar pelo ID
        public void Deletar (int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "DELETE FROM Funcionarios WHERE IDFuncionario = @ID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

        }

        //Listar pelo nome na URL
        public List<FuncionarioDomain> GetByNameUrl (string nome)
        {
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IDFuncionario, Nome, Sobrenome, DataNascimento FROM Funcionarios" + $" WHERE Nome LIKE '%{nome}%' OR Sobrenome LIKE '%{nome}%'";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IDFuncionario = Convert.ToInt32(rdr[0]),
                            Nome = rdr[1].ToString(),
                            Sobrenome = rdr[2].ToString(),
                            DataNascimento = Convert.ToDateTime(rdr[3])
                        };
                        funcionarios.Add(funcionario);
                    }
                }
            }
            return funcionarios;
        }

        public List<FuncionarioDomain> NomesCompletos()
        {
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IDFuncionario, Nome, Sobrenome, DataNascimento FROM Funcionarios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IDFuncionario = Convert.ToInt32(rdr[0]),
                            Nome = rdr[1].ToString() + " " + rdr[2].ToString(),
                            Sobrenome = rdr[2].ToString(),
                            DataNascimento = Convert.ToDateTime(rdr[3])
                        };

                        funcionarios.Add(funcionario);
                    }
                }
            }
            return funcionarios;
        }
    }
}
