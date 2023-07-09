using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using DotNetEnv;

namespace Repositories
{
  public static class Conexao
  {
    public static void Conectar()
    {
      Env.Load();

      string server = Environment.GetEnvironmentVariable("DB_SERVER");
      string user = Environment.GetEnvironmentVariable("DB_USER");
      string database = Environment.GetEnvironmentVariable("DB_DATABASE");

      string string_conexao = $"server={server};user={user};database={database};";

      using (MySqlConnection conexao = new MySqlConnection(string_conexao))
      {
        try
        {
          conexao.Open();
          MessageBox.Show("Conexão bem-sucedida!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

          // Faça as operações desejadas com o banco de dados aqui

          conexao.Close();
        }
        catch (Exception ex)
        {
          MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }
  }
}
