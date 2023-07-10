using System;
using MySql.Data.MySqlClient;
using DotNetEnv;

namespace Repositories
{
  public static class Conexao
  {
    public static MySqlConnection ObterConexao()
    {
      Env.Load();
      
      string server = Environment.GetEnvironmentVariable("DB_SERVER");
      string user = Environment.GetEnvironmentVariable("DB_USER");
      string database = Environment.GetEnvironmentVariable("DB_DATABASE");

      string string_conexao = $"server={server};user={user};database={database};";

      return new MySqlConnection(string_conexao);
    }
  }
}
