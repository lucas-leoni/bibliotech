using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace Repositories
{
  public class LivroRepository
  {
    static List<Models.Livro> livros = new List<Models.Livro>();

    public static void AddLivro(Models.Livro livro)
    {
      using (MySqlConnection conexao = Repositories.Conexao.ObterConexao())
      {
        try
        {
          // Abre a conexão com o banco
          conexao.Open();

          string insert_query = "INSERT INTO livro " +
          "(titulo, genero, dt_publicacao, status, id_autor, id_editora) " +
          "VALUES (@Titulo, @Genero, @DtPublicacao, @Status, @IdAutor, @IdEditora)";
          MySqlCommand comando_insert = new MySqlCommand(insert_query, conexao);

          if (livro != null)
          {
            comando_insert.Parameters.AddWithValue("@Titulo", livro.Titulo);
            comando_insert.Parameters.AddWithValue("@Genero", livro.Genero);
            comando_insert.Parameters.AddWithValue("@DtPublicacao", livro.DtPublicacao);
            comando_insert.Parameters.AddWithValue("@Status", livro.Status);
            comando_insert.Parameters.AddWithValue("@IdAutor", livro.IdAutor);
            comando_insert.Parameters.AddWithValue("@IdEditora", livro.IdEditora);

            int linhas_afetadas = comando_insert.ExecuteNonQuery();
            livro.CodLivro = Convert.ToInt32(comando_insert.LastInsertedId);

            if (linhas_afetadas > 0)
            {
              livros.Add(livro);
            }
            else
            {
              MessageBox.Show(
                "Não foi possível adicionar o livro!",
                "Erro!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
              );
            }
          }
          else
          {
            MessageBox.Show(
              "Não foi possível adicionar o livro!",
              "Erro!",
              MessageBoxButtons.OK,
              MessageBoxIcon.Error
            );
          }

          // Fecha a conexão com o banco
          conexao.Close();
        }

        catch (Exception ex)
        {
          MessageBox.Show(
            "Erro ao conectar ao banco de dados: " + ex.Message,
            "Erro!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
          );
        }
      }
    }

    public static List<Models.Livro> ListLivros()
    {
      using (MySqlConnection conexao = Repositories.Conexao.ObterConexao())
      {
        try
        {
          // Abre a conexão com o banco de dados
          conexao.Open();

          // Consulta SQL para recuperar os registros da tabela de livros
          string select_query = "SELECT * FROM livro";

          // Cria um comando MySqlCommand com a consulta SQL e a conexão
          MySqlCommand comando_select = new MySqlCommand(select_query, conexao);
          MySqlDataAdapter bdAdapter = new MySqlDataAdapter(comando_select);

          DataSet dbDataSet = new DataSet();
          bdAdapter.Fill(dbDataSet, "livro");
          DataTable table = dbDataSet.Tables["livro"];

          foreach (DataRow row in table.Rows)
          {
            // Aqui você pode acessar os dados retornados pela consulta SELECT
            Models.Livro livro = new Models.Livro();
            livro.CodLivro = Convert.ToInt32(row["cod_livro"].ToString());
            livro.Titulo = row["titulo"].ToString();
            livro.Genero = row["genero"].ToString();
            livro.DtPublicacao = Convert.ToDateTime(row["dt_publicacao"]);
            livro.Status = row["status"].ToString();
            livro.IdAutor = Convert.ToInt32(row["id_autor"].ToString());
            livro.IdEditora = Convert.ToInt32(row["id_editora"].ToString());
            livros.Add(livro);
          }

          // Fecha a conexão com o banco
          conexao.Close();
        }

        catch (Exception ex)
        {
          MessageBox.Show(
            "Erro ao conectar ao banco de dados: " + ex.Message,
            "Erro!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
          );
        }
      }
      return livros;
    }

    public static Models.Livro? GetLivro(int cod_livro)
    {
      Models.Livro livro = new Models.Livro();
      using (MySqlConnection conexao = Repositories.Conexao.ObterConexao())
      {
        try
        {
          // Abre a conexão com o banco
          conexao.Open();

          // Consulta SQL para recuperar o usuário pelo id
          string select_query = "SELECT * FROM livro WHERE cod_livro = @CodLivro";

          MySqlCommand comando_select = new MySqlCommand(select_query, conexao);

          if (cod_livro != null)
          {
            comando_select.Parameters.AddWithValue("@CodLivro", cod_livro);

            MySqlDataAdapter bdAdapter = new MySqlDataAdapter(comando_select);

            DataSet dbDataSet = new DataSet();
            bdAdapter.Fill(dbDataSet, "livro");
            DataTable table = dbDataSet.Tables["livro"];

            foreach (DataRow row in table.Rows)
            {
              // Aqui você pode acessar os dados retornados pela consulta SELECT
              livro.CodLivro = Convert.ToInt32(row["cod_livro"].ToString());
              livro.Titulo = row["titulo"].ToString();
              livro.Genero = row["genero"].ToString();
              livro.DtPublicacao = Convert.ToDateTime(row["dt_publicacao"]);
              livro.Status = row["status"].ToString();
              livro.IdAutor = Convert.ToInt32(row["id_autor"].ToString());
              livro.IdEditora = Convert.ToInt32(row["id_editora"].ToString());
            }
          }
          else
          {
            MessageBox.Show(
              "Livro não encontrado!",
              "Erro!",
              MessageBoxButtons.OK,
              MessageBoxIcon.Error
            );
          }

          // Fecha a conexão com o banco
          conexao.Close();
        }
        catch (Exception ex)
        {
          MessageBox.Show(
            "Erro ao conectar ao banco de dados: " + ex.Message,
            "Erro!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
          );
        }
      }

      return livro;
    }

    public static void LimparList()
    {
      livros.Clear();
    }

    public static void UpdateLivro(int cod_livro, Models.Livro livro)
    {
      using (MySqlConnection conexao = Repositories.Conexao.ObterConexao())
      {
        try
        {
          // Abre a conexão com o banco
          conexao.Open();

          string update_query = "UPDATE livro " +
          "SET titulo = @Titulo, genero = @Genero, " +
          "dt_publicacao = @DtPublicacao, status = @Status, " +
          "id_autor = @IdAutor, id_editora = @IdEditora " +
          "WHERE cod_livro = @CodLivro";
          MySqlCommand comando_update = new MySqlCommand(update_query, conexao);

          if (livro != null)
          {
            comando_update.Parameters.AddWithValue("@Titulo", livro.Titulo);
            comando_update.Parameters.AddWithValue("@Genero", livro.Genero);
            comando_update.Parameters.AddWithValue("@DtPublicacao", livro.DtPublicacao);
            comando_update.Parameters.AddWithValue("@Status", livro.Status);
            comando_update.Parameters.AddWithValue("@IdAutor", livro.IdAutor);
            comando_update.Parameters.AddWithValue("@IdEditora", livro.IdEditora);
            comando_update.Parameters.AddWithValue("@CodLivro", livro.CodLivro);

            int linhas_afetadas = comando_update.ExecuteNonQuery();

            if (linhas_afetadas > 0)
            {
              Models.Livro livro_existente = GetLivro(cod_livro);
              livro_existente = livro;
            }
            else
            {
              MessageBox.Show(
                "Não foi possível editar o livro!",
                "Erro!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
              );
            }
          }
          else
          {
            MessageBox.Show(
              "Livro não encontrado!",
              "Erro!",
              MessageBoxButtons.OK,
              MessageBoxIcon.Error
            );
          }

          // Fecha a conexão com o banco
          conexao.Close();
        }

        catch (Exception ex)
        {
          MessageBox.Show(
            "Erro ao conectar ao banco de dados: " + ex.Message,
            "Erro!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
          );
        }
      }
    }

    public static void DeleteLivro(int cod_livro)
    {
      using (MySqlConnection conexao = Repositories.Conexao.ObterConexao())
      {
        try
        {
          // Abre a conexão com o banco
          conexao.Open();

          string delete_query = "DELETE FROM livro WHERE cod_livro = @CodLivro";
          MySqlCommand comando_delete = new MySqlCommand(delete_query, conexao);

          Models.Livro livro = GetLivro(cod_livro);
          comando_delete.Parameters.AddWithValue("@CodLivro", livro.CodLivro);
          int linhas_afetadas = comando_delete.ExecuteNonQuery();

          if (linhas_afetadas > 0)
          {
            livros.Remove(livro);
          }
          else
          {
            MessageBox.Show(
              "Não foi possível excluir o livro!",
              "Erro!",
              MessageBoxButtons.OK,
              MessageBoxIcon.Error
            );
          }

          // Fecha a conexão com o banco
          conexao.Close();
        }

        catch (Exception ex)
        {
          MessageBox.Show(
            "Erro ao conectar ao banco de dados: " + ex.Message,
            "Erro!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
          );
        }
      }
    }
  }
}