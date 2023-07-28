using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace Repositories
{
  public class EmprestimoRepository
  {
    static List<Models.Emprestimo> emprestimos = new List<Models.Emprestimo>();

    public static void Emprestar(Models.Emprestimo emprestimo)
    {
      using (MySqlConnection conexao = Repositories.Conexao.ObterConexao())
      {
        try
        {
          Models.Livro livro = Controllers.LivroController.GetLivro(emprestimo.CodLivro);
          Models.Usuario usuario = Controllers.UsuarioController.GetUsuario(emprestimo.IdUsuario);

          if (livro == null && usuario == null)
          {
            MessageBox.Show(
              "Livro e usuário não cadastrados no banco de dados!",
              "Erro!",
              MessageBoxButtons.OK,
              MessageBoxIcon.Error
            );
            return; // Retorna sem realizar o empréstimo
          }
          else if (livro == null)
          {
            MessageBox.Show(
              "Livro não cadastrado no banco de dados!",
              "Erro!",
              MessageBoxButtons.OK,
              MessageBoxIcon.Error
            );
            return; // Retorna sem realizar o empréstimo
          }
          else if (usuario == null)
          {
            MessageBox.Show(
              "Usuário não cadastrado no banco de dados!",
              "Erro!",
              MessageBoxButtons.OK,
              MessageBoxIcon.Error
            );
            return; // Retorna sem realizar o empréstimo
          }
          else if (livro.Status == "Emprestado")
          {
            MessageBox.Show(
              "Este livro já está emprestado no momento!",
              "Erro!",
              MessageBoxButtons.OK,
              MessageBoxIcon.Error
            );
            return; // Retorna sem realizar o empréstimo
          }
          else
          {
            // Abre a conexão com o banco
            conexao.Open();

            string insert_query = "INSERT INTO emprestimo " +
            "(dt_emprestimo, dt_prev_devolucao, dt_real_devolucao, cod_livro, id_usuario) " +
            "VALUES (@DtEmprestimo, @DtPrevDevolucao, @DtRealDevolucao, @CodLivro, @IdUsuario)";
            MySqlCommand comando_insert = new MySqlCommand(insert_query, conexao);

            if (emprestimo != null)
            {
              comando_insert.Parameters.AddWithValue("@DtEmprestimo", emprestimo.DtEmprestimo);
              comando_insert.Parameters.AddWithValue("@DtPrevDevolucao", emprestimo.DtPrevDevolucao);
              comando_insert.Parameters.AddWithValue("@DtRealDevolucao", emprestimo.DtRealDevolucao);
              comando_insert.Parameters.AddWithValue("@CodLivro", emprestimo.CodLivro);
              comando_insert.Parameters.AddWithValue("@IdUsuario", emprestimo.IdUsuario);

              int linhas_afetadas = comando_insert.ExecuteNonQuery();
              emprestimo.CodEmprestimo = Convert.ToInt32(comando_insert.LastInsertedId);

              if (linhas_afetadas > 0)
              {
                emprestimos.Add(emprestimo);

                livro.Status = "Emprestado";
                Controllers.LivroController.UpdateLivro(livro.CodLivro, livro);

                // Exibe o MessageBox de livro emprestado com sucesso
                MessageBox.Show(
                  "Livro emprestado com sucesso!",
                  "Sucesso!",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information
                );
              }
              else
              {
                MessageBox.Show(
                  "Não foi possível emprestar o livro!",
                  "Erro!",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error
                );
              }
            }
            else
            {
              MessageBox.Show(
                "Não foi possível emprestar o livro!",
                "Erro!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
              );
            }

            // Fecha a conexão com o banco
            conexao.Close();
          }
        }

        catch (MySqlException ex)
        {
          if (ex.Number == 1452) // Número do erro para chave estrangeira não encontrada
          {
            // Verifica se tanto o livro quanto o usuário não foram encontrados
            if (ex.Message.Contains("livro") && ex.Message.Contains("usuario"))
            {
              MessageBox.Show(
                  "Livro e usuário não cadastrados no banco de dados!",
                  "Erro!",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error
              );
            }
            else if (ex.Message.Contains("livro"))
            {
              MessageBox.Show(
                  "Livro não cadastrado no banco de dados!",
                  "Erro!",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error
              );
            }
            else if (ex.Message.Contains("usuario"))
            {
              MessageBox.Show(
                  "Usuário não cadastrado no banco de dados!",
                  "Erro!",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error
              );
            }
          }
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

    public static List<Models.Emprestimo> ListEmprestimos()
    {
      using (MySqlConnection conexao = Repositories.Conexao.ObterConexao())
      {
        try
        {
          // Abre a conexão com o banco de dados
          conexao.Open();

          // Consulta SQL para recuperar os registros da tabela de emprestimos
          string select_query = "SELECT * FROM emprestimo";

          // Cria um comando MySqlCommand com a consulta SQL e a conexão
          MySqlCommand comando_select = new MySqlCommand(select_query, conexao);
          MySqlDataAdapter bdAdapter = new MySqlDataAdapter(comando_select);

          DataSet dbDataSet = new DataSet();
          bdAdapter.Fill(dbDataSet, "emprestimo");
          DataTable table = dbDataSet.Tables["emprestimo"];

          foreach (DataRow row in table.Rows)
          {
            // Aqui você pode acessar os dados retornados pela consulta SELECT
            Models.Emprestimo emprestimo = new Models.Emprestimo();
            emprestimo.CodEmprestimo = Convert.ToInt32(row["cod_emprestimo"].ToString());
            emprestimo.DtEmprestimo = Convert.ToDateTime(row["dt_emprestimo"]);
            emprestimo.DtPrevDevolucao = Convert.ToDateTime(row["dt_prev_devolucao"]);

            // Verifica se dt_real_devolucao é nula antes de atribuir ao objeto
            if (row["dt_real_devolucao"] != DBNull.Value)
            {
              emprestimo.DtRealDevolucao = Convert.ToDateTime(row["dt_real_devolucao"]);
            }

            emprestimo.CodLivro = Convert.ToInt32(row["cod_livro"].ToString());
            emprestimo.IdUsuario = Convert.ToInt32(row["id_usuario"].ToString());
            emprestimos.Add(emprestimo);
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
      return emprestimos;
    }

    public static Models.Emprestimo? GetEmprestimo(int cod_emprestimo)
    {
      // Encontra o emprestimo na List com base no valor do atributo CodEmprestimo
      return emprestimos.Find(e => e.CodEmprestimo == cod_emprestimo);
    }

    public static void LimparList()
    {
      emprestimos.Clear();
    }

    public static void UpdateEmprestimo(int cod_emprestimo, Models.Emprestimo emprestimo)
    {
      using (MySqlConnection conexao = Repositories.Conexao.ObterConexao())
      {
        try
        {
          // Abre a conexão com o banco
          conexao.Open();

          string update_query = "UPDATE emprestimo " +
          "SET dt_emprestimo = @DtEmprestimo, dt_prev_devolucao = @DtPrevDevolucao, " +
          "dt_real_devolucao = @DtRealDevolucao, cod_livro = @CodLivro, id_usuario = @IdUsuario " +
          "WHERE cod_emprestimo = @CodEmprestimo";
          MySqlCommand comando_update = new MySqlCommand(update_query, conexao);

          if (emprestimo != null)
          {
            comando_update.Parameters.AddWithValue("@DtEmprestimo", emprestimo.DtEmprestimo);
            comando_update.Parameters.AddWithValue("@DtPrevDevolucao", emprestimo.DtPrevDevolucao);
            comando_update.Parameters.AddWithValue("@DtRealDevolucao", emprestimo.DtRealDevolucao);
            comando_update.Parameters.AddWithValue("@CodLivro", emprestimo.CodLivro);
            comando_update.Parameters.AddWithValue("@IdUsuario", emprestimo.IdUsuario);
            comando_update.Parameters.AddWithValue("@CodEmprestimo", emprestimo.CodEmprestimo);

            int linhas_afetadas = comando_update.ExecuteNonQuery();

            if (linhas_afetadas > 0)
            {
              Models.Emprestimo emprestimo_existente = GetEmprestimo(cod_emprestimo);
              emprestimo_existente = emprestimo;
            }
            else
            {
              MessageBox.Show(
                "Não foi possível atualizar o empréstimo!",
                "Erro!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
              );
            }
          }
          else
          {
            MessageBox.Show(
              "Empréstimo não encontrado!",
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

    public static void DeleteEmprestimo(int cod_emprestimo)
    {
      using (MySqlConnection conexao = Repositories.Conexao.ObterConexao())
      {
        try
        {
          // Abre a conexão com o banco
          conexao.Open();

          string delete_query = "DELETE FROM emprestimo WHERE cod_emprestimo = @CodEmprestimo";
          MySqlCommand comando_delete = new MySqlCommand(delete_query, conexao);

          Models.Emprestimo emprestimo = GetEmprestimo(cod_emprestimo);
          comando_delete.Parameters.AddWithValue("@CodEmprestimo", emprestimo.CodEmprestimo);
          int linhas_afetadas = comando_delete.ExecuteNonQuery();

          if (linhas_afetadas > 0)
          {
            emprestimos.Remove(emprestimo);
          }
          else
          {
            MessageBox.Show(
              "Não foi possível excluir o empréstimo!",
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