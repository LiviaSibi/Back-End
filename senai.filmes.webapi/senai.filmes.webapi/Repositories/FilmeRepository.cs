using senai.filmes.webapi.Domains;
using senai.filmes.webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.filmes.webapi.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string StringConexao = "Data Source=DEV10\\SQLEXPRESS; initial catalog=Filmes; user Id=sa; pwd=sa@132";

        //Listar todos
        public List<FilmeDomain> Listar()
        {
            List<FilmeDomain> filmes = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IDFilme, Titulo, Filme.IDGenero, Genero.Nome FROM Filme INNER JOIN Genero ON Filme.IDGenero = Genero.IDGenero ORDER BY Titulo DESC";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IDFilme = Convert.ToInt32(rdr[0]),
                            Titulo = rdr[1].ToString(),
                            IDGenero = Convert.ToInt32(rdr[2]),
                            Genero = new GeneroDomain
                            {
                                IDGenero = Convert.ToInt32(rdr[2]),
                                Nome = rdr[3].ToString()
                            }
                        };

                        filmes.Add(filme);
                    }
                }
            }
            return filmes;
        }

        //Listar por ID
        public FilmeDomain GetById(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IDFilme, Titulo, Filme.IDGenero, Genero.Nome FROM Filme INNER JOIN Genero ON Filme.IDGenero = Genero.IDGenero WHERE IDFilme = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IDFilme = Convert.ToInt32(rdr[0]),
                            Titulo = rdr[1].ToString(),
                            IDGenero = Convert.ToInt32(rdr[2]),
                            Genero = new GeneroDomain
                            {
                                IDGenero = Convert.ToInt32(rdr[2]),
                                Nome = rdr[3].ToString()
                            }
                        };
                        return filme;
                    }
                    return null;
                }
            }
        }

        //Cadastrar
        public void Cadastrar(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "INSERT INTO Filme(Titulo, IDGenero) VALUES (@Titulo, @ID)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                cmd.Parameters.AddWithValue("@ID", filme.IDGenero);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //Deletar
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "DELETE FROM Filme WHERE IDFilme=@ID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //Update por ID
        public void AtualizarUrl(int id, FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "UPDATE Filme SET Titulo = @Titulo, IDGenero = @IDGenero WHERE IDFilme = @ID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@IDGenero", filme.IDGenero);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //Listar por titulo de filme
        public FilmeDomain GetByName(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IDFilme, Titulo, Filme.IDGenero, Genero.Nome FROM Filme INNER JOIN Genero ON Filme.IDGenero = Genero.IDGenero WHERE Filme.Titulo = @Titulo";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FilmeDomain Filme = new FilmeDomain
                        {
                            IDFilme = Convert.ToInt32(rdr[0]),
                            Titulo = rdr[1].ToString(),
                            IDGenero = Convert.ToInt32(rdr[2]),
                            Genero = new GeneroDomain
                            {
                                IDGenero = Convert.ToInt32(rdr[2]),
                                Nome = rdr[3].ToString()
                            }
                        };
                        return Filme;
                    }
                    return null;
                }
            }
        }
    }
}
