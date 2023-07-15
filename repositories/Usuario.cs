using System;
using System.Collections.Generic;
/* using MySql.Data.MySqlClient;
using System.Data; */

namespace Repositories
{
  public class UsuarioRepository
  {
    static List<Models.Usuario> usuarios = new List<Models.Usuario>();

    public static void AddUsuario(Models.Usuario usuario)
    {
      usuarios.Add(usuario);
      int id_usuario = usuarios.IndexOf(usuario);
      usuario.getIndex(id_usuario);
    }

    public static List<Models.Usuario> ListUsuarios()
    {
      return usuarios;
    }

    /* public static List<Models.Usuario> Sincronizar()
    {
      using (MySqlConnection conexao = Repositories.Conexao.ObterConexao())
      {
        try
        {
          // Abre a conexão com o banco de dados
          conexao.Open();

          // Consulta SQL para recuperar os registros da tabela de usuários
          string selectQuery = "SELECT * FROM usuario";

          // Cria um comando MySqlCommand com a consulta SQL e a conexão
          MySqlCommand comandoSelect = new MySqlCommand(selectQuery, conexao);
          MySqlDataAdapter bdAdapter = new MySqlDataAdapter(comandoSelect);

          DataSet dbDataSet = new DataSet();
          bdAdapter.Fill(dbDataSet, "usuarios");
          DataTable table = dbDataSet.Tables["usuarios"];

          foreach (DataRow row in table.Rows)
          {
            // Aqui você pode acessar os dados retornados pela consulta SELECT
            int id = Convert.ToInt32(row["id_usuario"].ToString());
            Models.Usuario usuario = new Models.Usuario();
            usuario.IdUsuario = id;
            usuario.Nome = row["nome"].ToString();
            usuario.DtNascimento = Convert.ToDateTime(row["dt_nascimento"]);
            usuario.Endereco = row["endereco"].ToString();
            usuario.Telefone = row["telefone"].ToString();
            usuario.Email = row["email"].ToString();
            usuarios.Add(usuario);
          }
          conexao.Close();
        }

        catch (Exception ex)
        {
          MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
      return usuarios;
    } */

    public static Models.Usuario? GetUsuario(int id_usuario)
    {
      if (id_usuario < 0 || id_usuario >= usuarios.Count)
      {
        return null;
      }
      else
      {
        return usuarios[id_usuario];
      }
    }

    public static void UpdateUsuario(int id_usuario, Models.Usuario usuario)
    {
      usuarios[id_usuario] = usuario;
    }

    public static void DeleteUsuario(int id_usuario)
    {
      usuarios.RemoveAt(id_usuario);
    }
  }
}