using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace Repositories
{
  public class UsuarioRepository
  {
    static List<Models.Usuario> usuarios = new List<Models.Usuario>();

    public static void AddUsuario(Models.Usuario usuario)
    {
      using (MySqlConnection conexao = Repositories.Conexao.ObterConexao())
      {
        try
        {
          // Abre a conexão com o banco
          conexao.Open();

          string insert_query = "INSERT INTO usuario " +
          "(nome, dt_nascimento, endereco, telefone, email) " +
          "VALUES (@Nome, @DtNascimento, @Endereco, @Telefone, @Email)";
          MySqlCommand comando_insert = new MySqlCommand(insert_query, conexao);

          if (usuario != null)
          {
            comando_insert.Parameters.AddWithValue("@Nome", usuario.Nome);
            comando_insert.Parameters.AddWithValue("@DtNascimento", usuario.DtNascimento);
            comando_insert.Parameters.AddWithValue("@Endereco", usuario.Endereco);
            comando_insert.Parameters.AddWithValue("@Telefone", usuario.Telefone);
            comando_insert.Parameters.AddWithValue("@Email", usuario.Email);

            int linhas_afetadas = comando_insert.ExecuteNonQuery();
            usuario.IdUsuario = Convert.ToInt32(comando_insert.LastInsertedId);

            if (linhas_afetadas > 0)
            {
              usuarios.Add(usuario);
            }
            else
            {
              MessageBox.Show(
                "Não foi possível adicionar o usuário!",
                "Erro!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
              );
            }
          }
          else
          {
            MessageBox.Show(
              "Não foi possível adicionar o usuário!",
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

    public static List<Models.Usuario> ListUsuarios()
    {
      using (MySqlConnection conexao = Repositories.Conexao.ObterConexao())
      {
        try
        {
          // Abre a conexão com o banco de dados
          conexao.Open();

          // Consulta SQL para recuperar os registros da tabela de usuários
          string select_query = "SELECT * FROM usuario";

          // Cria um comando MySqlCommand com a consulta SQL e a conexão
          MySqlCommand comando_select = new MySqlCommand(select_query, conexao);
          MySqlDataAdapter bdAdapter = new MySqlDataAdapter(comando_select);

          DataSet dbDataSet = new DataSet();
          bdAdapter.Fill(dbDataSet, "usuario");
          DataTable table = dbDataSet.Tables["usuario"];

          foreach (DataRow row in table.Rows)
          {
            // Aqui você pode acessar os dados retornados pela consulta SELECT
            Models.Usuario usuario = new Models.Usuario();
            usuario.IdUsuario = Convert.ToInt32(row["id_usuario"].ToString());
            usuario.Nome = row["nome"].ToString();
            usuario.DtNascimento = Convert.ToDateTime(row["dt_nascimento"]);
            usuario.Endereco = row["endereco"].ToString();
            usuario.Telefone = row["telefone"].ToString();
            usuario.Email = row["email"].ToString();
            usuarios.Add(usuario);
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
      return usuarios;
    }

    public static Models.Usuario? GetUsuario(int id_usuario)
    {
      Models.Usuario usuario = new Models.Usuario();
      using (MySqlConnection conexao = Repositories.Conexao.ObterConexao())
      {
        try
        {
          // Abre a conexão com o banco
          conexao.Open();

          // Consulta SQL para recuperar o usuário pelo id
          string select_query = "SELECT * FROM usuario WHERE id_usuario = @IdUsuario";

          MySqlCommand comando_select = new MySqlCommand(select_query, conexao);

          if (id_usuario != null)
          {
            comando_select.Parameters.AddWithValue("@IdUsuario", id_usuario);

            MySqlDataAdapter bdAdapter = new MySqlDataAdapter(comando_select);

            DataSet dbDataSet = new DataSet();
            bdAdapter.Fill(dbDataSet, "usuario");
            DataTable table = dbDataSet.Tables["usuario"];

            foreach (DataRow row in table.Rows)
            {
              // Aqui você pode acessar os dados retornados pela consulta SELECT
              usuario.IdUsuario = Convert.ToInt32(row["id_usuario"].ToString());
              usuario.Nome = row["nome"].ToString();
              usuario.DtNascimento = Convert.ToDateTime(row["dt_nascimento"]);
              usuario.Endereco = row["endereco"].ToString();
              usuario.Telefone = row["telefone"].ToString();
              usuario.Email = row["email"].ToString();
            }
          }
          else
          {
            MessageBox.Show(
              "Usuário não encontrado!",
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

      return usuario;
    }

    public static void LimparList()
    {
      usuarios.Clear();
    }

    public static void UpdateUsuario(int id_usuario, Models.Usuario usuario)
    {
      using (MySqlConnection conexao = Repositories.Conexao.ObterConexao())
      {
        try
        {
          // Abre a conexão com o banco
          conexao.Open();

          string update_query = "UPDATE usuario " +
          "SET nome = @Nome, dt_nascimento = @DtNascimento, " +
          "endereco = @Endereco, telefone = @Telefone, email = @Email " +
          "WHERE id_usuario = @IdUsuario";
          MySqlCommand comando_update = new MySqlCommand(update_query, conexao);

          if (usuario != null)
          {
            comando_update.Parameters.AddWithValue("@Nome", usuario.Nome);
            comando_update.Parameters.AddWithValue("@DtNascimento", usuario.DtNascimento);
            comando_update.Parameters.AddWithValue("@Endereco", usuario.Endereco);
            comando_update.Parameters.AddWithValue("@Telefone", usuario.Telefone);
            comando_update.Parameters.AddWithValue("@Email", usuario.Email);
            comando_update.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);

            int linhas_afetadas = comando_update.ExecuteNonQuery();

            if (linhas_afetadas > 0)
            {
              Models.Usuario usuario_existente = GetUsuario(id_usuario);
              usuario_existente = usuario;
            }
            else
            {
              MessageBox.Show(
                "Não foi possível editar o usuário!",
                "Erro!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
              );
            }
          }
          else
          {
            MessageBox.Show(
              "Usuário não encontrado!",
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

    public static void DeleteUsuario(int id_usuario)
    {
      using (MySqlConnection conexao = Repositories.Conexao.ObterConexao())
      {
        try
        {
          // Abre a conexão com o banco
          conexao.Open();

          string delete_query = "DELETE FROM usuario WHERE id_usuario = @IdUsuario";
          MySqlCommand comando_delete = new MySqlCommand(delete_query, conexao);

          Models.Usuario usuario = GetUsuario(id_usuario);
          comando_delete.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
          int linhas_afetadas = comando_delete.ExecuteNonQuery();

          if (linhas_afetadas > 0)
          {
            usuarios.Remove(usuario);
          }
          else
          {
            MessageBox.Show(
              "Não foi possível excluir o usuário!",
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